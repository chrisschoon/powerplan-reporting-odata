using PowerPlan.OData.Models;

namespace PowerPlan.OData.Controllers
{
    public class PwrhouseTaxVersionTypeController : GenericODataController<PwrhouseTaxVersionType>
    {
        public PwrhouseTaxVersionTypeController(SandboxSqlPoolReportingContext context) : base(context) { }
    }
}