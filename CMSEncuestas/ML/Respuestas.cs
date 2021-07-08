using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Respuestas : Result
    {
        public int IdRespuesta { get; set; } = 0;
        public string Respuesta { get; set; } = string.Empty;
        public Preguntas Pregunta { get; set; } = new Preguntas();
        public Estatus Estatus { get; set; } = new Estatus();
    }
}
