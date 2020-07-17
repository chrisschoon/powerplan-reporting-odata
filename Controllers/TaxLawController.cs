using PowerPlan.OData.Models;

namespace PowerPlan.OData.Controllers
{
    public class TaxLawController : GenericODataController<TaxLaw>
    {
        public TaxLawController(SandboxSqlPoolReportingContext context) : base(context) { }
    }
}