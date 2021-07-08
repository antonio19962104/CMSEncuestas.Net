using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class UsuarioRespuestas : Result
    {
        public int IdusuarioRespuestas { get; set; } = 0;
        public Encuesta Encuesta { get; set; } = new Encuesta();
        public Usuario Usuario { get; set; } = new Usuario();
        public Preguntas Preguntas { get; set; } = new Preguntas();
        public Respuestas Respuestas { get; set; } = new Respuestas();
    }
}
