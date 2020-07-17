using PowerPlan.OData.Models;

namespace PowerPlan.OData.Controllers
{
    public class DeferredIncomeTaxController : GenericODataController<DeferredIncomeTax>
    {
        public DeferredIncomeTaxController(SandboxSqlPoolReportingContext context) : base(context) { }
    }
}