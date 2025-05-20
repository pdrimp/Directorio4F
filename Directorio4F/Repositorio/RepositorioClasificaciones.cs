using Directorio4F.Data;
using Microsoft.EntityFrameworkCore;

namespace Directorio4F.Repositorio
{
    public class RepositorioClasificaciones : IRepositorioClasificaciones
    {
        private readonly BDDirectorioDBContext _context;
        public RepositorioClasificaciones(BDDirectorioDBContext context)
        {
            _context = context;
        }
        public async Task Add(Clasificacion clasificacion)
        {
            await _context.Clasificaciones.AddAsync(clasificacion);
            await _context.SaveChangesAsync();
        }
        public async Task Delete(int id)
        {
            var clasificacion = await Get(id);
            if (clasificacion.Personas.Count > 0)
            {
                throw new Exception("No se puede eliminar la clasificación porque tiene personas asociadas.");
            }
            _context.Clasificaciones.Remove(clasificacion);
            await _context.SaveChangesAsync();
        }
        public async Task<Clasificacion> Get(int id)
        {
            return await _context.Clasificaciones.Include(p => p.Personas).FirstAsync(r => r.Id == id);
        }
        public async Task<List<Clasificacion>> GetAll()
        {
            return await _context.Clasificaciones.AsNoTracking().ToListAsync();
        }
        public async Task Update(Clasificacion clasificacion)
        {
            _context.Clasificaciones.Update(clasificacion);
            await _context.SaveChangesAsync();
        }
    }
}
