using PlayerTeamAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlayerTeamAPI.EFConfigurations
{
    public class Player_TeamEntityTypeConfig : IEntityTypeConfiguration<Player_Team>
    {
        public void Configure(EntityTypeBuilder<Player_Team> builder)
        {
            builder.HasKey(e => e.IdPlayerTeam);

            builder.Property(e => e.IdPlayerTeam).ValueGeneratedNever();

            builder.Property(e => e.NumOnShirt).IsRequired();

            builder.Property(e => e.Comment).IsRequired().HasMaxLength(100); ;

            builder.HasOne(d => d.IdPlayerNavigation)
                   .WithMany(p => p.Player_Team)
                   .HasForeignKey(d => d.IdPlayer)
                   .OnDelete(DeleteBehavior.ClientSetNull);

            builder.HasOne(d => d.IdTeamNavigation)
                   .WithMany(p => p.Player_Team)
                   .HasForeignKey(d => d.IdTeam)
                   .OnDelete(DeleteBehavior.ClientSetNull);

            // seed data
            builder.HasData(
                    new Player_Team { IdPlayerTeam = 1, IdPlayer = 1, IdTeam = 2, NumOnShirt = 101, Comment = "Comment1" },
                    new Player_Team { IdPlayerTeam = 2, IdPlayer = 3, IdTeam = 1, NumOnShirt = 122, Comment = "Comment1" },
                    new Player_Team { IdPlayerTeam = 3, IdPlayer = 2, IdTeam = 3, NumOnShirt = 421, Comment = "Comment1" },
                    new Player_Team { IdPlayerTeam = 4, IdPlayer = 3, IdTeam = 2, NumOnShirt = 512, Comment = "Comment1" },
                    new Player_Team { IdPlayerTeam = 5, IdPlayer = 1, IdTeam = 1, NumOnShirt = 111, Comment = "Comment1" }
                );
        }
    }
}
