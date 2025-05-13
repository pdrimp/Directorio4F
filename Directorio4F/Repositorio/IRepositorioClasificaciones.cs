using Directorio4F.Data;

namespace Directorio4F.Repositorio
{
    public interface IRepositorioClasificaciones
    {
        Task<List<Clasificacion>> GetAll();
        Task<Clasificacion> Get(int id);
        Task Add(Clasificacion persona);
        Task Update(Clasificacion persona);
        Task Delete(int id);
    }
}
