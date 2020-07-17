using PowerPlan.OData.Models;

namespace PowerPlan.OData.Controllers
{
    public class PwrhouseTaxYearController : GenericODataController<PwrhouseTaxYear>
    {
        public PwrhouseTaxYearController(SandboxSqlPoolReportingContext context) : base(context) { }
    }
}