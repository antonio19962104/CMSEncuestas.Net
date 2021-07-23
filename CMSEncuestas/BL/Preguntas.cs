using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Preguntas
    {
        public static MappingConfigurations Convert = new MappingConfigurations();
        public static ML.Preguntas Add(ML.Preguntas pregunta, DL.CmsEncuestasEntities context)
        {
            try
            {
                var DLPregunta = Convert.ToDLPregunta(pregunta);
                context.Preguntas.Add(DLPregunta);
                pregunta.IdPregunta = DLPregunta.IdPregunta;
            }
            catch (Exception aE)
            {
                BL.Nlog.logErrorModuloPreguntas(aE, new StackTrace());
            }
            return pregunta;
        }
    }
}
