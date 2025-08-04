using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Config
{
    internal class PortfolioItemConfig : IEntityTypeConfiguration<PortfolioItem>
    {
        public void Configure(EntityTypeBuilder<PortfolioItem> builder)
        {
            builder.ToTable("PortfolioItems");
            builder.Property(pi => pi.Id)
                .HasDefaultValueSql("NEWID()"); // Assuming you want to use NEWID() for default value
            builder.HasKey(pi => pi.Id);
        }
    }
}
