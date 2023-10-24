using Core.Domain.Common;
using Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Contexts
{
    public class HotelsManagementContext : DbContext
    {
        public DbSet<Hotel> Hotels { get; set; }

        public HotelsManagementContext(DbContextOptions<HotelsManagementContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);

            base.OnModelCreating(builder);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var item in ChangeTracker.Entries<AuditableEntity>())
            {
                if (item.State == EntityState.Added)
                    item.Entity.CreateDate = DateTime.Now;
                else if (item.State == EntityState.Modified)
                    item.Entity.ModifyDate = DateTime.Now;
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
