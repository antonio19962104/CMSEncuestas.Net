using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Administrador
    {
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
                        result.Object = BL.MappingConfigurations.MappingAdministrador(dlAdmin);
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
