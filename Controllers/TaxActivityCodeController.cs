using PowerPlan.OData.Models;

namespace PowerPlan.OData.Controllers
{
    public class TaxActivityCodeController : GenericODataController<TaxActivityCode>
    {
        public TaxActivityCodeController(SandboxSqlPoolReportingContext context) : base(context) { }
    }
}