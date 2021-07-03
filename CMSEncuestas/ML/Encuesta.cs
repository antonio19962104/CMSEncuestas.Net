using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Encuesta
    {
        public int IdEncuesta { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public string Instrucciones { get; set; }
        public string Agradecimiento { get; set; }
        public ML.Estatus Estatus { get; set; }
        public ML.Administrador Administrador { get; set; }
        public ML.TipoEncuesta TipoEncuesta { get; set; }
    }
}
