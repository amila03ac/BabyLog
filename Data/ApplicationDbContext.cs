using BabyLog.Models;
using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BabyLog.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        /// <summary>
        /// Current user id which is executing the request that this data context is part of.
        /// </summary>
        private readonly string _userId;

        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions,
            IHttpContextAccessor httpContextAccessor) : base(options, operationalStoreOptions)
        {
            var httpContext = httpContextAccessor.HttpContext;
            if(httpContext != null)
            {
                _userId = httpContext.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            }
        }

        #region Entities

        public DbSet<EventType> EventTypes{ get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Baby> Babies { get; set; }

        #endregion

        public Task<int> SaveChangesAsync()
        {
            ValidateEntities();
            return base.SaveChangesAsync();
        }

        /// <summary>
        /// Validates and automatically sets auditing fields for entities that are being added/modified.
        /// </summary>
        protected virtual void ValidateEntities()
        {
            foreach (var entry in ChangeTracker.Entries<AuditedEntityBase>().Where(e => e.State == EntityState.Added))
            {
                entry.Entity.CreatedByUserId = entry.Entity.LastUpdatedByUserId = _userId;
                entry.Entity.CreatedAtUtc = entry.Entity.LastUpdatedAtUtc = DateTime.UtcNow;
            }

            foreach (var entry in ChangeTracker.Entries<AuditedEntityBase>().Where(e => e.State == EntityState.Modified))
            {
                entry.Entity.LastUpdatedByUserId = _userId;
                entry.Entity.LastUpdatedAtUtc = DateTime.UtcNow;
            }
        }

    }
}
