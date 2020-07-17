using PowerPlan.OData.Models;

namespace PowerPlan.OData.Controllers
{
    public class CompanySetupController : GenericODataController<CompanySetup>
    {
        public CompanySetupController(SandboxSqlPoolReportingContext context) : base(context) { }
    }
}