using PowerPlan.OData.Models;

namespace PowerPlan.OData.Controllers
{
    public class TaxTransferControlController : GenericODataController<TaxTransferControl>
    {
        public TaxTransferControlController(SandboxSqlPoolReportingContext context) : base(context) { }
    }
}