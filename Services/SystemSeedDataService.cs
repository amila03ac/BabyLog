using BabyLog.Contracts;
using BabyLog.Data;
using BabyLog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BabyLog.Services
{
    public class SystemSeedDataService : ISystemSeedDataService
    {
        private readonly ApplicationDbContext dataContext;

        public SystemSeedDataService(ApplicationDbContext dbContext)
        {
            dataContext = dbContext;
        }

        public async Task SeedData()
        {
            // Seed EventTypes
            CreateEventTypes();
            await dataContext.SaveChangesAsync();
        }

        private void CreateEventTypes()
        {
            if (!dataContext.EventTypes.Any())
            {
                var eventTypes = new List<EventType>()
                {
                    new EventType
                    {
                        Name = "Sleep",
                        ColorCode = "387cb0",
                        ShortCode = "SLP"
                    },
                    new EventType
                    {
                        Name = "Wake Up",
                        ColorCode = "ba3475",
                        ShortCode = "WKUP"
                    },
                    new EventType
                    {
                        Name = "Pee",
                        ColorCode = "f5f0ab",
                        ShortCode = "PEE"
                    },
                    new EventType
                    {
                        Name = "Poop",
                        ColorCode = "bdb32a",
                        ShortCode = "POOP"
                    },
                    new EventType
                    {
                        Name = "Feeding Start",
                        ColorCode = "52a0d1",
                        ShortCode = "FDS"
                    },
                    new EventType
                    {
                        Name = "Feeding End",
                        ColorCode = "252e8f",
                        ShortCode = "FDE"
                    },
                    new EventType
                    {
                        Name = "Bath",
                        ColorCode = "35b097",
                        ShortCode = "BTH"
                    },
                    new EventType
                    {
                        Name = "Wash",
                        ColorCode = "297bab",
                        ShortCode = "WSH"
                    },
                    new EventType
                    {
                        Name = "Vomit",
                        ColorCode = "80411d",
                        ShortCode = "VMT"
                    }
                };

                dataContext.AddRange(eventTypes);
            }
        }
    }
}
