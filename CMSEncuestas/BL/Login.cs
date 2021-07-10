using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace PLC.Modulos.Login
{
    public static class Login
    {
        public static string Autenticar(ML.Administrador aAdministrador)
        {
            try
            {
                var result = BL.Administrador.Autenticar(aAdministrador);
                if (!result.Correct)
                    return result.ExceptionMessage;
                if (result.Object == null)
                    return "404";
                var workSpaces = BL.WorkSpace.GetWorkSpaceByIdAdmin((ML.Administrador)result.Object);
                aAdministrador.cadenaToEncrypt = GetCadenaAdminToEncrypt(result.Object) + "|" + GetCadenaWorkSpaceToEncrypt(workSpaces);
                aAdministrador._token = Encrypt._Encrypt.Encrypt(aAdministrador.cadenaToEncrypt, aAdministrador.Password);
                BL.Nlog.logAccess(BL.MappingConfigurations.MappingAdministrador((DL.Administrador)result.Object));
                return aAdministrador._token;
            }
            catch (Exception aE)
            {
                BL.Nlog.logErrorModuloSeguridad(aE, new StackTrace(true));
                return "error";
            }
        }
        public static string GetCadenaAdminToEncrypt(object aAdministrador)
        {
            var admin = (ML.Administrador)aAdministrador;
            return admin.IdAdministrador + "|" + 
                    admin.Nombre + " " +
                        admin.ApellidoPaterno + " " +
                            admin.ApellidoMaterno + "|" + 
                                admin.Username + "|" + 
                                    admin.Password;
        }
        public static string GetCadenaWorkSpaceToEncrypt(List<ML.WorkSpace> aWorkSpace)
        {
            string cadena = "";
            foreach (var item in aWorkSpace)
                cadena += item.IdWorkSpace + ",";
            return cadena;
        }
    }
}
