using Microsoft.AspNet.OData.Builder;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OData.Edm;
using PowerPlan.OData.Models;
using System;
using System.Linq;
using System.Reflection;

namespace PowerPlan.OData
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<SandboxSqlPoolReportingContext>().AddLogging(opt =>
            {
                opt.AddEventLog();
            });
            services.AddControllers(mvcOptions => mvcOptions.EnableEndpointRouting = false).AddNewtonsoftJson();
            services.AddOData();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseMvc(routeBuilder =>
            {
                routeBuilder.EnableDependencyInjection();
                routeBuilder.Count().Expand().Filter().OrderBy().Select().MaxTop(1000);
                routeBuilder.MapODataServiceRoute("odata", "odata", GetEdmModel());
            });
        }

        private IEdmModel GetEdmModel()
        {
            var builder = new ODataConventionModelBuilder();

            var types = Assembly.GetExecutingAssembly().GetTypes().Where(t => t.GetInterfaces().Contains(typeof(IGenericODataModel))).ToList();
            foreach (Type type in types)
            {
                var entityTypeConfig = builder.AddEntityType(type);
                builder.AddEntitySet(type.Name, entityTypeConfig);
            }

            return builder.GetEdmModel();
        }
    }
}
