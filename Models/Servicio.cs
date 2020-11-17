
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sanatorio.Models {
    
    public class Servicio {

        [Key]
        public string Nombre { get; set; }
        //[Required]
        //public List<string> Prestaciones { get; set; }
    }
}