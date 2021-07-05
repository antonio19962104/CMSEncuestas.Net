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
        public static NLog.Logger nLogModuloSeguridad = NLog.LogManager.GetLogger("ModuloSeguridad");
        public static NLog.Logger nLogModuloMappingConfigurations = NLog.LogManager.GetLogger("ModuloMappingConfigurations");
        public static NLog.Logger nLogModuloWorkSpace = NLog.LogManager.GetLogger("ModuloWorkSpace");

        public static void logErrorModuloSeguridad(Exception aE, StackTrace st)
        {
            nLogModuloSeguridad.Error("Method: ", st.GetFrame(0).GetMethod().Name);
            nLogModuloSeguridad.Error("Exception: " + aE);
            nLogModuloSeguridad.Error("Inner Exception" + aE.InnerException);
            nLogModuloSeguridad.Error("StackTrace", aE.StackTrace);
        }
        public static void logErrorMappingConfigurations(Exception aE, StackTrace st)
        {
            nLogModuloMappingConfigurations.Error("Method: ", st.GetFrame(0).GetMethod().Name);
            nLogModuloMappingConfigurations.Error("Exception: " + aE);
            nLogModuloMappingConfigurations.Error("Inner Exception" + aE.InnerException);
            nLogModuloMappingConfigurations.Error("StackTrace", aE.StackTrace);
        }
        public static void logErrorModuloWorkSpace(Exception aE, StackTrace st)
        {
            nLogModuloWorkSpace.Error("Method: ", st.GetFrame(0).GetMethod().Name);
            nLogModuloWorkSpace.Error("Exception: " + aE);
            nLogModuloWorkSpace.Error("Inner Exception" + aE.InnerException);
            nLogModuloWorkSpace.Error("StackTrace", aE.StackTrace);
        }
    }
}
