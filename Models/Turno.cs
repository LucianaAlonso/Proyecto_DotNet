using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sanatorio.Models {

    public class Turno {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required]
        public string Paciente { get; set; }   
        [Required]
        public string Medico { get; set; }
        [Required]
        public string FechaYHora { get; set; }
        [Required]
        public string Estado { get; set; }
    }
}