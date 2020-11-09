  
using Microsoft.EntityFrameworkCore;

namespace Proyecto_DotNet.Models
{
    public class SanatorioContext : DbContext
    {
        public NotasContext(DbContextOptions<NotasContext> options)
            :base(options)
        {

        }

        public DbSet<Medico> Medico { get; set; }
        public DbSet<Servicio> Servicio { get; set; }
    }
}