﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PlayerTeamAPI.Models;

namespace Kol1.Migrations
{
    [DbContext(typeof(MainDbContext))]
    [Migration("20210511185231_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PlayerTeamAPI.Models.Championship", b =>
                {
                    b.Property<int>("IdChampionship")
                        .HasColumnType("int");

                    b.Property<string>("OfficialName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("IdChampionship");

                    b.ToTable("Championship");

                    b.HasData(
                        new
                        {
                            IdChampionship = 1,
                            OfficialName = "Name1",
                            Year = 2000
                        },
                        new
                        {
                            IdChampionship = 2,
                            OfficialName = "Name2",
                            Year = 2001
                        },
                        new
                        {
                            IdChampionship = 3,
                            OfficialName = "Name3",
                            Year = 2002
                        },
                        new
                        {
                            IdChampionship = 4,
                            OfficialName = "Name4",
                            Year = 2003
                        },
                        new
                        {
                            IdChampionship = 5,
                            OfficialName = "Name5",
                            Year = 2004
                        });
                });

            modelBuilder.Entity("PlayerTeamAPI.Models.Championship_Team", b =>
                {
                    b.Property<int>("IdChampionshipTeam")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IdChampionship")
                        .HasColumnType("int");

                    b.Property<int>("IdTeam")
                        .HasColumnType("int");

                    b.Property<float>("Score")
                        .HasColumnType("real");

                    b.HasKey("IdChampionshipTeam");

                    b.HasIndex("IdChampionship");

                    b.HasIndex("IdTeam");

                    b.ToTable("Championship_Team");

                    b.HasData(
                        new
                        {
                            IdChampionshipTeam = 1,
                            IdChampionship = 2,
                            IdTeam = 1,
                            Score = 1f
                        },
                        new
                        {
                            IdChampionshipTeam = 2,
                            IdChampionship = 1,
                            IdTeam = 2,
                            Score = 1.1f
                        },
                        new
                        {
                            IdChampionshipTeam = 3,
                            IdChampionship = 3,
                            IdTeam = 3,
                            Score = 1.2f
                        },
                        new
                        {
                            IdChampionshipTeam = 4,
                            IdChampionship = 3,
                            IdTeam = 3,
                            Score = 2f
                        },
                        new
                        {
                            IdChampionshipTeam = 5,
                            IdChampionship = 1,
                            IdTeam = 2,
                            Score = 3f
                        });
                });

            modelBuilder.Entity("PlayerTeamAPI.Models.Player", b =>
                {
                    b.Property<int>("IdPlayer")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("IdPlayer");

                    b.ToTable("Player");

                    b.HasData(
                        new
                        {
                            IdPlayer = 1,
                            DateOfBirth = new DateTime(2021, 5, 11, 20, 52, 30, 824, DateTimeKind.Local).AddTicks(8746),
                            FirstName = "Jan",
                            LastName = "Dobusz"
                        },
                        new
                        {
                            IdPlayer = 2,
                            DateOfBirth = new DateTime(2021, 5, 11, 20, 52, 30, 828, DateTimeKind.Local).AddTicks(7551),
                            FirstName = "Barby",
                            LastName = "Girl"
                        },
                        new
                        {
                            IdPlayer = 3,
                            DateOfBirth = new DateTime(2021, 5, 11, 20, 52, 30, 828, DateTimeKind.Local).AddTicks(7597),
                            FirstName = "Diana",
                            LastName = "Kathe"
                        });
                });

            modelBuilder.Entity("PlayerTeamAPI.Models.Player_Team", b =>
                {
                    b.Property<int>("IdPlayerTeam")
                        .HasColumnType("int");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("IdPlayer")
                        .HasColumnType("int");

                    b.Property<int>("IdTeam")
                        .HasColumnType("int");

                    b.Property<int>("NumOnShirt")
                        .HasColumnType("int");

                    b.HasKey("IdPlayerTeam");

                    b.HasIndex("IdPlayer");

                    b.HasIndex("IdTeam");

                    b.ToTable("Player_Team");

                    b.HasData(
                        new
                        {
                            IdPlayerTeam = 1,
                            Comment = "Comment1",
                            IdPlayer = 1,
                            IdTeam = 2,
                            NumOnShirt = 101
                        },
                        new
                        {
                            IdPlayerTeam = 2,
                            Comment = "Comment1",
                            IdPlayer = 3,
                            IdTeam = 1,
                            NumOnShirt = 122
                        },
                        new
                        {
                            IdPlayerTeam = 3,
                            Comment = "Comment1",
                            IdPlayer = 2,
                            IdTeam = 3,
                            NumOnShirt = 421
                        },
                        new
                        {
                            IdPlayerTeam = 4,
                            Comment = "Comment1",
                            IdPlayer = 3,
                            IdTeam = 2,
                            NumOnShirt = 512
                        },
                        new
                        {
                            IdPlayerTeam = 5,
                            Comment = "Comment1",
                            IdPlayer = 1,
                            IdTeam = 1,
                            NumOnShirt = 111
                        });
                });

            modelBuilder.Entity("PlayerTeamAPI.Models.Team", b =>
                {
                    b.Property<int>("IdTeam")
                        .HasColumnType("int");

                    b.Property<int>("MaxAge")
                        .HasColumnType("int");

                    b.Property<string>("TeamName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("IdTeam");

                    b.ToTable("Team");

                    b.HasData(
                        new
                        {
                            IdTeam = 1,
                            MaxAge = 23,
                            TeamName = "Dinamo"
                        },
                        new
                        {
                            IdTeam = 2,
                            MaxAge = 25,
                            TeamName = "Shahter"
                        },
                        new
                        {
                            IdTeam = 3,
                            MaxAge = 30,
                            TeamName = "Team3"
                        });
                });

            modelBuilder.Entity("PlayerTeamAPI.Models.Championship_Team", b =>
                {
                    b.HasOne("PlayerTeamAPI.Models.Championship", "IdChampionshipNavigation")
                        .WithMany("Championship_Team")
                        .HasForeignKey("IdChampionship")
                        .IsRequired();

                    b.HasOne("PlayerTeamAPI.Models.Team", "IdTeamNavigation")
                        .WithMany("Championship_Team")
                        .HasForeignKey("IdTeam")
                        .IsRequired();

                    b.Navigation("IdChampionshipNavigation");

                    b.Navigation("IdTeamNavigation");
                });

            modelBuilder.Entity("PlayerTeamAPI.Models.Player_Team", b =>
                {
                    b.HasOne("PlayerTeamAPI.Models.Player", "IdPlayerNavigation")
                        .WithMany("Player_Team")
                        .HasForeignKey("IdPlayer")
                        .IsRequired();

                    b.HasOne("PlayerTeamAPI.Models.Team", "IdTeamNavigation")
                        .WithMany("Player_Team")
                        .HasForeignKey("IdTeam")
                        .IsRequired();

                    b.Navigation("IdPlayerNavigation");

                    b.Navigation("IdTeamNavigation");
                });

            modelBuilder.Entity("PlayerTeamAPI.Models.Championship", b =>
                {
                    b.Navigation("Championship_Team");
                });

            modelBuilder.Entity("PlayerTeamAPI.Models.Player", b =>
                {
                    b.Navigation("Player_Team");
                });

            modelBuilder.Entity("PlayerTeamAPI.Models.Team", b =>
                {
                    b.Navigation("Championship_Team");

                    b.Navigation("Player_Team");
                });
#pragma warning restore 612, 618
        }
    }
}
