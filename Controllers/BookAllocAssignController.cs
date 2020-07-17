using PowerPlan.OData.Models;

namespace PowerPlan.OData.Controllers
{
    public class BookAllocAssignController : GenericODataController<BookAllocAssign>
    {
        public BookAllocAssignController(SandboxSqlPoolReportingContext context) : base(context) { }
    }
}