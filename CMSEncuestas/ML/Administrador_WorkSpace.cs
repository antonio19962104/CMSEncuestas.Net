using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Administrador_WorkSpace : Result
    {
        public int IdAdministrador_WorkSpace { get; set; } = 0;
        public Administrador Administrador { get; set; } = new Administrador();
        public WorkSpace WorkSpace { get; set; } = new WorkSpace();
        public Estatus Estatus { get; set; } = new Estatus();
    }
}
