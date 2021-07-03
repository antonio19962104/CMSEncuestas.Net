using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Administrador
    {
        public int IdAdministrador { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public ML.Estatus Estatus { get; set; }
        public string cadenaToEncrypt { get; set; }
        public string _token { get; set; }
    }
}
