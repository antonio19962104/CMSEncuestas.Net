using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class BaseDeDatos
    {
        public int IdBaseDeDatos { get; set; }
        public ML.Estatus Estatus { get; set; }
        public ML.Administrador Administrador { get; set; }
    }
}
