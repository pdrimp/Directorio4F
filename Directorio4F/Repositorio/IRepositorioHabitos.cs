using Directorio4F.Data;

namespace Directorio4F.Repositorio
{
    public interface IRepositorioHabitos
    {
        Task<List<Habito>> GetAll();
        Task<Habito> Get(int id);
        Task Add(Habito habito);
        Task Update(Habito habito);
        Task Delete(int id);
    }
}
