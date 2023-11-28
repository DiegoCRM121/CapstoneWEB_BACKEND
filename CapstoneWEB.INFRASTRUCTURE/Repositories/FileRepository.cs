using CapstoneWEB.CORE.DTOs;
using CapstoneWEB.CORE.Interfaces;
using CapstoneWEB.CORE.Entities;
using CapstoneWEB.INFRASTRUCTURE.Data;
using Microsoft.EntityFrameworkCore;

namespace CapstoneWEB.INFRASTRUCTURE.Repositories
{
    public class FileRepository: IFileRepository
    {
        private readonly CapstoneWebBdContext _dbContext;

        public FileRepository(CapstoneWebBdContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<CORE.Entities.File>> GetAll()
        {
            return await _dbContext.File.ToListAsync();
        }

        public async Task<bool> Insert(CORE.Entities.File file)
        {
            await _dbContext.File.AddAsync(file);
            var countRows = await _dbContext.SaveChangesAsync();
            return countRows > 0;
        }
        
    }
}
