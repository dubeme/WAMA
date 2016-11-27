using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WAMA.Core.Models.Service;
using WAMA.Core.ViewModel.User;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WAMA.Web.Controllers
{
    public class PatronController : Controller
    {
        private IUserAccountService _UserAccountService;

        public PatronController(IUserAccountService userAccountService)
        {
            _UserAccountService = userAccountService;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(PatronUserAccountViewModel patron)
        {
            if (!ModelState.IsValid)
            {
                ViewData[AppString.ErrorMessages] = ModelState.Values
                    .Where(val => val.ValidationState == ModelValidationState.Invalid)
                    .Select(val => val.Errors.FirstOrDefault().ErrorMessage);
            }
            else
            {
                try
                {
                    await _UserAccountService.CreateUserAsync(patron);

                    return RedirectToAction(
                        actionName: nameof(CheckInController.Index),
                        controllerName: nameof(CheckInController).Replace(AppString.Controller, string.Empty));
                }
                catch (Exception ex)
                {
                    var errMessages = new List<string>();

                    while (ex != null)
                    {
                        errMessages.Add(ex.Message);
                        ex = ex.InnerException;
                    }

                    ViewData[AppString.ErrorMessages] = errMessages;
                }
            }

            return View();
        }
    }
}