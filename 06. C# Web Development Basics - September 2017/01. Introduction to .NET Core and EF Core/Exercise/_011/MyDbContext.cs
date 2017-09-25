namespace _011
{
    using _011.Models;
    using Microsoft.EntityFrameworkCore;

    public class MyDbContext : DbContext
    {
        public DbSet<Bet> Bets { get; set; }

        public DbSet<BetGame> BetGames { get; set; }

        public DbSet<Color> Colors { get; set; }

        public DbSet<Competition> Competitions { get; set; }

        public DbSet<CompetitionType> CompetitionTypes { get; set; }

        public DbSet<Continent> Continents { get; set; }

        public DbSet<Countrie> Countries { get; set; }

        public DbSet<Game> Games { get; set; }

        public DbSet<PlayerStatistic> PlayerStatistics { get; set; }

        public DbSet<Position> Positions { get; set; }

        public DbSet<ResultPrediction> ResultPredictions { get; set; }

        public DbSet<Round> Rounds { get; set; }

        public DbSet<Team> Teams { get; set; }

        public DbSet<Town> Towns { get; set; }

        public DbSet<User> Users { get; set; }

        //public DbSet<CountriesContinents> CountriesContinents { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer(@"Server=.;Database=_011;Integrated Security=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BetGame>()
                .HasKey(a => new { a.BetId, a.GameId });

            modelBuilder.Entity<Game>()
                .HasMany(a => a.Bets)
                .WithOne(a => a.Game)
                .HasForeignKey(a => a.GameId);

            modelBuilder.Entity<Bet>()
               .HasMany(a => a.Games)
               .WithOne(a => a.Bet)
               .HasForeignKey(a => a.BetId);

            modelBuilder.Entity<PlayerStatistic>()
                .HasKey(a => new { a.PlayerId, a.GameId });

            modelBuilder.Entity<Game>()
               .HasMany(a => a.PlayersStatistics)
               .WithOne(a => a.Game)
               .HasForeignKey(a => a.GameId);

            modelBuilder.Entity<Player>()
               .HasMany(a => a.Statistics)
               .WithOne(a => a.Player)
               .HasForeignKey(a => a.PlayerId);

            modelBuilder.Entity<Town>()
                .HasMany(a => a.Teams)
                .WithOne(a => a.Town)
                .HasForeignKey(a => a.TownId);

            //modelBuilder.Entity<Countrie>()
            //    .HasMany(a => a.Towns)
            //    .WithOne(a => a.Countrie)
            //    .HasForeignKey(a => a.CountrieId);

            modelBuilder.Entity<CountriesContinents>()
                .HasKey(a => new { a.ContinentId, a.CountrieId });

            modelBuilder.Entity<Continent>()
                .HasMany(a => a.Countries)
                .WithOne(a => a.Continent)
                .HasForeignKey(a => a.ContinentId);

            modelBuilder.Entity<Countrie>()
               .HasMany(a => a.Contienets)
               .WithOne(a => a.Countrie)
               .HasForeignKey(a => a.CountrieId);

            modelBuilder.Entity<Team>()
                .HasMany(a => a.Players)
                .WithOne(a => a.Team)
                .HasForeignKey(a => a.TeamId);

            modelBuilder.Entity<Position>()
               .HasMany(a => a.Players)
               .WithOne(a => a.Position)
               .HasForeignKey(a => a.PositionId);

            //?????????????
            //modelBuilder.Entity<PlayerGames>()
            //   .HasKey(a => new { a.PlayerId, a.GameId });

            //modelBuilder.Entity<Player>()
            //    .HasMany(a => a.Games)
            //    .WithOne(a => a.Player)
            //    .HasForeignKey(a => a.PlayerId);

            //modelBuilder.Entity<Game>()
            //   .HasMany(a => a.PlayersGames)
            //   .WithOne(a => a.Game)
            //   .HasForeignKey(a => a.GameId);
        }
    }
}