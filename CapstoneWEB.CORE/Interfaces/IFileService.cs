using CapstoneWEB.CORE.DTOs;

namespace CapstoneWEB.CORE.Interfaces
{
    public interface IFileService
    {
        Task<IEnumerable<FileDTO>> GetAll();
        Task<bool> Insert(FileInsertDTO fileInsert);
    }
}
