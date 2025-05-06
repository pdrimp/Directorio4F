using Microsoft.EntityFrameworkCore;

namespace Directorio4F.Data
{
    public class BDDirectorioDBContext : DbContext
    {
        public BDDirectorioDBContext(
                   DbContextOptions<BDDirectorioDBContext> options
                                    ) : base(options)
        {

        }

        public DbSet<Persona> Personas { get; set; }
    }
}
