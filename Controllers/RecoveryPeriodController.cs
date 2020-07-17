using PowerPlan.OData.Models;

namespace PowerPlan.OData.Controllers
{
    public class RecoveryPeriodController : GenericODataController<RecoveryPeriod>
    {
        public RecoveryPeriodController(SandboxSqlPoolReportingContext context) : base(context) { }
    }
}