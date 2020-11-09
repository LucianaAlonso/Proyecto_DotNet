using System.Collections.Generic;

namespace Sanatorio.Models {
    public class ObraSocial {
        public string Nombre { get; set; }

        public List<string> Planes { get; set; }

        public bool Activa { get; set; }
    }
}