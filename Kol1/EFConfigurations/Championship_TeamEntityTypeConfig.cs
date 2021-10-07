using PlayerTeamAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlayerTeamAPI.EFConfigurations
{
    public class Championship_TeamEntityTypeConfig : IEntityTypeConfiguration<Championship_Team>
    {
        public void Configure(EntityTypeBuilder<Championship_Team> builder)
        {
            builder.HasKey(e => e.IdChampionshipTeam);

            builder.Property(e => e.Score);

            builder.HasOne(d => d.IdChampionshipNavigation)
                   .WithMany(p => p.Championship_Team)
                   .HasForeignKey(d => d.IdChampionship)
                   .OnDelete(DeleteBehavior.ClientSetNull);

            builder.HasOne(d => d.IdTeamNavigation)
                   .WithMany(p => p.Championship_Team)
                   .HasForeignKey(d => d.IdTeam)
                   .OnDelete(DeleteBehavior.ClientSetNull);

            // seed data
            builder.HasData(
                    new Championship_Team { IdChampionshipTeam = 1, IdTeam = 1, IdChampionship = 2, Score = 1.0f },
                    new Championship_Team { IdChampionshipTeam = 2, IdTeam = 2, IdChampionship = 1, Score = 1.1f },
                    new Championship_Team { IdChampionshipTeam = 3, IdTeam = 3, IdChampionship = 3, Score = 1.2f },
                    new Championship_Team { IdChampionshipTeam = 4, IdTeam = 3, IdChampionship = 3, Score = 2.0f },
                    new Championship_Team { IdChampionshipTeam = 5, IdTeam = 2, IdChampionship = 1, Score = 3.0f }
                );
        }
    }
}
