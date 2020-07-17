using PowerPlan.OData.Models;

namespace PowerPlan.OData.Controllers
{
    public class TaxCreditController : GenericODataController<TaxCredit>
    {
        public TaxCreditController(SandboxSqlPoolReportingContext context) : base(context) { }
    }
}