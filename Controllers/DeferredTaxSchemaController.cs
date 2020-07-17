using PowerPlan.OData.Models;

namespace PowerPlan.OData.Controllers
{
    public class DeferredTaxSchemaController : GenericODataController<DeferredTaxSchema>
    {
        public DeferredTaxSchemaController(SandboxSqlPoolReportingContext context) : base(context) { }
    }
}