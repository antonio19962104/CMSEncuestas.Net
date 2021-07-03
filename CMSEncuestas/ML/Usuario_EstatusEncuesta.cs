using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Usuario_EstatusEncuesta
    {
        public int IdUsuario_EstatusEncuesta { get; set; }
        public ML.Usuario Usuario { get; set; }
        public ML.Encuesta Encuesta { get; set; }
        public ML.EstatusEncuesta EstatusEncuesta { get; set; }
    }
}
