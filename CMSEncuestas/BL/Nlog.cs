using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    /// <summary>
    /// Contiene los métodos de creación de logs por módulos
    /// </summary>
    public class Nlog
    {
        /// <summary>
        /// Instancia de un log para el modulo de Seguridad
        /// </summary>
        public static NLog.Logger nLogModuloSeguridad = NLog.LogManager.GetLogger("LogModuloSeguridad");
        /// <summary>
        /// Instancia de un log para el modulo MappingConfigurations
        /// </summary>
        public static NLog.Logger nLogModuloMappingConfigurations = NLog.LogManager.GetLogger("LogModuloMappingConfigurations");
        /// <summary>
        /// Instancia de un log para el modulo WorkSpace
        /// </summary>
        public static NLog.Logger nLogModuloWorkSpace = NLog.LogManager.GetLogger("LogModuloWorkSpace");
        /// <summary>
        /// Instancia de un log para el modulo SenderEmail
        /// </summary>
        public static NLog.Logger nLogModuloSenderEmail = NLog.LogManager.GetLogger("LogModuloSenderEmail");
        /// <summary>
        /// Instancia de un log para el control de accesos al sitio
        /// </summary>
        public static NLog.Logger nLogAccess = NLog.LogManager.GetLogger("LogAccess");
        /// <summary>
        /// Instancia de un log para la impresion de datos
        /// </summary>
        public static NLog.Logger nlogData = NLog.LogManager.GetLogger("LogData");

        /// <summary>
        /// Escritura de un log para el modulo de Seguridad
        /// </summary>
        /// <param name="aE"></param>
        /// <param name="aSt"></param>
        public static void logErrorModuloSeguridad(Exception aE, StackTrace aSt)
        {
            nLogModuloSeguridad.Error("Method: ", aSt.GetFrame(0).GetMethod().Name);
            nLogModuloSeguridad.Error("Exception: " + aE);
            nLogModuloSeguridad.Error("Inner Exception: " + aE.InnerException);
            nLogModuloSeguridad.Error("StackTrace: ", aE.StackTrace);
        }
        /// <summary>
        /// Escritura de un log para el modulo MappingConfigurations
        /// </summary>
        /// <param name="aE"></param>
        /// <param name="aSt"></param>
        public static void logErrorMappingConfigurations(Exception aE, StackTrace aSt)
        {
            nLogModuloMappingConfigurations.Error("Method: ", aSt.GetFrame(0).GetMethod().Name);
            nLogModuloMappingConfigurations.Error("Exception: " + aE);
            nLogModuloMappingConfigurations.Error("Inner Exception: " + aE.InnerException);
            nLogModuloMappingConfigurations.Error("StackTrace: ", aE.StackTrace);
        }
        /// <summary>
        /// Escritura de un log para el modulo WorkSpace
        /// </summary>
        /// <param name="aE"></param>
        /// <param name="aSt"></param>
        public static void logErrorModuloWorkSpace(Exception aE, StackTrace aSt)
        {
            nLogModuloWorkSpace.Error("Method: ", aSt.GetFrame(0).GetMethod().Name);
            nLogModuloWorkSpace.Error("Exception: " + aE);
            nLogModuloWorkSpace.Error("Inner Exception: " + aE.InnerException);
            nLogModuloWorkSpace.Error("StackTrace: ", aE.StackTrace);
        }
        /// <summary>
        /// Escritura de un log para el modulo SenderEmail
        /// </summary>
        /// <param name="aE"></param>
        /// <param name="aSt"></param>
        public static void logErrorModuloSenderEmail(Exception aE, StackTrace aSt)
        {
            nLogModuloSenderEmail.Error("Method: ", aSt.GetFrame(0).GetMethod().Name);
            nLogModuloSenderEmail.Error("Exception: " + aE);
            nLogModuloSenderEmail.Error("Inner Exception: " + aE.InnerException);
            nLogModuloSenderEmail.Error("StackTrace: ", aE.StackTrace);
        }
        /// <summary>
        /// Escritura de un log para el control de los accesos
        /// </summary>
        /// <param name="aAdministrador"></param>
        /// <param name="IPAdress"></param>
        public static void logAccess(ML.Administrador aAdministrador, string IPAdress)
        {
            nLogAccess.Info("Usuario: " + aAdministrador.Username);
            nLogAccess.Info("Nombre: " + string.Concat(aAdministrador.Nombre, " ", aAdministrador.ApellidoPaterno + " ", aAdministrador.ApellidoMaterno));
            nLogAccess.Info("IPAdress: " + IPAdress);
        }
        /// <summary>
        /// Escritura de un log para imprimir datos
        /// </summary>
        /// <param name="message"></param>
        public static void logData(string message)
        {
            nlogData.Info(message);
        }
    }
}
