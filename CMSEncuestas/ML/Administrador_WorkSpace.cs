using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Administrador_WorkSpace
    {
        public int IdAdministrador_WorkSpace { get; set; }
        public ML.Administrador Administrador { get; set; }
        public ML.WorkSpace WorkSpace { get; set; }
        public ML.Estatus Estatus { get; set; }
    }
}
