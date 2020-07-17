using PowerPlan.OData.Models;

namespace PowerPlan.OData.Controllers
{
    public class TaxIncludeController : GenericODataController<TaxInclude>
    {
        public TaxIncludeController(SandboxSqlPoolReportingContext context) : base(context) { }
    }
}