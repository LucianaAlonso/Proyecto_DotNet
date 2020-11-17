using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sanatorio.Models {

    public class Usuario {

        [Key]
        public string Mail { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Apellido { get; set; }
        [Required]
        public string Contraseña { get; set; }

        public ObraSocial ObraSocial { get; set; }
       // public List<Turno> Turnos { get; set; }
    }
}