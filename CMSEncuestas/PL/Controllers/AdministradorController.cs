﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class AdministradorController : Controller
    {
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(ML.Administrador administrador)
        {
            var _token = BL.Administrador.Autenticar(administrador);
            return RedirectToAction("Home", "Home", new { _token = _token });
        }
    }
}