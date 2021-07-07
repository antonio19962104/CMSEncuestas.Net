using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Nlog
    {
        public static NLog.Logger nLogModuloSeguridad = NLog.LogManager.GetLogger("LogModuloSeguridad");
        public static NLog.Logger nLogModuloMappingConfigurations = NLog.LogManager.GetLogger("LogModuloMappingConfigurations");
        public static NLog.Logger nLogModuloWorkSpace = NLog.LogManager.GetLogger("LogModuloWorkSpace");
        public static NLog.Logger nLogAccess = NLog.LogManager.GetLogger("LogAccess");

        public static void logErrorModuloSeguridad(Exception aE, StackTrace aSt)
        {
            nLogModuloSeguridad.Error("Method: ", aSt.GetFrame(0).GetMethod().Name);
            nLogModuloSeguridad.Error("Exception: " + aE);
            nLogModuloSeguridad.Error("Inner Exception: " + aE.InnerException);
            nLogModuloSeguridad.Error("StackTrace: ", aE.StackTrace);
        }
        public static void logErrorMappingConfigurations(Exception aE, StackTrace aSt)
        {
            nLogModuloMappingConfigurations.Error("Method: ", aSt.GetFrame(0).GetMethod().Name);
            nLogModuloMappingConfigurations.Error("Exception: " + aE);
            nLogModuloMappingConfigurations.Error("Inner Exception: " + aE.InnerException);
            nLogModuloMappingConfigurations.Error("StackTrace: ", aE.StackTrace);
        }
        public static void logErrorModuloWorkSpace(Exception aE, StackTrace aSt)
        {
            nLogModuloWorkSpace.Error("Method: ", aSt.GetFrame(0).GetMethod().Name);
            nLogModuloWorkSpace.Error("Exception: " + aE);
            nLogModuloWorkSpace.Error("Inner Exception: " + aE.InnerException);
            nLogModuloWorkSpace.Error("StackTrace: ", aE.StackTrace);
        }
        public static void logAccess(ML.Administrador aAdministrador)
        {
            nLogAccess.Info("Usuario: " + aAdministrador.Username);
            nLogAccess.Info("Nombre: " + string.Concat(aAdministrador.Nombre, " ", aAdministrador.ApellidoPaterno + " ", aAdministrador.ApellidoMaterno));
            nLogAccess.Info("Token: " + aAdministrador._token);
        }
    }
}
