using BabyLog.Contracts;
using BabyLog.Models.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BabyLog.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class BabiesController : ControllerBase
    {
        private readonly IBabyService _babyService;

        public BabiesController(IBabyService service)
        {
            _babyService = service;
        }

        // GET: Babies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BabyDto>>> GetBabies()
        {
            return await _babyService.GetAllAsync();
        }

        // GET: Babies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BabyDto>> GetBaby(int id)
        {
            var baby = await _babyService.GetBabyAsync(id);

            if (baby == null)
            {
                return NotFound();
            }

            return baby;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutBaby(int id, BabyDto baby)
        {
            if (id != baby.Id)
            {
                return BadRequest();
            }

            var success = await _babyService.UpdateBabyAsync(baby);

            return success ? Ok() : NotFound();
        }



        [HttpPost]
        public async Task<IActionResult> PutBaby(BabyDto baby)
        {
            var success = await _babyService.AddBabyAsync(baby);

            return success ? Ok() : NotFound();
        }
    }
}
