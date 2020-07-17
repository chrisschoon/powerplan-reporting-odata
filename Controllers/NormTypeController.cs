using PowerPlan.OData.Models;

namespace PowerPlan.OData.Controllers
{
    public class NormTypeController : GenericODataController<NormType>
    {
        public NormTypeController(SandboxSqlPoolReportingContext context) : base(context) { }
    }
}