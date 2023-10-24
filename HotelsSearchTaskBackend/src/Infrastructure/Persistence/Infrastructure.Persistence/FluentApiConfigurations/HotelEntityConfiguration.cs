using Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.FluentApiConfigurations
{
    public class HotelEntityConfiguration : IEntityTypeConfiguration<Hotel>
    {
        public void Configure(EntityTypeBuilder<Hotel> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Name)
                .HasMaxLength(50);

            builder.OwnsOne(x => x.Address, vo =>
            {
                vo.Property(x => x.Country).HasColumnName("AddressCountry");
                vo.Property(x => x.State).HasColumnName("AddressState");
                vo.Property(x => x.City).HasColumnName("AddressCity");
            });
        }
    }
}
