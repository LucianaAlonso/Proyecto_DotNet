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
        public Especialidad Especialidad { get; set;}
        [Required]
        public Rol RolEnEspecialidad { get; set; }

    }
    
}