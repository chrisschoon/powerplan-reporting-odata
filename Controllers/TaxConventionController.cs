using PowerPlan.OData.Models;

namespace PowerPlan.OData.Controllers
{
    public class TaxConventionController : GenericODataController<TaxConvention>
    {
        public TaxConventionController(SandboxSqlPoolReportingContext context) : base(context) { }
    }
}