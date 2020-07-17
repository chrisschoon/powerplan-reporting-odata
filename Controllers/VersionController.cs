using PowerPlan.OData.Models;

namespace PowerPlan.OData.Controllers
{
    public class VersionController : GenericODataController<Version>
    {
        public VersionController(SandboxSqlPoolReportingContext context) : base(context) { }
    }
}