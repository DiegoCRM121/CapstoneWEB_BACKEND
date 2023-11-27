using CapstoneWEB.CORE.DTOs;
using CapstoneWEB.CORE.Entities;

namespace CapstoneWEB.CORE.Interfaces
{
    public interface IEmotionDetailRepository
    {
        Task<bool> Insert(IEnumerable<EmotionDetail> emotionDetails);
    }
}
