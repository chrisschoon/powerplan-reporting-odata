using PowerPlan.OData.Models;

namespace PowerPlan.OData.Controllers
{
    public class TaxRateControlController : GenericODataController<TaxRateControl>
    {
        public TaxRateControlController(SandboxSqlPoolReportingContext context) : base(context) { }
    }
}