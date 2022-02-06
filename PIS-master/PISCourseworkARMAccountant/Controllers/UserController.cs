using Microsoft.AspNetCore.Mvc;
using PISBusinessLogic.BindingModels;
using PISBusinessLogic.BusinessLogic;
using PISBusinessLogic.Enums;
using PISBusinessLogic.Interfaces;
using System.Linq;

namespace PISCourseworkARMAccountant.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserLogic _user;
        private readonly EncryptionLogic _enc;
        private readonly Validation validation;

        public UserController(IUserLogic user, EncryptionLogic enc)
        {
            _user = user;
            _enc = enc;
            validation = new Validation();
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ValidationLogin(UserBindingModel user)
        {
            var userView = _user.Read(new UserBindingModel
            {
                Email = user.Email,
            }).FirstOrDefault();
            if (validation.userCheck(user, userView) != "")
            {
                ModelState.AddModelError("", validation.userCheck(user, userView));
                return View();
            }
            if (userView == null)
            {
                ModelState.AddModelError("", "Почта или пароль не верны, попробуйте еще раз");
                return View();
            }
            if (userView.Role == Roles.Бухгалтер)
            {
                Program.Accountant = userView;
            }
            return RedirectToAction("Index", "Home");
        }
        [HttpPost]
        public ActionResult Login(UserBindingModel user)
        {
            if (validation.userCheck(user, null) != "")
            {
                ModelState.AddModelError("", validation.userCheck(user, null));
                return View();
            }
            else
            {
                return ValidationLogin(user);
            }
        }   
        public IActionResult Logout()
        {
            if (Program.Accountant != null)
            {
                Program.Accountant = null;
            }           
            return RedirectToAction("Index", "Home");
        }
    }
}

