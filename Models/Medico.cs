using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sanatorio.Models {

    public class Medico {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        
        public string NombreYApellido { get; set; }

        public string Especialidad { get; set;}

        public string RolEnEspecialidad { get; set; }
    }
    
}