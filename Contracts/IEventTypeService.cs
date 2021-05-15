using BabyLog.Models.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BabyLog.Contracts
{
    public interface IEventTypeService
    {
        public Task<List<EventTypeDto>> GetAllAsync();
        public Task<EventTypeDto> GetEventTypeAsync(int Id);
    }
}
