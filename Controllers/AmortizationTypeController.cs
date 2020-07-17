using PowerPlan.OData.Models;

namespace PowerPlan.OData.Controllers
{
    public class AmortizationTypeController : GenericODataController<AmortizationType>
    {
        public AmortizationTypeController(SandboxSqlPoolReportingContext context) : base(context) { }
    }
}