using PowerPlan.OData.Models;

namespace PowerPlan.OData.Controllers
{
    public class TaxBookSchemaController : GenericODataController<TaxBookSchema>
    {
        public TaxBookSchemaController(SandboxSqlPoolReportingContext context) : base(context) { }
    }
}