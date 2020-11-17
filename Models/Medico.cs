using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sanatorio.Models {

    public class Medico {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required]
        public string NombreYApellido { get; set; }
        [Required]
        public string Especialidad { get; set;}
        [Required]
        public string RolEnEspecialidad { get; set; }

        public Boolean EsAutoridad { get ; set; }

        public string RolAutoridad { get; set; }

    }
    
}