using Microsoft.EntityFrameworkCore;
using SuperHeroGames.Models;

namespace SuperHeroGames
{
    public class SuperHeroContext : DbContext
    {
        public SuperHeroContext(DbContextOptions<SuperHeroContext> options)
            : base(options)
        { }

        public DbSet<Team> Teams { get; set; }
        public DbSet<SuperHero> SuperHeroes { get; set; }
    }
}
