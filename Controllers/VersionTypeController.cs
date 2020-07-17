using PowerPlan.OData.Models;

namespace PowerPlan.OData.Controllers
{
    public class VersionTypeController : GenericODataController<VersionType>
    {
        public VersionTypeController(SandboxSqlPoolReportingContext context) : base(context) { }
    }
}