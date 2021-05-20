using BabyLog.Models.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BabyLog.Contracts
{
    public interface IBabyService
    {
        public Task<List<BabyDto>> GetAllAsync();
        public Task<BabyDto> GetBabyAsync(int Id);
        public Task<bool> AddBabyAsync(BabyDto baby);
        public Task<bool> UpdateBabyAsync(BabyDto baby);
    }
}
