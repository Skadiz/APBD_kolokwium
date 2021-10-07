using PlayerTeamAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlayerTeamAPI.EFConfigurations
{
    public class ChampionshipEntityTypeConfig : IEntityTypeConfiguration<Championship>
    {
        public void Configure(EntityTypeBuilder<Championship> builder)
        {
            builder.HasKey(e => e.IdChampionship);

            builder.Property(e => e.IdChampionship).ValueGeneratedNever();

            builder.Property(e => e.OfficialName).IsRequired()
                                         .HasMaxLength(200);

            builder.Property(e => e.Year).IsRequired();
            
            // seed data
            builder.HasData(
                    new Championship { IdChampionship = 1, OfficialName = "Name1", Year = 2000},
                    new Championship { IdChampionship = 2, OfficialName = "Name2", Year = 2001},
                    new Championship { IdChampionship = 3, OfficialName = "Name3", Year = 2002},
                    new Championship { IdChampionship = 4, OfficialName = "Name4", Year = 2003},
                    new Championship { IdChampionship = 5, OfficialName = "Name5", Year = 2004}
                ) ;
        }
    }
}
