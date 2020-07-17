using PowerPlan.OData.Models;

namespace PowerPlan.OData.Controllers
{
    public class TaxDepreciationController : GenericODataController<TaxDepreciation>
    {
        public TaxDepreciationController(SandboxSqlPoolReportingContext context) : base(context) { }
    }
}