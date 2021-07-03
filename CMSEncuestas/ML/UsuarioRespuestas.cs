using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class UsuarioRespuestas
    {
        public int IdusuarioRespuestas { get; set; }
        public ML.Encuesta Encuesta { get; set; }
        public ML.Usuario Usuario { get; set; }
        public ML.Preguntas Preguntas { get; set; }
        public ML.Respuestas Respuestas { get; set; }
    }
}
