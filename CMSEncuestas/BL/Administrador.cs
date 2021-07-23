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
    }
}
