﻿// <auto-generated />
using System;
using FootballСalendar.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace FootballСalendar.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("FootballСalendar.Entities.City", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<long?>("CountryId")
                        .IsRequired()
                        .HasColumnType("bigint");

                    b.Property<DateTime>("DateCreate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("DateDelete")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("DateModify")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("character varying(255)")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("tblCities");
                });

            modelBuilder.Entity("FootballСalendar.Entities.Coach", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<long?>("CountryId")
                        .IsRequired()
                        .HasColumnType("bigint");

                    b.Property<DateTime>("DateCreate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("DateDelete")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("DateModify")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("timestamp without time zone");

                    b.Property<long?>("FootballClubId")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("character varying(255)")
                        .HasMaxLength(255);

                    b.Property<string>("Surame")
                        .IsRequired()
                        .HasColumnType("character varying(255)")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("tblCoaches");
                });

            modelBuilder.Entity("FootballСalendar.Entities.Country", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("DateCreate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("DateDelete")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("DateModify")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Flag")
                        .IsRequired()
                        .HasColumnType("character varying(255)")
                        .HasMaxLength(255);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("character varying(255)")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("tblCountries");
                });

            modelBuilder.Entity("FootballСalendar.Entities.DbRole", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("character varying(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("character varying(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("FootballСalendar.Entities.DbUser", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasColumnType("character varying(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("character varying(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("character varying(256)")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("boolean");

                    b.Property<string>("UserName")
                        .HasColumnType("character varying(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("FootballСalendar.Entities.DbUserRole", b =>
                {
                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.Property<long>("RoleId")
                        .HasColumnType("bigint");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("FootballСalendar.Entities.FootballClub", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<long?>("CityId")
                        .IsRequired()
                        .HasColumnType("bigint");

                    b.Property<long?>("CoachId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("DateCreate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("DateDelete")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("DateModify")
                        .HasColumnType("timestamp without time zone");

                    b.Property<long?>("HomeStadiumId")
                        .IsRequired()
                        .HasColumnType("bigint");

                    b.Property<long?>("LeagueId")
                        .IsRequired()
                        .HasColumnType("bigint");

                    b.Property<string>("Logo")
                        .IsRequired()
                        .HasColumnType("character varying(255)")
                        .HasMaxLength(255);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("character varying(255)")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.HasIndex("CoachId")
                        .IsUnique();

                    b.HasIndex("HomeStadiumId");

                    b.HasIndex("LeagueId");

                    b.ToTable("tblFootballClubs");
                });

            modelBuilder.Entity("FootballСalendar.Entities.FootballGame", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("DateCreate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("DateDelete")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("DateModify")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<long?>("GameStatusId")
                        .IsRequired()
                        .HasColumnType("bigint");

                    b.Property<long?>("HomeTeamId")
                        .HasColumnType("bigint");

                    b.Property<long?>("LeagueId")
                        .IsRequired()
                        .HasColumnType("bigint");

                    b.Property<long?>("OpponentTeamId")
                        .HasColumnType("bigint");

                    b.Property<long?>("StadiumId")
                        .IsRequired()
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("GameStatusId");

                    b.HasIndex("HomeTeamId")
                        .IsUnique();

                    b.HasIndex("LeagueId");

                    b.HasIndex("OpponentTeamId")
                        .IsUnique();

                    b.HasIndex("StadiumId");

                    b.ToTable("tblFootballGames");
                });

            modelBuilder.Entity("FootballСalendar.Entities.GameStatus", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("DateCreate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("DateDelete")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("DateModify")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("character varying(255)")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("tblGameStatuses");
                });

            modelBuilder.Entity("FootballСalendar.Entities.HomeTeam", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("DateCreate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("DateDelete")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("DateModify")
                        .HasColumnType("timestamp without time zone");

                    b.Property<long?>("FootballClubId")
                        .IsRequired()
                        .HasColumnType("bigint");

                    b.Property<long?>("FootballGameId")
                        .IsRequired()
                        .HasColumnType("bigint");

                    b.Property<int>("GoalCount")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("FootballClubId");

                    b.ToTable("tblHomeTeams");
                });

            modelBuilder.Entity("FootballСalendar.Entities.League", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<long?>("CountryId")
                        .IsRequired()
                        .HasColumnType("bigint");

                    b.Property<DateTime>("DateCreate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("DateDelete")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("DateModify")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("character varying(255)")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("tblLeagues");
                });

            modelBuilder.Entity("FootballСalendar.Entities.OpponentTeam", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("DateCreate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("DateDelete")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("DateModify")
                        .HasColumnType("timestamp without time zone");

                    b.Property<long?>("FootballClubId")
                        .IsRequired()
                        .HasColumnType("bigint");

                    b.Property<long?>("FootballGameId")
                        .IsRequired()
                        .HasColumnType("bigint");

                    b.Property<int>("GoalCount")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("FootballClubId");

                    b.ToTable("tblOpponentTeams");
                });

            modelBuilder.Entity("FootballСalendar.Entities.Player", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<long?>("CountryId")
                        .IsRequired()
                        .HasColumnType("bigint");

                    b.Property<DateTime>("DateCreate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("DateDelete")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("DateModify")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("timestamp without time zone");

                    b.Property<long?>("FootballClubId")
                        .IsRequired()
                        .HasColumnType("bigint");

                    b.Property<int>("GameNumber")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("character varying(255)")
                        .HasMaxLength(255);

                    b.Property<string>("Surame")
                        .IsRequired()
                        .HasColumnType("character varying(255)")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.HasIndex("FootballClubId");

                    b.ToTable("tblPlayers");
                });

            modelBuilder.Entity("FootballСalendar.Entities.Stadium", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("Capacity")
                        .HasColumnType("integer");

                    b.Property<long?>("CityId")
                        .IsRequired()
                        .HasColumnType("bigint");

                    b.Property<DateTime>("DateCreate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("DateDelete")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("DateModify")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("character varying(255)")
                        .HasMaxLength(255);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("character varying(255)")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.ToTable("tblStadiums");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<long>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<long>("RoleId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<long>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<long>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("character varying(128)")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderKey")
                        .HasColumnType("character varying(128)")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("text");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<long>", b =>
                {
                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("character varying(128)")
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .HasColumnType("character varying(128)")
                        .HasMaxLength(128);

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("FootballСalendar.Entities.City", b =>
                {
                    b.HasOne("FootballСalendar.Entities.Country", "Country")
                        .WithMany("Cities")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FootballСalendar.Entities.Coach", b =>
                {
                    b.HasOne("FootballСalendar.Entities.Country", "Nationality")
                        .WithMany("Coaches")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FootballСalendar.Entities.DbUserRole", b =>
                {
                    b.HasOne("FootballСalendar.Entities.DbRole", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FootballСalendar.Entities.DbUser", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FootballСalendar.Entities.FootballClub", b =>
                {
                    b.HasOne("FootballСalendar.Entities.City", "City")
                        .WithMany("FootballClubs")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FootballСalendar.Entities.Coach", "Coach")
                        .WithOne("FootballClub")
                        .HasForeignKey("FootballСalendar.Entities.FootballClub", "CoachId");

                    b.HasOne("FootballСalendar.Entities.Stadium", "HomeStadium")
                        .WithMany("FootballClubs")
                        .HasForeignKey("HomeStadiumId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FootballСalendar.Entities.League", "League")
                        .WithMany("FootballClubs")
                        .HasForeignKey("LeagueId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FootballСalendar.Entities.FootballGame", b =>
                {
                    b.HasOne("FootballСalendar.Entities.GameStatus", "GameStatus")
                        .WithMany("FootballGames")
                        .HasForeignKey("GameStatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FootballСalendar.Entities.HomeTeam", "HomeTeam")
                        .WithOne("FootballGame")
                        .HasForeignKey("FootballСalendar.Entities.FootballGame", "HomeTeamId")
                        .HasPrincipalKey("FootballСalendar.Entities.HomeTeam", "FootballGameId");

                    b.HasOne("FootballСalendar.Entities.League", "League")
                        .WithMany("FootballGames")
                        .HasForeignKey("LeagueId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FootballСalendar.Entities.OpponentTeam", "OpponentTeam")
                        .WithOne("FootballGame")
                        .HasForeignKey("FootballСalendar.Entities.FootballGame", "OpponentTeamId")
                        .HasPrincipalKey("FootballСalendar.Entities.OpponentTeam", "FootballGameId");

                    b.HasOne("FootballСalendar.Entities.Stadium", "Stadium")
                        .WithMany("FootballGames")
                        .HasForeignKey("StadiumId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FootballСalendar.Entities.HomeTeam", b =>
                {
                    b.HasOne("FootballСalendar.Entities.FootballClub", "FootballClub")
                        .WithMany("HomeTeams")
                        .HasForeignKey("FootballClubId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FootballСalendar.Entities.League", b =>
                {
                    b.HasOne("FootballСalendar.Entities.Country", "Country")
                        .WithMany("Leagues")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FootballСalendar.Entities.OpponentTeam", b =>
                {
                    b.HasOne("FootballСalendar.Entities.FootballClub", "FootballClub")
                        .WithMany("OpponentTeams")
                        .HasForeignKey("FootballClubId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FootballСalendar.Entities.Player", b =>
                {
                    b.HasOne("FootballСalendar.Entities.Country", "Nationality")
                        .WithMany("Players")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FootballСalendar.Entities.FootballClub", "FootballClub")
                        .WithMany("Players")
                        .HasForeignKey("FootballClubId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FootballСalendar.Entities.Stadium", b =>
                {
                    b.HasOne("FootballСalendar.Entities.City", "City")
                        .WithMany("Stadiums")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<long>", b =>
                {
                    b.HasOne("FootballСalendar.Entities.DbRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<long>", b =>
                {
                    b.HasOne("FootballСalendar.Entities.DbUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<long>", b =>
                {
                    b.HasOne("FootballСalendar.Entities.DbUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<long>", b =>
                {
                    b.HasOne("FootballСalendar.Entities.DbUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
