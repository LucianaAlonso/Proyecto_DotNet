using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sanatorio.Models {

    public class Autoridad {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required]
        public string NombreYApellido { get; set; }
        [Required]
        public string RolAutoridad { get; set; }

    }
    
}