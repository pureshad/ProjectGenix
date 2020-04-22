using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Genix.Web.Controllers
{
    public abstract partial class BaseController : Controller
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {
        }
    }
}
