using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    /// <summary>
    /// Clase Administrador
    /// </summary>
    public class Administrador : Result
    {
        /// <summary>
        /// IdAdministrador
        /// </summary>
        public int IdAdministrador { get; set; } = 0;
        /// <summary>
        /// Nombre
        /// </summary>
        public string Nombre { get; set; } = string.Empty;
        /// <summary>
        /// ApellidoPaterno
        /// </summary>
        public string ApellidoPaterno { get; set; } = string.Empty;
        /// <summary>
        /// ApellidoMaterno
        /// </summary>
        public string ApellidoMaterno { get; set; } = string.Empty;
        /// <summary>
        /// Email
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// Username
        /// </summary>
        public string Username { get; set; } = string.Empty;
        /// <summary>
        /// Password
        /// </summary>
        public string Password { get; set; } = string.Empty;
        /// <summary>
        /// Estatus
        /// </summary>
        public Estatus Estatus { get; set; } = new Estatus();
        /// <summary>
        /// cadenaToEncrypt
        /// </summary>
        public string cadenaToEncrypt { get; set; } = string.Empty;
        /// <summary>
        /// _token
        /// </summary>
        public string _token { get; set; } = string.Empty;
        /// <summary>
        /// LogNums
        /// </summary>
        public int LogNums { get; set; } = 0;
        /// <summary>
        /// LogFailed
        /// </summary>
        public int LogFailed { get; set; } = 0;
        /// <summary>
        /// FechaExpiracionPass
        /// </summary>
        public DateTime FechaExpiracionPass { get; set; } = DateTime.MinValue;
    }
}
