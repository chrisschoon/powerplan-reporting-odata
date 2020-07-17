using PowerPlan.OData.Models;

namespace PowerPlan.OData.Controllers
{
    public class DeferredIncomeTaxRatesController : GenericODataController<DeferredIncomeTaxRates>
    {
        public DeferredIncomeTaxRatesController(SandboxSqlPoolReportingContext context) : base(context) { }
    }
}