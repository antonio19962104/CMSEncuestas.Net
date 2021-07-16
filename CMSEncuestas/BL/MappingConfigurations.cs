using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    /// <summary>
    /// Clase del modulo Mapping Configurations
    /// </summary>
    public class MappingConfigurations
    {
        /// <summary>
        /// Mapea un objeto DL Administrador a un Objeto ML Administrador
        /// </summary>
        /// <param name="dlAdministrador">Objeto DL Administrador</param>
        /// <returns>Objeto ML Administrador</returns>
        public static ML.Administrador MappingAdministrador(DL.Administrador dlAdministrador)
        {
            try
            {
                ML.Administrador administrador = new ML.Administrador()
                {
                    IdAdministrador = dlAdministrador.IdAdministrador,
                    Nombre = dlAdministrador.Nombre,
                    ApellidoPaterno = dlAdministrador.ApellidoPaterno,
                    ApellidoMaterno = dlAdministrador.ApellidoMaterno,
                    Username = dlAdministrador.Username,
                    Password = dlAdministrador.Password,
                };
                return administrador;
            }
            catch (Exception aE)
            {
                BL.Nlog.logErrorMappingConfigurations(aE, new StackTrace(true));
                return new ML.Administrador();
            }
        }
        /// <summary>
        /// Mapea un objeto DL WorkSpace a un Objeto ML WorkSpace
        /// </summary>
        /// <param name="dlWorkSpace">Objeto DL Administrador</param>
        /// <returns>Objeto ML WorkSpace</returns>
        public static ML.WorkSpace MappingWorkSpace(DL.WorkSpace dlWorkSpace)
        {
            try
            {
                ML.WorkSpace workSpace = new ML.WorkSpace()
                {
                    IdWorkSpace = dlWorkSpace.IdWorkSpace,
                    Nombre = dlWorkSpace.Nombre,
                    Descripcion = dlWorkSpace.Descripcion
                };
                return workSpace;
            }
            catch (Exception aE)
            {
                BL.Nlog.logErrorMappingConfigurations(aE, new StackTrace(true));
                return new ML.WorkSpace();
            }
        }
    }
}
