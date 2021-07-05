using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class MappingConfigurations
    {
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
                BL.Nlog.logErrorMappingConfigurations(aE, new StackTrace());
                return new ML.Administrador();
            }
        }
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
                BL.Nlog.logErrorMappingConfigurations(aE, new StackTrace());
                return new ML.WorkSpace();
            }
        }
    }
}
