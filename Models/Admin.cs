using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sanatorio.Models {

    public class Admin {

        [Key]
        public string Usuario { get; set; }
        [Required]
        public string Contraseña { get; set; }
    }
}