using PowerPlan.OData.Models;

namespace PowerPlan.OData.Controllers
{
    public class TaxBookReconcileController : GenericODataController<TaxBookReconcile>
    {
        public TaxBookReconcileController(SandboxSqlPoolReportingContext context) : base(context) { }
    }
}