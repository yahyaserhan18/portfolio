using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Config
{
    internal class OwnerConfig : IEntityTypeConfiguration<Owner>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Owner> builder)
        {
            builder.ToTable("Owners");
            builder.Property(x => x.Id).HasDefaultValueSql("NEWID()");
            builder.HasKey(o => o.Id);

            builder.HasData
            (
                new Owner
                {
                    //Id = Guid.NewGuid(),
                    Id = new Guid("9e44d4be-1c4e-4c3c-a6dc-20e091f6cabc"),
                    FullName = "Yahya Elserhan",
                    Profil = "Software Engineer - Information System Engineer",
                    //Avatar = Guid.NewGuid().ToString() + "_" + "avatar.jpg",
                    Avatar = "afbee271-d03c-4416-bfc7-9c42e6c2cf4c" + "_" + "avatar.jpg"
                }
            );
        }
    }
}
