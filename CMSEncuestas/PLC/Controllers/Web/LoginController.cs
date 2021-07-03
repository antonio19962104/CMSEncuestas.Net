using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PLC.Controllers.Web
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult Login(ML.Administrador administrador)
        {
            var _token = Modulos.Login.Login.Autenticar(administrador);
            return View("Home/?_token=" + _token);
        }
    }
}
