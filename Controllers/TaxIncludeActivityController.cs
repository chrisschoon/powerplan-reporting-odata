using PowerPlan.OData.Models;

namespace PowerPlan.OData.Controllers
{
    public class TaxIncludeActivityController : GenericODataController<TaxIncludeActivity>
    {
        public TaxIncludeActivityController(SandboxSqlPoolReportingContext context) : base(context) { }
    }
}