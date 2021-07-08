using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Administrador : Result
    {
        public int IdAdministrador { get; set; } = 0;
        public string Nombre { get; set; } = string.Empty;
        public string ApellidoPaterno { get; set; } = string.Empty;
        public string ApellidoMaterno { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public Estatus Estatus { get; set; } = new Estatus();
        public string cadenaToEncrypt { get; set; } = string.Empty;
        public string _token { get; set; } = string.Empty;
    }
}
