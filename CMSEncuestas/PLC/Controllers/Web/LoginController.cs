using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace PLC.Controllers.Web
{
    public class LoginController : Controller
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public LoginController(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(ML.Administrador administrador)
        {
            var _token = Modulos.Login.Login.Autenticar(administrador);
            _httpContextAccessor.HttpContext.Session.SetString("keyToken", administrador.Password);
            return RedirectToAction("Home", "Home", new { _token = _token });
        }
    }
}
