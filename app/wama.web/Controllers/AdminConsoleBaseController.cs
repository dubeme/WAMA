using Microsoft.AspNetCore.Mvc;

namespace WAMA.Web.Controllers
{
    [Route("AdminConsole/[controller]/[action]")]
    public abstract class AdminConsoleBaseController : WamaBaseController
    {
    }
}