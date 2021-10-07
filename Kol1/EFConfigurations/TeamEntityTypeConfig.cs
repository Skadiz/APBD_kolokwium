using PlayerTeamAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlayerTeamAPI.EFConfigurations
{
    public class TeamEntityTypeConfig : IEntityTypeConfiguration<Team>
    {
        public void Configure(EntityTypeBuilder<Team> builder)
        {
            builder.HasKey(e => e.IdTeam);

            builder.Property(e => e.IdTeam).ValueGeneratedNever();

            builder.Property(e => e.TeamName).IsRequired()
                                              .HasMaxLength(100);
            builder.Property(e => e.MaxAge).IsRequired();
           
            // seed data
            builder.HasData(
                    new Team { IdTeam = 1, TeamName = "Dinamo", MaxAge = 23 },
                    new Team { IdTeam = 2, TeamName = "Shahter", MaxAge = 25},
                    new Team { IdTeam = 3, TeamName = "Team3", MaxAge = 30}
                );
        }
    }
}
