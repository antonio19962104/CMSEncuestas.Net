using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class WorkSpace : Result
    {
        public int IdWorkSpace { get; set; } = 0;
        public string Nombre { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public Estatus Estatus { get; set; } = new Estatus();
    }
}
