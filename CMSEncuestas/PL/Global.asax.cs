using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace PL
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            BL.Seguridad seguridad = new BL.Seguridad();
            var r = PL.Controllers.HomeController.LoadJson("encuesta");
            var contentHtml = string.Empty;
            HttpWebRequest request = WebRequest.Create("http://autofin.com/auto") as HttpWebRequest;
            request.Method = "GET";
            request.ContentType = "application/x-www-form-urlencoded";

            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            using (StreamReader reader = new StreamReader(response.GetResponseStream()))
            {
                string resp = reader.ReadToEnd();
                contentHtml = resp;
            }
            List<string> img = new List<string>();
            var indice = 0;
            for (int i = 0; i < 8; i++)
            {
                var cadena = contentHtml.Substring((indice + 1), (contentHtml.Length - (indice+1)));
                var indice1 = cadena.IndexOf("http://www.autofin.com/pub/media/wysiwyg/");
                indice = indice1;
                img.Add(contentHtml.Substring(indice1, 100));
            }

            img = new List<string>();
            var linkParser = new Regex(@"\b(?:https?://|www\.)\S+\b", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            var rawString = contentHtml;
            foreach (Match m in linkParser.Matches(rawString))
            {
                Console.WriteLine(m.Value);
                if (m.Value.Contains("http://www.autofin.com/pub/media/wysiwyg"))
                {
                    var ind = m.Value.IndexOf("jpg");
                    img.Add(m.Value.Substring(0, 3));
                }
            }
                

            Console.WriteLine(img);
            // usuario|pass|opc|nivel|f1,f2,f3,f4
            //var token = seguridad.EncriptarCadena("jamurillo@grupoautofin.com|Pass@word01|opc|nivel|f1,f2,f3,f4");
            //var credencales = seguridad.DesencriptarCadena(token);
        }
    }
}
