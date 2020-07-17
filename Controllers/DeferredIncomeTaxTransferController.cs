using PowerPlan.OData.Models;

namespace PowerPlan.OData.Controllers
{
    public class DeferredIncomeTaxTransferController : GenericODataController<DeferredIncomeTaxTransfer>
    {
        public DeferredIncomeTaxTransferController(SandboxSqlPoolReportingContext context) : base(context) { }
    }
}