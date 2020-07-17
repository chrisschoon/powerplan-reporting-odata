using PowerPlan.OData.Models;

namespace PowerPlan.OData.Controllers
{
    public class TaxBookController : GenericODataController<TaxBook>
    {
        public TaxBookController(SandboxSqlPoolReportingContext context) : base(context) { }
    }
}