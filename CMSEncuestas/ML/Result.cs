using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    /// <summary>
    /// Modelo en el que envía el resultado de cada petición
    /// </summary>
    public class Result : Bitacora
    {
        /// <summary>
        /// Estatus de un metodo
        /// </summary>
        public bool Correct { get; set; } = false;
        public Exception Exception { get; set; } = new Exception() { Source = "default" };
        public string ExceptionMessage { get; set; } = string.Empty;
        public object Object { get; set; } = new object();
        public List<object> Objects { get; set; } = new List<object>();
        public bool Exists { get; set; } = false;
        public enum saveStatus
        {
            error = 0,
            success = 1
        }
    }
}
