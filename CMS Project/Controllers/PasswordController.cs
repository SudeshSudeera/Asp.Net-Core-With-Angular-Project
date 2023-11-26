using Microsoft.AspNetCore.Mvc;
using ModelService;
using UserService;

namespace CMS_Project.Controllers
{
    public class PasswordController : Controller
    {
        private readonly IUserSvc _userSvc;

        public PasswordController(IUserSvc userSvc)
        {
            _userSvc = userSvc;
        }

        public IActionResult ResetPassword(ResetPasswordViewModel model)
        {
            return View(model);
        }

        [HttpPost("[action]")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdatePassword([FromBody] ResetPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _userSvc.ResetPassword(model);

                if (result.IsValid)
                {
                    return RedirectToAction("ResetPasswordConfirmation");
                }
            }
            return BadRequest("Fail");
        }

        public IActionResult ResetPasswordConfirmation()
        {
            return View();
        }
    }
}
