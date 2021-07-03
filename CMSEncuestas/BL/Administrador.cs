using System;
using System.Collections.Generic;
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
                    var existe = context.Administrador.Where(o => o.Username == aAdministrador.Username && o.Password == aAdministrador.Password).FirstOrDefault();
                    if (existe == null)
                    {
                        result.Correct = true;
                        result.Object = "not found";
                    }
                    else
                    {
                        result.Correct = true;
                        result.Object = existe;
                    }
                }
            }
            catch (Exception aE)
            {
                result.Correct = false;
                result.ExMessage = aE.Message;
            }
            return result;
        }
    }
}
