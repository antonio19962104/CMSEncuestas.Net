using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Encuesta
    {
        public static MappingConfigurations Convert { get; set; } = new MappingConfigurations();
        public static ML.Result Add(ML.Encuesta encuesta)
        {
            try
            {
                using (DL.CmsEncuestasEntities context = new DL.CmsEncuestasEntities())
                {
                    using (var transaction = context.Database.BeginTransaction(System.Data.IsolationLevel.ReadUncommitted))
                    {
                        try
                        {
                            var DLEncuesta = Convert.ToDLEncuesta(encuesta);
                            var result = context.Encuesta.Add(DLEncuesta);
                            foreach (var pregunta in encuesta.Preguntas)
                            {
                                var DLPreguntas = Convert.ToDLPregunta(pregunta);
                                DLPreguntas.IdEncuesta = DLEncuesta.IdEncuesta;
                                context.Preguntas.Add(DLPreguntas);
                                foreach (var respuesta in pregunta.Respuestas)
                                {
                                    var DLRespuestas = Convert.ToDLRespuesta(respuesta);
                                    context.Respuestas.Add(DLRespuestas);
                                    DLRespuestas.IdPregunta = DLPreguntas.IdPregunta;
                                }
                            }
                            context.SaveChanges();
                            transaction.Commit();
                            encuesta.Correct = true;
                            encuesta.IdEncuesta = DLEncuesta.IdEncuesta;
                        }
                        catch (Exception aE)
                        {
                            BL.Nlog.logErrorModuloEncuesta(aE, new StackTrace());
                            transaction.Rollback();
                            encuesta.Correct = false;
                            encuesta.Exception = aE;
                            encuesta.ExceptionMessage = aE.Message;
                        }
                    }
                }
            }
            catch (Exception aE)
            {
                BL.Nlog.logErrorModuloEncuesta(aE, new StackTrace());
                encuesta.Correct = false;
                encuesta.Exception = aE;
                encuesta.ExceptionMessage = aE.Message;
            }
            return encuesta;
        }
        public static List<ML.Encuesta> GetAll()
        {
            var list = new List<ML.Encuesta>();
            try
            {
                using (DL.CmsEncuestasEntities context = new DL.CmsEncuestasEntities())
                {
                    var data = context.Encuesta.Where(o => o.IdEstatus == 1);
                    foreach (var item in data)
                        list.Add(Convert.ToModelEncuesta(item));
                }
            }
            catch (Exception aE)
            {
                BL.Nlog.logErrorModuloEncuesta(aE, new StackTrace());
                return list;
            }
            return list;
        }
    }
}
