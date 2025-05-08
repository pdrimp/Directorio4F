using Directorio4F.Data;

namespace Directorio4F.Repositorio
{
    public interface IRepositorioPersonas
    {
        Task<List<Persona>> GetAll();
        Task<Persona> Get(int id);
        Task Add(Persona persona);
        Task Update(Persona persona);
        Task Delete(int id);
    }
}
