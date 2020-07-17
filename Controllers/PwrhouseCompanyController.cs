using PowerPlan.OData.Models;

namespace PowerPlan.OData.Controllers
{
    public class PwrhouseCompanyController : GenericODataController<PwrhouseCompany>
    {
        public PwrhouseCompanyController(SandboxSqlPoolReportingContext context) : base(context) { }
    }
}