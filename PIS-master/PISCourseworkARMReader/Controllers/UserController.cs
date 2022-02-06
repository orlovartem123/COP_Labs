using Microsoft.AspNetCore.Mvc;
using PISBusinessLogic.BindingModels;
using PISBusinessLogic.BusinessLogic;
using PISBusinessLogic.Enums;
using PISBusinessLogic.Interfaces;
using System.IO;
using System.Linq;

namespace PISCourseworkARMReader.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserLogic _user;
        private readonly IBookLogic _bookLogic;
        private readonly EncryptionLogic _enc;
        private readonly Validation validation;
        private readonly ReportLogic _report;

        public UserController(IUserLogic user, IBookLogic bookLogic, EncryptionLogic enc, ReportLogic report)
        {
            _user = user;
            _enc = enc;
            _bookLogic = bookLogic;
            _report = report;
            validation = new Validation();
        }
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Registration()
        {
            return View();
        }

        public IActionResult Report()
        {
            ViewBag.Books = _bookLogic.Read(null);
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
            if (userView.Role == Roles.Читатель)
            {
                Program.Reader = userView;
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
        [HttpPost]
        public ActionResult ValidationRegistration(UserBindingModel user)
        {
            var userView = _user.Read(new UserBindingModel
            {
                Email = user.Email
            }).FirstOrDefault();
            if (userView != null)
            {
                ModelState.AddModelError("", "Данный Email уже занят");
                return View(user);
            }
            _user.CreateOrUpdate(new UserBindingModel
            {
                FIO = user.FIO,
                Password = _enc.Encrypt(user.Password, user.Email),
                Email = user.Email,
                Role = Roles.Читатель
            });
            return RedirectToAction("Login", "User");
        }
        [HttpPost]
        public ActionResult Registration(UserBindingModel user)
        {
            if (validation.registrationCheck(user) != "")
            {
                ModelState.AddModelError("", validation.registrationCheck(user));
                return View();
            }
            return ValidationRegistration(user);

        }
        public IActionResult Logout()
        {
            if (Program.Reader != null)
            {
                Program.Reader = null;
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public IActionResult CreateTable(CreateTableModel model)
        {
            var filePath = _report.GetPerekTable(model.Year);
            return PhysicalFile(filePath, "application/pdf", Path.GetFileName(filePath));
        }
    }

    public class CreateTableModel
    {
        public int Year { get; set; }
    }
}

