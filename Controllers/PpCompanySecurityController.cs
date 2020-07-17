using PowerPlan.OData.Models;

namespace PowerPlan.OData.Controllers
{
    public class PpCompanySecurityController : GenericODataController<PpCompanySecurity>
    {
        public PpCompanySecurityController(SandboxSqlPoolReportingContext context) : base(context) { }
    }
}