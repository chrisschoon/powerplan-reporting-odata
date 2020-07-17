using PowerPlan.OData.Models;

namespace PowerPlan.OData.Controllers
{
    public class BookAllocGroupController : GenericODataController<BookAllocGroup>
    {
        public BookAllocGroupController(SandboxSqlPoolReportingContext context) : base(context) { }
    }
}