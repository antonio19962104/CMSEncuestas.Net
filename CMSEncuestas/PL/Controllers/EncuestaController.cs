using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class EncuestaController : Controller
    {
        // GET: Encuesta
        public ActionResult Index(string _token)
        {
            var token = Modulo.Seguridad.Generales.ValidaToken(_token, Session.SessionID);
            if (!token.Correct)
                return new JsonResult() { };
            return View(BL.Encuesta.GetAll());
        }
        public ActionResult Add()
        {
            return View(new ML.Encuesta());
        }
        public ActionResult Add(ML.Encuesta encuesta)
        {
            return Json(BL.Encuesta.Add(encuesta));
        }
    }
}