using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Sciaraffia.Models
{
    public class Usser
    {   [Required(ErrorMessage="Campo Requerido")]
        [EmailAddress(ErrorMessage="No es un correo Valido")]
        public string correo{ get; set; }


        [Required(ErrorMessage="Campo Requerido")]
        public string nombre{ get; set; }

        
        [Required(ErrorMessage="Campo Requerido")]
        public string clave{ get; set; }

         [Required(ErrorMessage="Campo Requerido")]
         [Compare("clave",ErrorMessage="No Son Iguales")]
        public string conclave{ get; set; }
    }
}