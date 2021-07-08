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
        public static ML.Result Autenticar(ML.Administrador aAdministrador)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.CmsEncuestasEntities context = new DL.CmsEncuestasEntities())
                {
                    var existe = context.Administrador.Where(o => o.Username == aAdministrador.Username && o.Password == aAdministrador.Password && o.IdEstatus == 1).FirstOrDefault();
                    if (existe == null)
                    {
                        result.Correct = true;
                        result.Object = existe;
                    }
                    else
                    {
                        result.Correct = true;
                        result.Object = BL.MappingConfigurations.MappingAdministrador(existe);
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
