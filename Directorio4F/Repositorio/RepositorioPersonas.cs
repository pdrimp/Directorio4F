using Directorio4F.Data;
using Microsoft.EntityFrameworkCore;

namespace Directorio4F.Repositorio
{
    public class RepositorioPersonas : IRepositorioPersonas
    {
        private readonly BDDirectorioDBContext _context;
        public RepositorioPersonas(BDDirectorioDBContext context)
        {
            _context = context;
        }
        public async Task<List<Persona>> GetAll()
        {
            return await _context.Personas.Include(c=>c.Clasificacion).AsNoTracking().ToListAsync();
        }
        public async Task<Persona> Get(int id)
        {
            return await _context.Personas.FindAsync(id);
        }
        public async Task Add(Persona persona)
        {
            _context.Personas.Add(persona);
            await _context.SaveChangesAsync();
        }
        public async Task Update(Persona persona)
        {
            _context.Personas.Update(persona);
            await _context.SaveChangesAsync();
        }
        public async Task Delete(int id)
        {
            var persona = await Get(id);
            _context.Personas.Remove(persona);
            await _context.SaveChangesAsync();
        }
    }
}
