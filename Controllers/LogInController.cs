using System;
using System.Web.Mvc;
using Webtonic.Models.Entities;

namespace Webtonic.Controllers
{
    public class LogInController : Controller
    {
        // GET: LogIn
        #region Login page
        [HttpPost]
        public ActionResult LoginPage(UserLogin model)
        {
            model.EmailAddress = "test@webtonic.co.za";
            //model.Password = "Password1";
            return PartialView("_LoginPage", model);
        }
        #endregion

        #region Login authentication 
        [HttpPost]
        public ActionResult Login(UserLogin model)
        {
            try
            {
                if (model.EmailAddress == "test@webtonic.co.za" && model.Password == "Password1")
                {
                    return RedirectToAction("ViewResults", "Student", new { email = model.EmailAddress, password = model.Password });
                }
                return Json(new { result = "false", message = "Username or Password is incorrect", title = "Invalid LogIn" }, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                return Json(new { result = "false", message = ex.Message, title = "Invalid LogIn" }, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion
    }
}