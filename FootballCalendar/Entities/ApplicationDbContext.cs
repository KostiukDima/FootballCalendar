using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootballСalendar.Entities
{
    public class ApplicationDbContext : IdentityDbContext<DbUser, DbRole, long, IdentityUserClaim<long>,
                                       DbUserRole, IdentityUserLogin<long>,
                                       IdentityRoleClaim<long>, IdentityUserToken<long>>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
        public DbSet<City> Cities { get; set; }
        public DbSet<Coach> Coaches { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<FootballClub> FootballClubs { get; set; }
        public DbSet<FootballGame> FootballGames { get; set; }
        public DbSet<GameStatus> GameStatuses { get; set; }
        public DbSet<HomeTeam> HomeTeams { get; set; }
        public DbSet<OpponentTeam> OpponentTeams { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Stadium> Stadiums { get; set; }
        public DbSet<League> Leagues { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {            
            base.OnModelCreating(builder);

            builder.Entity<DbUserRole>(userRole =>
            {
                userRole.HasKey(ur => new { ur.UserId, ur.RoleId });

                userRole.HasOne(ur => ur.Role)
                    .WithMany(r => r.UserRoles)
                    .HasForeignKey(ur => ur.RoleId)
                    .IsRequired();

                userRole.HasOne(ur => ur.User)
                    .WithMany(r => r.UserRoles)
                    .HasForeignKey(ur => ur.UserId)
                    .IsRequired();
            });


            builder.Entity<Country>()
                .HasMany<City>(c => c.Cities).WithOne(ci => ci.Country).HasForeignKey(ci => ci.CountryId).IsRequired();

            builder.Entity<Country>()
                .HasMany<Coach>(c => c.Coaches).WithOne(co => co.Nationality).HasForeignKey(co => co.CountryId).IsRequired();

            builder.Entity<Country>()
                .HasMany<Player>(c => c.Players).WithOne(p => p.Nationality).HasForeignKey(co => co.CountryId).IsRequired();

            builder.Entity<Country>()
                .HasMany<League>(c => c.Leagues).WithOne(l => l.Country).HasForeignKey(l => l.CountryId).IsRequired();

            builder.Entity<City>()
                .HasMany<Stadium>(c => c.Stadiums).WithOne(s => s.City).HasForeignKey(s => s.CityId).IsRequired();

            builder.Entity<City>()
               .HasMany<FootballClub>(c => c.FootballClubs).WithOne(f => f.City).HasForeignKey(f => f.CityId).IsRequired();

            builder.Entity<Stadium>()
                   .HasMany<FootballClub>(s => s.FootballClubs).WithOne(f => f.HomeStadium).HasForeignKey(f => f.HomeStadiumId).IsRequired();

            builder.Entity<Stadium>()
                   .HasMany<FootballGame>(s => s.FootballGames).WithOne(f => f.Stadium).HasForeignKey(f => f.StadiumId).IsRequired();

            builder.Entity<League>()
                   .HasMany<FootballClub>(l => l.FootballClubs).WithOne(f => f.League).HasForeignKey(f => f.LeagueId).IsRequired();

            builder.Entity<FootballClub>()
                   .HasMany<Player>(f => f.Players).WithOne(p => p.FootballClub).HasForeignKey(p => p.FootballClubId).IsRequired();

            builder.Entity<FootballClub>()
                   .HasMany<HomeTeam>(f => f.HomeTeams).WithOne(h => h.FootballClub).HasForeignKey(h => h.FootballClubId).IsRequired();

            builder.Entity<FootballClub>()
                   .HasMany<OpponentTeam>(f => f.OpponentTeams).WithOne(o => o.FootballClub).HasForeignKey(o => o.FootballClubId).IsRequired();

            builder.Entity<League>()
                   .HasMany<FootballGame>(l => l.FootballGames).WithOne(f => f.League).HasForeignKey(f => f.LeagueId).IsRequired();

            builder.Entity<GameStatus>()
                   .HasMany<FootballGame>(l => l.FootballGames).WithOne(f => f.GameStatus).HasForeignKey(f => f.GameStatusId).IsRequired();

            builder.Entity<FootballGame>()
                  .HasOne<HomeTeam>(f => f.HomeTeam).WithOne(h => h.FootballGame)
                  .HasForeignKey<FootballGame>(f => f.HomeTeamId);

            builder.Entity<FootballGame>()
                 .HasOne<OpponentTeam>(f => f.OpponentTeam).WithOne(o => o.FootballGame)
                 .HasForeignKey<FootballGame>(f => f.OpponentTeamId);

            builder.Entity<FootballClub>()
                  .HasOne<Coach>(f => f.Coach).WithOne(c => c.FootballClub)
                  .HasForeignKey<FootballClub>(f => f.CoachId);


        }

    }
}
