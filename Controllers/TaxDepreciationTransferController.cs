using PowerPlan.OData.Models;

namespace PowerPlan.OData.Controllers
{
    public class TaxDepreciationTransferController : GenericODataController<TaxDepreciationTransfer>
    {
        public TaxDepreciationTransferController(SandboxSqlPoolReportingContext context) : base(context) { }
    }
}