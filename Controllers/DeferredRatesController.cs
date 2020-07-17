using PowerPlan.OData.Models;

namespace PowerPlan.OData.Controllers
{
    public class DeferredRatesController : GenericODataController<DeferredRates>
    {
        public DeferredRatesController(SandboxSqlPoolReportingContext context) : base(context) { }
    }
}