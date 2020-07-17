using PowerPlan.OData.Models;

namespace PowerPlan.OData.Controllers
{
    public class BasisAmountsController : GenericODataController<BasisAmounts>
    {
        public BasisAmountsController(SandboxSqlPoolReportingContext context) : base(context) { }
    }
}