using PlayerTeamAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlayerTeamAPI.EFConfigurations
{
    public class PlayerEntityTypeConfig : IEntityTypeConfiguration<Player>
    {
        public void Configure(EntityTypeBuilder<Player> builder)
        {
            builder.HasKey(e => e.IdPlayer);

            builder.Property(e => e.IdPlayer).ValueGeneratedNever();

            builder.Property(e => e.FirstName).IsRequired()
                                              .HasMaxLength(100);

            builder.Property(e => e.LastName).IsRequired()
                                             .HasMaxLength(150);

            builder.Property(e => e.DateOfBirth).IsRequired()
                                          .HasColumnType("datetime");
            // seed data
            builder.HasData(
                    new Player { IdPlayer = 1, FirstName = "Jan", LastName = "Dobusz", DateOfBirth = DateTime.Now },
                    new Player { IdPlayer = 2, FirstName = "Barby", LastName = "Girl", DateOfBirth = DateTime.Now },
                    new Player { IdPlayer = 3, FirstName = "Diana", LastName = "Kathe", DateOfBirth = DateTime.Now }
                ); 
        }
    }
}
