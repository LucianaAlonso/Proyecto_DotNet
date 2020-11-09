  
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proyecto_DotNet.Models
{
    public class Medico {

        public string Nombre  { get; set; }
        
        public string Apellido { get; set }

        public string Especialidad { get; set}

        public string Rol { get; set}
    }
}