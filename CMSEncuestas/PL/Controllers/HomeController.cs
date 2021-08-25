using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Home(string _token)
        {
            return View(new ML.Administrador() { _token = _token });
        }
        public JsonResult GetTranstale(string modulo)
        {
            ViewBag.Traduccion = LoadJson(modulo);
            return Json(LoadJson(modulo));
        }
        public static string LoadJson(string modulo)
        {
            using (StreamReader r = new StreamReader(@"\\10.5.2.101\\ClimaLaboral\\" + modulo + ".json"))
            {
                string json = r.ReadToEnd();
                //List<Translate> items = JsonConvert.DeserializeObject<List<Translate>>(json);
                return json;
            }
        }

        public class Translate
        {
            public string id;
            public string spanish;
            public string english;
        }
    }
}