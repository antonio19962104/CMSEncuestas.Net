﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class TipoEncuesta : Result
    {
        public int IdTipoEncuesta { get; set; } = 0;
        public string Nombre { get; set; } = string.Empty;
    }
}
