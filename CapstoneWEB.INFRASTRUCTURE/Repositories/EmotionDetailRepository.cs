using CapstoneWEB.CORE.DTOs;
using CapstoneWEB.CORE.Interfaces;
using CapstoneWEB.CORE.Entities;
using CapstoneWEB.INFRASTRUCTURE.Data;
using Microsoft.EntityFrameworkCore;

namespace CapstoneWEB.INFRASTRUCTURE.Repositories
{
    public class EmotionDetailRepository: IEmotionDetailRepository
    {
        private readonly CapstoneDbContext _dbContext;

        public EmotionDetailRepository(CapstoneDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> Insert(IEnumerable<EmotionDetail> emotionDetails)
        {
            await _dbContext.EmotionDetail.AddRangeAsync(emotionDetails);

            var file = await _dbContext.File.Where(x => x.IdFile == emotionDetails.FirstOrDefault().IdFile).FirstOrDefaultAsync();

            _dbContext.File.Update(file);

            int rows = await _dbContext.SaveChangesAsync();
            return rows > 0;
        }
    }
}
