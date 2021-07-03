using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Preguntas
    {
        public int IdPregunta { get; set; }
        public string Pregunta { get; set; }
        public ML.Encuesta Encuesta { get; set; }
        public ML.Estatus Estatus { get; set; }
        public ML.TipoControl TipoControl { get; set; }
    }
}
