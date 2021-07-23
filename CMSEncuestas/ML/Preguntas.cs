using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Preguntas : Result
    {
        public int IdPregunta { get; set; } = 0;
        public string Pregunta { get; set; } = string.Empty;
        public Encuesta Encuesta { get; set; } = new Encuesta();
        public Estatus Estatus { get; set; } = new Estatus();
        public TipoControl TipoControl { get; set; } = new TipoControl();
        public List<ML.Respuestas> Respuestas { get; set; }
    }
}
