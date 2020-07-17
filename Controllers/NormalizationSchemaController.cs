using PowerPlan.OData.Models;

namespace PowerPlan.OData.Controllers
{
    public class NormalizationSchemaController : GenericODataController<NormalizationSchema>
    {
        public NormalizationSchemaController(SandboxSqlPoolReportingContext context) : base(context) { }
    }
}