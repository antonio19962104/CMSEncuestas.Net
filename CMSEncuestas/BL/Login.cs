using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace BL
{
    /// <summary>
    /// Clase del Modulo de seguridad
    /// </summary>
    public static class Login
    {
        /// <summary>
        /// Autentica un usuario administrador
        /// </summary>
        /// <param name="aAdministrador">Modelo con las claves de acceso del administrador</param>
        /// <returns>Token del usuario admnistrador</returns>
        public static string Autenticar(ML.Administrador aAdministrador, string IPAdress)
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
                aAdministrador._token = BL._Encrypt.Encrypt(aAdministrador.cadenaToEncrypt, aAdministrador.Password);
                BL.Nlog.logAccess(BL.MappingConfigurations.MappingAdministrador((DL.Administrador)result.Object), IPAdress);
                return aAdministrador._token;
            }
            catch (Exception aE)
            {
                BL.Nlog.logErrorModuloSeguridad(aE, new StackTrace(true));
                return "error";
            }
        }
        /// <summary>
        /// Crea la porcion de la cadena a encriptar con los datos del administrador
        /// </summary>
        /// <param name="aAdministrador"></param>
        /// <returns>Porcion de cadena a encriptar</returns>
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
        /// <summary>
        /// Crea la porcion de la cadena a encryptar con los datos de espacio de trabajo
        /// </summary>
        /// <param name="aWorkSpace"></param>
        /// <returns>Porcion de cadena a encriptar</returns>
        public static string GetCadenaWorkSpaceToEncrypt(List<ML.WorkSpace> aWorkSpace)
        {
            string cadena = "";
            foreach (var item in aWorkSpace)
                cadena += item.IdWorkSpace + ",";
            return cadena;
        }
    }
}
