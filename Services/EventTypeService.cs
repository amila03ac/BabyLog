using BabyLog.Contracts;
using BabyLog.Data;
using BabyLog.Models;
using BabyLog.Models.Dto;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BabyLog.Services
{
    public class EventTypeService : IEventTypeService
    {
        private readonly ApplicationDbContext _dataContext;

        public EventTypeService(ApplicationDbContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<List<EventTypeDto>> GetAllAsync()
        {
            return await _dataContext.EventTypes.Select(e => ItemToDTO(e)).ToListAsync();
        }

        public async Task<EventTypeDto> GetEventTypeAsync(int id)
        {
            var event_type = await _dataContext.EventTypes.FindAsync(id);

            return event_type == null ? null : ItemToDTO(event_type);
        }

        private static EventTypeDto ItemToDTO(EventType eventType) =>
            new()
            {
                Id = eventType.Id,
                Name = eventType.Name,
                ShortCode = eventType.ShortCode,
                ColorCode = eventType.ColorCode
            };
    }
}
