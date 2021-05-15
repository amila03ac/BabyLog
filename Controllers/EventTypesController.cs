using BabyLog.Contracts;
using BabyLog.Data;
using BabyLog.Models;
using BabyLog.Models.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BabyLog.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class EventTypesController : ControllerBase
    {
        private readonly IEventTypeService _eventTypeService;

        public EventTypesController(IEventTypeService service)
        {
            _eventTypeService = service;
        }

        // GET: api/EventTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EventTypeDto>>> GetEventTypes()
        {
            return await _eventTypeService.GetAllAsync();
        }

        // GET: api/EventTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EventTypeDto>> GetEventType(int id)
        {
            var eventType = await _eventTypeService.GetEventTypeAsync(id);

            if (eventType == null)
            {
                return NotFound();
            }

            return eventType;
        }
    }
}
