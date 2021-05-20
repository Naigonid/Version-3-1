using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sciaraffia.Entidades
{
    
        public class HorarioCita {
        [Key]
        public int serial{ get; set; }

        public string usuario{ get; set; }
        public string fecha{ get; set; }
        public string hora{ get; set; }

       /*  public virtual Usuario Usuario { get; set; } */
    }
    
    
}