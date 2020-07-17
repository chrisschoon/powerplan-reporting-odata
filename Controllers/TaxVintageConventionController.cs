using PowerPlan.OData.Models;

namespace PowerPlan.OData.Controllers
{
    public class TaxVintageConventionController : GenericODataController<TaxVintageConvention>
    {
        public TaxVintageConventionController(SandboxSqlPoolReportingContext context) : base(context) { }
    }
}