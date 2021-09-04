using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    /// <summary>
    /// Contiene metodos que se usan de manera general en la solucion
    /// </summary>
    public class Generales
    {
        /// <summary>
        /// convierte un DataSet a entidades Entity Framework
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="row"></param>
        /// <returns>objeto del del namespace DL</returns>
        public static T GetEntity<T>(DataRow row) where T : new()
        {
            var entity = new T();
            var properties = typeof(T).GetProperties();
            foreach (var property in properties)
            {
                //Get the description attribute and set value in DataSet to Entity
                var descriptionAttribute = (DescriptionAttribute)property.GetCustomAttributes(typeof(DescriptionAttribute), true).SingleOrDefault();
                if (descriptionAttribute == null)
                    continue;

                property.SetValue(entity, row[descriptionAttribute.Description]);
            }
            return entity;
        }

        /// <summary>
        /// itera los valores de una lista de objetos e imprime los valores de las propiedades en un log
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <param name="st"></param>
        /// <returns></returns>
        public static T print_r<T>(List<T> data, StackTrace st) where T : new()
        {
            foreach (var elem in data)
            {
                Nlog.logData("/------------------------------------------------------------------------/");
                Nlog.logData("Tipo: " + typeof(T).FullName);
                Nlog.logData("Method: " + st.GetFrame(0).GetMethod());
                var properties = typeof(T).GetProperties();
                foreach (var property in properties)
                {
                    var value = Convert.ToString(property.GetValue(elem));
                    if (!string.IsNullOrEmpty(value))
                        Nlog.logData("Propiedad: " + property.Name + ". Valor: " + value);
                }
            }
            return new T();
        }

        /// <summary>
        /// itera las propiedades de un objeto y las imprime en un log
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <param name="st"></param>
        /// <returns></returns>
        public static T print_r<T>(object data, StackTrace st) where T : new()
        {
            Nlog.logData("/------------------------------------------------------------------------/");
            Nlog.logData("Tipo: " + typeof(T).FullName);
            Nlog.logData("Method: " + st.GetFrame(0).GetMethod());
            var properties = typeof(T).GetProperties();
            foreach (var property in properties)
            {
                var value = Convert.ToString(property.GetValue(data));
                if (!string.IsNullOrEmpty(value))
                    Nlog.logData("Propiedad: " + property.Name + ". Valor: " + value);
            }
            return new T();
        }
        /// <summary>
        /// Get base64 string for specified image
        /// </summary>
        /// <param name="path"></param>
        /// <returns>base64 string for specified image</returns>
        public static string GetBase64FromFile(string path)
        {
            try
            {
                Byte[] bytes = File.ReadAllBytes(path);
                String file = Convert.ToBase64String(bytes);
                return file;
            }
            catch (Exception)
            {
                return ML.Constantes.UnavailableImage;
            }
        }
        /// <summary>
        /// Create file image in specified location
        /// </summary>
        /// <param name="cadenaBase64"></param>
        /// <param name="IdProductoIntercambiable"></param>
        /// <returns>string path image</returns>
        public static string CrearImagenEnDirectorio(string cadenaBase64, int IdProductoIntercambiable)
        {
            try
            {
                string base64 = GetBase64ValidData(cadenaBase64);
                string ext = GetBase64Extension(cadenaBase64);
                var nombreImagen = "image_IdPCanjeable_" + IdProductoIntercambiable + "." + ext;
                var ruta = @"\\10.5.2.101\Demos\ArchivosProgramaLealtad\media_productosCanjeables\";
                if (!Directory.Exists(ruta))
                    Directory.CreateDirectory(ruta);
                if (System.IO.File.Exists(ruta + nombreImagen))
                    System.IO.File.Delete(ruta + nombreImagen);
                byte[] bytes = Convert.FromBase64String(base64);
                System.IO.File.WriteAllBytes(ruta + nombreImagen, bytes);
                return ruta + "\\" + nombreImagen;
            }
            catch (Exception aE)
            {
                return string.Empty;
            }
        }
        /// <summary>
        /// Construct valid base64 string
        /// </summary>
        /// <param name="cadena"></param>
        /// <returns>Valid base 64 string</returns>
        public static string GetBase64ValidData(string cadena)
        {
            if (cadena.Contains("jpg;"))
                return cadena.Remove(0, 22);
            if (cadena.Contains("jpeg;"))
                return cadena.Remove(0, 23);
            if (cadena.Contains("png;"))
                return cadena.Remove(0, 22);
            else
                return cadena;
        }
        /// <summary>
        /// Get extension of base64 image
        /// </summary>
        /// <param name="cadena"></param>
        /// <returns>Extension of base64 image</returns>
        public static string GetBase64Extension(string cadena)
        {
            if (cadena.Contains("jpg;"))
                return "jpg";
            if (cadena.Contains("jpeg;"))
                return "jpeg";
            if (cadena.Contains("png;"))
                return "png";
            return string.Empty;
        }
    }
}
