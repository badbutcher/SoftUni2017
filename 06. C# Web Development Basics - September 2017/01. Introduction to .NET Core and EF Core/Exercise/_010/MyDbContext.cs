namespace _010
{
    using _010.Models;
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

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer(@"Server=.;Database=_010;Integrated Security=True;");
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //}
    }
}