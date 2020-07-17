using PowerPlan.OData.Models;

namespace PowerPlan.OData.Controllers
{
    public class TaxClassController : GenericODataController<TaxClass>
    {
        public TaxClassController(SandboxSqlPoolReportingContext context) : base(context) { }
    }
}