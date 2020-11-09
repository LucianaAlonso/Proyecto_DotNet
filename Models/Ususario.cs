using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sanatorio.Models {

    public class Usuario {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Mail { get; set; }

        public string Nombre { get; set; }
        public string Apellido { get; set; }
       // public List<Turno> Turnos { get; set; }
    }
}