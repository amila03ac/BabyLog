using BabyLog.Contracts;
using BabyLog.Data;
using BabyLog.Models;
using BabyLog.Models.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BabyLog.Services
{
    public class BabyService : IBabyService
    {
        private readonly ApplicationDbContext _dataContext;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public BabyService(ApplicationDbContext dataContext, IHttpContextAccessor httpContextAccessor)
        {
            _dataContext = dataContext;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<bool> AddBabyAsync(BabyDto babyDto)
        {
            var _userId = _httpContextAccessor.HttpContext.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            var baby = new Baby
            {
                FirstName = babyDto.FirstName,
                LastName = babyDto.LastName,
                Birthday = babyDto.Birthday,
                ApplicationUserId = _userId
            };

            _dataContext.Babies.Add(baby);
            var result = await _dataContext.SaveChangesAsync();
            return result > 0;
        }

        public async Task<List<BabyDto>> GetAllAsync()
        {
            return await _dataContext.Babies.Select(b => ItemToDTO(b)).ToListAsync();
        }

        public async Task<BabyDto> GetBabyAsync(int id)
        {
            var baby = await _dataContext.Babies.FindAsync(id);

            return baby == null ? null : ItemToDTO(baby);
        }

        public async Task<bool> UpdateBabyAsync(BabyDto baby)
        {
            throw new NotImplementedException();
        }

        private static BabyDto ItemToDTO(Baby baby) =>
            new()
            {
                Id = baby.Id,
                FirstName = baby.FirstName,
                LastName = baby.LastName,
                Birthday = baby.Birthday,
                ApplicationUserId = baby.ApplicationUserId
            };
    }
}
