using CapstoneWEB.CORE.DTOs;
using CapstoneWEB.CORE.Entities;

namespace CapstoneWEB.CORE.Interfaces
{
    public interface IFileRepository
    {
        Task<IEnumerable<Entities.File>> GetAll();
        Task<bool> Insert(Entities.File file);
    }
}
