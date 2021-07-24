using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceLayer.Models
{
    public class AudienciaModel
    {
        [MaxLength(100)]
        [Required]
        public string Name { get; set; }
    }
}
