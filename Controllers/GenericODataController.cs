using Microsoft.AspNet.OData.Query;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PowerPlan.OData.Models;
using System.Linq;
using System.Threading.Tasks;

namespace PowerPlan.OData.Controllers
{
    public class GenericODataController<T> where T : class
    {
        private readonly SandboxSqlPoolReportingContext _context;

        public GenericODataController(SandboxSqlPoolReportingContext context)
        {
            _context = context;
        }

        /// <summary>
        /// The GET endpoint that handles OData requests.
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> Get(ODataQueryOptions<T> odata)
        {
            IQueryable odataQuery;
            var dbSetQuery = _context.Set<T>().AsQueryable();

            // Azure Synapse Analytics Server does not support SQL OFFSET, which EF uses for skipping records.
            // So, we have to do this operation in memory.
            if (odata.Skip != null)
            {
                // Apply ORDER BY and TOP to the dbset query, then execute it (forgoing the use of the unsupported OFFSET command)
                var records = await dbSetQuery.ApplyOrderBy(odata).ApplyTop(odata).ToListAsync();

                // Now that the records are in memory, we can skip the necessary values, and cast as a queryable to apply the remaining odata options
                var recordQuery = records.Skip(odata.Skip.Value).AsQueryable();

                // Apply the rest of the odata options, ignoring $skip, $top, and $orderby, which we have already applied.
                odataQuery = odata.ApplyTo(recordQuery, AllowedQueryOptions.Skip | AllowedQueryOptions.Top | AllowedQueryOptions.OrderBy);
            }
            else
            {
                // There is no $skip requested, so just act normally
                odataQuery = odata.ApplyTo(dbSetQuery);
            }

            return new OkObjectResult(odataQuery);
        }
    }
}
