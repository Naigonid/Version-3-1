using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Sciaraffia.Models
{
    public class RegistroH
    {
        [Required]
        public string fecha { get; set; }
        [Required]
        public string hora { get; set; }
       /*  public string valor { get; set; } */
        public string nombre { get; set; }

    }
}