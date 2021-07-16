using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace InitFiles
{
    class Files
    {
        string DocumentacionControllerContent = @"using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    /// <summary>
    /// Controlador de la documentación del proyecto
    /// </summary>
    public class DocumentacionController : Controller
    {
        /// <summary>
        /// Vista de la documentación del proyecto
        /// </summary>
        /// <returns>Vista de la documentación del proyecto</returns>
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// Obtiene un objeto con la documentacion del proyecto
        /// </summary>
        /// <returns>Objeto con la documentacion del proyecto</returns>
        public JsonResult GetDocumentacion()
        {
            var list = new List<BL.Documentacion.Doc>();
            list.Add(BL.Documentacion.GetBussinessLayerDocumentation());
            list.Add(BL.Documentacion.GetDataLayerDocumentation());
            list.Add(BL.Documentacion.GetModelLayerDocumentation());
            list.Add(BL.Documentacion.GetPresentationLayerDocumentation());
            return Json(list, JsonRequestBehavior.AllowGet);
        }


    }
}";
        string classDocumentacion = "";
        public void createDocumentationController()
        {
            var directory = Directory.GetCurrentDirectory();
            var index = directory.IndexOf("InitFiles");
            directory = directory.Substring(0, index);
            directory = directory + @"PL\\Controllers\\DocumentationController2.cs";
            try
            {
                // Create the file, or overwrite if the file exists.
                using (FileStream fs = File.Create(directory))
                {
                    byte[] info = new UTF8Encoding(true).GetBytes(DocumentacionControllerContent);
                    // Add some information to the file.
                    fs.Write(info, 0, info.Length);
                }

                // Open the stream and read it back.
                using (StreamReader sr = File.OpenText(directory))
                {
                    string s = "";
                    while ((s = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(s);
                    }
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
