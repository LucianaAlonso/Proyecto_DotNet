using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sanatorio.Models {
    public class ObraSocial {
        
        [Key]
        public string Nombre { get; set; }

        //public List<string> Planes { get; set; }

        public bool Activa { get; set; }
    }
}