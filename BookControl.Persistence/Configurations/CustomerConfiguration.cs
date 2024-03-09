using BookControl.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookControl.Persistence.Configurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(80);
            builder.Property(x => x.LastName)
                .IsRequired()
                .HasMaxLength(80);
            builder.Property(x => x.Dni)
                .IsRequired()
                .HasMaxLength(15);
            
            builder.ToTable(nameof(Customer), schema: "BookControl");
        }
    }
}
