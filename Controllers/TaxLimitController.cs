using PowerPlan.OData.Models;

namespace PowerPlan.OData.Controllers
{
    public class TaxLimitController : GenericODataController<TaxLimit>
    {
        public TaxLimitController(SandboxSqlPoolReportingContext context) : base(context) { }
    }
}