using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sanatorio.Models {
    public class ObraSocial {
        
        [Key]
        public string Nombre { get; set; }
        public string PaginaWeb { get; set; }
        
        public List<Plan> Planes { get; set; }
        [Required]
        public bool Activa { get; set; }
    }
}