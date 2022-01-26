﻿using Microsoft.AspNetCore.Mvc;
using PISBusinessLogic.BindingModels;
using PISBusinessLogic.BusinessLogic;
using PISBusinessLogic.Enums;
using PISBusinessLogic.HelperModels;
using PISBusinessLogic.Interfaces;
using PISBusinessLogic.ViewModels;
using PISCourseworkARMReader.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PISCourseworkARMReader.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserLogic _user;
        private readonly IBookLogic _bookLogic;
        private readonly IGenreLogic _genreLogic;
        private readonly IContractLogic _contractLogic;
        private readonly EncryptionLogic _enc;
        private readonly Validation validation;

        public UserController(IUserLogic user, IBookLogic bookLogic, IGenreLogic genreLogic, IContractLogic contractLogic, EncryptionLogic enc)
        {
            _user = user;
            _enc = enc;
            _genreLogic = genreLogic;
            _contractLogic = contractLogic;
            _bookLogic = bookLogic;
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
            ViewBag.Genres = _genreLogic.Read(null);
            ViewBag.Contracts = _contractLogic.Read(null);
            ViewBag.Books = _bookLogic.Read(null);
            return View();
        }

        [HttpPost]
        public ActionResult Report()
        {

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
    }
}

