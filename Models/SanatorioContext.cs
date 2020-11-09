
using Microsoft.EntityFrameworkCore;

namespace Sanatorio.Models {
    
    public class SanatorioContext: DbContext {
        
        public SanatorioContext(DbContextOptions<SanatorioContext> options)
            :base(options){

        }

        public DbSet<Servicio> Servicio { get; set; }
        public DbSet<Medico> Medico  {get; set; }
        public DbSet<ObraSocial> ObraSocial { get; set; }
        public DbSet<Coberturas> Coberturas { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
    }
}
