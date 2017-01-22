using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using WAMA.Web.Model;

namespace WAMA.Web.Controllers
{
    public abstract class WamaBaseController : Controller
    {
        protected void SetActiveConsoleTool(string tool)
        {
            ViewData[Constants.ADMIN_CONSOLE_ACTIVE_TOOL] = tool;
        }

        public void SetErrorMessages(params string[] errors)
        {
            ViewData[AppString.ErrorMessages] = errors.AsEnumerable();
        }

        public void SetErrorMessages(IEnumerable<string> errors)
        {
            ViewData[AppString.ErrorMessages] = errors;
        }

        public void AddErrorMessage(string error)
        {
            var errors = new string[] { error };

            if (ViewData[AppString.ErrorMessages] is Enumerable)
            {
                errors = Enumerable
                    .Concat(ViewData[AppString.ErrorMessages] as IEnumerable<string>, errors)
                    .ToArray();
            }

            ViewData[AppString.ErrorMessages] = errors.AsEnumerable();
        }
    }
}