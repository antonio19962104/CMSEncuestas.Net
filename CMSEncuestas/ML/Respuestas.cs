using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Respuestas
    {
        public int IdRespuesta { get; set; }
        public string Respuesta { get; set; }
        public ML.Preguntas Pregunta { get; set; }
        public ML.Estatus Estatus { get; set; }
    }
}
