using PowerPlan.OData.Models;

namespace PowerPlan.OData.Controllers
{
    public class TaxLocationController : GenericODataController<TaxLocation>
    {
        public TaxLocationController(SandboxSqlPoolReportingContext context) : base(context) { }
    }
}