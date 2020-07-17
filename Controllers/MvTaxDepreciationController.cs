using PowerPlan.OData.Models;

namespace PowerPlan.OData.Controllers
{
    public class MvTaxDepreciationController : GenericODataController<MvTaxDepreciation>
    {
        public MvTaxDepreciationController(SandboxSqlPoolReportingContext context) : base(context) { }
    }
}