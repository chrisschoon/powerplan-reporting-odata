using PowerPlan.OData.Models;

namespace PowerPlan.OData.Controllers
{
    public class TaxRecordControlController : GenericODataController<TaxRecordControl>
    {
        public TaxRecordControlController(SandboxSqlPoolReportingContext context) : base(context) { }
    }
}