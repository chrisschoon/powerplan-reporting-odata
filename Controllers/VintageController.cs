using PowerPlan.OData.Models;

namespace PowerPlan.OData.Controllers
{
    public class VintageController : GenericODataController<Vintage>
    {
        public VintageController(SandboxSqlPoolReportingContext context) : base(context) { }
    }
}