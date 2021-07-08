using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class BaseDeDatos : Result
    {
        public int IdBaseDeDatos { get; set; } = 0;
        public Estatus Estatus { get; set; } = new Estatus();
        public Administrador Administrador { get; set; } = new Administrador();
    }
}
