using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sciaraffia.Entidades
{
    
        public class Usuario {
        [Key]
        public string correo{ get; set; }
        public string nombre{ get; set; }
        public string clave{ get; set; }
        
       /*  public virtual List<HorarioCita> HorarioG{get; set;}    */

    }
    
    
}