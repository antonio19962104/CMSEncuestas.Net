using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Encuesta : Result
    {
        public int IdEncuesta { get; set; } = 0;
        public string Nombre { get; set; } = string.Empty;
        public DateTime FechaInicio { get; set; } = DateTime.MinValue;
        public DateTime FechaFin { get; set; } = DateTime.MinValue;
        public string Instrucciones { get; set; } = string.Empty;
        public string Agradecimiento { get; set; } = string.Empty;
        public Estatus Estatus { get; set; } = new Estatus();
        public Administrador Administrador { get; set; } = new Administrador();
        public TipoEncuesta TipoEncuesta { get; set; } = new TipoEncuesta();
        public List<ML.Preguntas> Preguntas { get; set; } = new List<Preguntas>();
    }
}
