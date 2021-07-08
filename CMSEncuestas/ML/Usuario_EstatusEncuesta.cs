using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Usuario_EstatusEncuesta : Result
    {
        public int IdUsuario_EstatusEncuesta { get; set; } = 0;
        public Usuario Usuario { get; set; } = new Usuario();
        public Encuesta Encuesta { get; set; } = new Encuesta();
        public EstatusEncuesta EstatusEncuesta { get; set; } = new EstatusEncuesta();
    }
}
