using Directorio4F.Data;
using Microsoft.EntityFrameworkCore;

namespace Directorio4F.Repositorio
{
    public class RepositorioHabitos : IRepositorioHabitos
    {
        private readonly BDDirectorioDBContext _context;
        public RepositorioHabitos(BDDirectorioDBContext context)
        {
            _context = context;
        }
        public async Task Add(Habito habito)
        {
            await _context.Habitos.AddAsync(habito);
            await _context.SaveChangesAsync();
        }
        public async Task Delete(int id)
        {
            var habito = await Get(id);
            if (habito.Personas?.Count > 0)
            {
                throw new Exception("No se puede eliminar la clasificación porque tiene personas asociadas.");
            }
            _context.Habitos.Remove(habito);
            await _context.SaveChangesAsync();
        }
        public async Task<Habito> Get(int id)
        {
            return await _context.Habitos.Include(p => p.Personas).FirstAsync(r => r.Id == id);
        }
        public async Task<List<Habito>> GetAll()
        {
            return await _context.Habitos.AsNoTracking().ToListAsync();
        }
        public async Task Update(Habito habito)
        {
            _context.Habitos.Update(habito);
            await _context.SaveChangesAsync();
        }
    }
}
