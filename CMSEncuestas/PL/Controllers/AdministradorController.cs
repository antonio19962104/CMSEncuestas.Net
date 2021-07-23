using System;
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
            return View(new ML.Administrador());
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="administrador"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Login(ML.Administrador administrador)
        {
            var _token = BL.Login.Autenticar(administrador, Session.SessionID, Modulo.Seguridad.Generales.GetIPAddress());
            return RedirectToAction("Home", "Home", new { _token = _token });
        }
    }
}