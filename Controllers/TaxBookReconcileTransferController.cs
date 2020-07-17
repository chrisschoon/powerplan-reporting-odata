using PowerPlan.OData.Models;

namespace PowerPlan.OData.Controllers
{
    public class TaxBookReconcileTransferController : GenericODataController<TaxBookReconcileTransfer>
    {
        public TaxBookReconcileTransferController(SandboxSqlPoolReportingContext context) : base(context) { }
    }
}