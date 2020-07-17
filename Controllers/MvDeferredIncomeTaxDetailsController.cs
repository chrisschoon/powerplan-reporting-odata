using PowerPlan.OData.Models;

namespace PowerPlan.OData.Controllers
{
    public class MvDeferredIncomeTaxDetailsController : GenericODataController<MvDeferredIncomeTaxDetails>
    {
        public MvDeferredIncomeTaxDetailsController(SandboxSqlPoolReportingContext context) : base(context) { }
    }
}