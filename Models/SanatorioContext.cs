
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Sanatorio.Models {
    
    public class SanatorioContext: DbContext {
        
        public SanatorioContext(DbContextOptions<SanatorioContext> options)
            :base(options){

        }

        protected SanatorioContext()
        {
        }

        public DbSet<Medico> Medico  {get; set; }
        public DbSet<ObraSocial> ObraSocial { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Autoridad> Autoridad { get; set; }
    }
}
