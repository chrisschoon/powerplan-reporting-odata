using PowerPlan.OData.Models;

namespace PowerPlan.OData.Controllers
{
    public class TaxReconcileItemController : GenericODataController<TaxReconcileItem>
    {
        public TaxReconcileItemController(SandboxSqlPoolReportingContext context) : base(context) { }
    }
}