using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    /// <summary>
    /// Clase del modulo del administrador
    /// </summary>
    public class Administrador
    {
        /// <summary>
        /// Objeto de la clase MappingConfigurations
        /// </summary>
        public static MappingConfigurations Convert { get; set; } = new MappingConfigurations();
        /// <summary>
        /// Valida la existencia de un usuario administrador
        /// </summary>
        /// <param name="aAdministrador">Modelo con las claves de acceso del administrador</param>
        /// <returns>Objeto administrador</returns>
        public static ML.Administrador Autenticar(ML.Administrador aAdministrador)
        {
            ML.Administrador result = new ML.Administrador();
            try
            {
                using (DL.CmsEncuestasEntities context = new DL.CmsEncuestasEntities())
                {
                    var dlAdmin = context.Administrador.Where(o => o.Username == aAdministrador.Username && o.Password == aAdministrador.Password && o.IdEstatus == 1).FirstOrDefault();
                    if (dlAdmin == null)
                    {
                        result.Correct = true;
                        result.Exists = false;
                    }
                    else
                    {
                        if (ValidaCambioPass(dlAdmin))
                        {
                            result.Exists = true;
                            result.Correct = false;
                            result.ExceptionMessage = ML.Constantes.CambiaPassMessage;
                            return result;
                        }
                        if (ValidaCuentaBloqueada(dlAdmin))
                        {
                            result.Exists = true;
                            result.Correct = false;
                            result.ExceptionMessage = ML.Constantes.CuentaBloqueadaMessage;
                            return result;
                        }
                        result.Correct = true;
                        result.Exists = true;
                        result.Object = Convert.ToModelAdministrador(dlAdmin);
                    }
                }
            }
            catch (Exception aE)
            {
                BL.Nlog.logErrorModuloSeguridad(aE, new StackTrace(true));
                result.Correct = false;
                result.Exception = aE;
                result.ExceptionMessage = aE.Message;
            }
            return result;
        }
        /// <summary>
        /// Valida si el password ha expirado
        /// </summary>
        /// <param name="administrador"></param>
        /// <returns></returns>
        public static bool ValidaCambioPass(DL.Administrador administrador)
        {
            administrador.FechaExpiracionPass = administrador.FechaHoraCreacion.AddDays(28);
            if (administrador.FechaExpiracionPass >= DateTime.Now)
                return true;
            else
                return false;
        }
        /// <summary>
        /// Valida si la cuenta ha sido bloqueada
        /// </summary>
        /// <param name="administrador"></param>
        /// <returns></returns>
        public static bool ValidaCuentaBloqueada(DL.Administrador administrador)
        {
            if (administrador.LogFailed >= 10)
                return true;
            else
                return false;
        }
        public static ML.Result Add(ML.Administrador administrador)
        {
            ML.Result result = new ML.Result();
            try
            {
                //var dlAdministrador = Convert.ToDL
            }
            catch (Exception aE)
            {
                BL.Nlog.logErrorModuloSeguridad(aE, new StackTrace());
                result.Correct = false;
                result.Exception = aE;
                result.ExceptionMessage = aE.Message;
            }
            return result;
        }
    }
}
