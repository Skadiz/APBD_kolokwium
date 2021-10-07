using PlayerTeamAPI.EFConfigurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlayerTeamAPI.Models
{
    public class MainDbContext : DbContext
    {
        public MainDbContext()
        {

        }

        public MainDbContext(DbContextOptions dbContextOptions)
            : base(dbContextOptions) // passing argument to super class DbContext
        {

        }

        public DbSet<Player> Player { get; set; } // table in DB
        public DbSet<Championship> Championship { get; set; }
        public DbSet<Team> Team { get; set; }
        public DbSet<Player_Team> Player_Team { get; set; }
        public DbSet<Championship_Team> Championship_Team { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new TeamEntityTypeConfig());
            modelBuilder.ApplyConfiguration(new PlayerEntityTypeConfig());
            modelBuilder.ApplyConfiguration(new Player_TeamEntityTypeConfig());
            modelBuilder.ApplyConfiguration(new ChampionshipEntityTypeConfig());
            modelBuilder.ApplyConfiguration(new Championship_TeamEntityTypeConfig());
        }
    }
}
