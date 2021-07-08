using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Usuario : Result
    {
        public int IdUsuario { get; set; } = 0;
        public string Nombre { get; set; } = string.Empty;
        public string ApellidoPaterno { get; set; } = string.Empty;
        public string ApellidoMaterno { get; set; } = string.Empty;
        public DateTime FechaNacimiento { get; set; } = DateTime.MinValue;
        public DateTime FechaIngreso { get; set; } = DateTime.MinValue;
        public string Sexo { get; set; } = string.Empty;
        public Estatus Estatus { get; set; } = new Estatus();
    }
}
