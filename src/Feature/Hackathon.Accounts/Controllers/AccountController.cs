using System.Web.Mvc;
using Hackathon.Accounts.Infrastructure;
using Hackathon.Accounts.Models;

namespace Hackathon.Accounts.Controllers
{
    public class AccountController : Controller
    {
        private IAccountManager accountManager; 

        public  AccountController(IAccountManager accountManager)
        {
            this.accountManager = accountManager;
        }
        // GET: Account
        public ActionResult Login()
        {
            return View("~/Views/Renderings/Account/Login.cshtml");
        }

        [HttpPost]
        public ActionResult Login(LoginModel loginModel)
        {
            accountManager.Login(loginModel.Email, loginModel.Password);

            return View("~/Views/Renderings/Account/Login.cshtml", loginModel);
        }

        public ActionResult Registration()
        {
            return View("~/Views/Renderings/Account/Registration.cshtml");
        }

        [HttpPost]
        public ActionResult Registration(RegistrationModel registrationModel)
        {
            if (ModelState.IsValid)
            {
                accountManager.Register(registrationModel.FirstName, registrationModel.LastName, registrationModel.Email, registrationModel.Password, registrationModel.DateOfBirth, registrationModel.Gender, registrationModel.Country);
                // return View("~/Views/Renderings/Account/Registration.cshtml", registrationModel);
                ModelState.AddModelError("", "");
                return Redirect("/");
            }
            else
            {
                ModelState.AddModelError("", "User already exists");
            }
            return View("~/Views/Renderings/Account/Registration.cshtml", registrationModel);
        }
    }
}