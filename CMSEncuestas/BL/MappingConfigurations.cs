using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    /// <summary>
    /// Clase del modulo Mapping Configurations
    /// </summary>
    public class MappingConfigurations
    {
        /// <summary>
        /// Mapea un objeto DL Administrador a un Objeto ML Administrador
        /// </summary>
        /// <param name="dlAdministrador">Objeto DL Administrador</param>
        /// <returns>Objeto ML Administrador</returns>
        public ML.Administrador ToModelAdministrador(DL.Administrador dlAdministrador)
        {
            try
            {
                ML.Administrador administrador = new ML.Administrador()
                {
                    IdAdministrador = dlAdministrador.IdAdministrador,
                    Nombre = dlAdministrador.Nombre,
                    ApellidoPaterno = dlAdministrador.ApellidoPaterno,
                    ApellidoMaterno = dlAdministrador.ApellidoMaterno,
                    Username = dlAdministrador.Username,
                    Password = dlAdministrador.Password,
                };
                return administrador;
            }
            catch (Exception aE)
            {
                BL.Nlog.logErrorMappingConfigurations(aE, new StackTrace(true));
                return new ML.Administrador();
            }
        }
        /// <summary>
        /// Mapea un objeto DL WorkSpace a un Objeto ML WorkSpace
        /// </summary>
        /// <param name="dlWorkSpace">Objeto DL Administrador</param>
        /// <returns>Objeto ML WorkSpace</returns>
        public ML.WorkSpace ToModelWorkSpace(DL.WorkSpace dlWorkSpace)
        {
            try
            {
                ML.WorkSpace workSpace = new ML.WorkSpace()
                {
                    IdWorkSpace = dlWorkSpace.IdWorkSpace,
                    Nombre = dlWorkSpace.Nombre,
                    Descripcion = dlWorkSpace.Descripcion
                };
                return workSpace;
            }
            catch (Exception aE)
            {
                BL.Nlog.logErrorMappingConfigurations(aE, new StackTrace(true));
                return new ML.WorkSpace();
            }
        }
        public ML.Encuesta ToModelEncuesta(DL.Encuesta dlEncuesta)
        {
            try
            {
                ML.Encuesta encuesta1 = new ML.Encuesta()
                {
                    IdEncuesta = dlEncuesta.IdEncuesta,
                    Nombre = dlEncuesta.Nombre,
                    FechaInicio = (DateTime)dlEncuesta.FechaInicio,
                    FechaFin = (DateTime)dlEncuesta.FechaFin,
                    Agradecimiento = dlEncuesta.Agradecimiento,
                    Instrucciones = dlEncuesta.Instrucciones,
                };
                encuesta1.Administrador.IdAdministrador = (int)dlEncuesta.IdAdministrador;
                encuesta1.Estatus.IdEstatus = (int)dlEncuesta.IdEstatus;
                encuesta1.TipoEncuesta.IdTipoEncuesta = (int)dlEncuesta.IdTipoEncuesta;
                return encuesta1;
            }
            catch (Exception aE)
            {
                BL.Nlog.logErrorModuloEncuesta(aE, new StackTrace());
                return new ML.Encuesta();
            }
        }
        /// <summary>
        /// Mapea un objeto ML Encuesta a un Objeto DL Encuesta
        /// </summary>
        /// <param name="encuesta"></param>
        /// <returns></returns>
        public DL.Encuesta ToDLEncuesta(ML.Encuesta encuesta)
        {
            try
            {
                DL.Encuesta encuesta1 = new DL.Encuesta()
                {
                    Nombre = encuesta.Nombre,
                    FechaInicio = encuesta.FechaInicio,
                    FechaFin = encuesta.FechaFin,
                    Agradecimiento = encuesta.Agradecimiento,
                    IdAdministrador = encuesta.Administrador.IdAdministrador,
                    IdEstatus = encuesta.Estatus.IdEstatus,
                    IdTipoEncuesta = encuesta.TipoEncuesta.IdTipoEncuesta,
                    Instrucciones = encuesta.Instrucciones,
                };
                return encuesta1;
            }
            catch (Exception aE)
            {
                BL.Nlog.logErrorMappingConfigurations(aE, new StackTrace());
                return new DL.Encuesta();
            }
        }
        public DL.Preguntas ToDLPregunta(ML.Preguntas preguntas)
        {
            try
            {
                DL.Preguntas preguntas1 = new DL.Preguntas()
                {
                    Pregunta = preguntas.Pregunta,
                    IdTipoControl = preguntas.TipoControl.IdTipoControl,
                    IdEstatus = preguntas.Estatus.IdEstatus,
                };
                return preguntas1;
            }
            catch (Exception aE)
            {
                BL.Nlog.logErrorMappingConfigurations(aE, new StackTrace());
                return new DL.Preguntas();
            }
        }
        public DL.Respuestas ToDLRespuesta(ML.Respuestas respuestas)
        {
            try
            {
                DL.Respuestas respuestas1 = new DL.Respuestas()
                {
                    Respuesta = respuestas.Respuesta,
                    IdEstatus = respuestas.Estatus.IdEstatus,
                };
                return respuestas1;
            }
            catch (Exception aE)
            {
                BL.Nlog.logErrorMappingConfigurations(aE, new StackTrace());
                return new DL.Respuestas();
            }
        }
    }
}
