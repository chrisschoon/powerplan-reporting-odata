using PowerPlan.OData.Models;

namespace PowerPlan.OData.Controllers
{
    public class TaxYearVersionController : GenericODataController<TaxYearVersion>
    {
        public TaxYearVersionController(SandboxSqlPoolReportingContext context) : base(context) { }
    }
}