using PowerPlan.OData.Models;

namespace PowerPlan.OData.Controllers
{
    public class TaxTypeOfPropertyController : GenericODataController<TaxTypeOfProperty>
    {
        public TaxTypeOfPropertyController(SandboxSqlPoolReportingContext context) : base(context) { }
    }
}