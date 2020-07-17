using PowerPlan.OData.Models;

namespace PowerPlan.OData.Controllers
{
    public class JurisdictionController : GenericODataController<Jurisdiction>
    {
        public JurisdictionController(SandboxSqlPoolReportingContext context) : base(context) { }
    }
}