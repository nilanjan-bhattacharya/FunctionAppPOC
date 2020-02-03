using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperHeroGames
{
    public class BloggingContextFactory : IDesignTimeDbContextFactory<SuperHeroContext>
    {
        public SuperHeroContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<SuperHeroContext>();
            optionsBuilder.UseSqlServer(Environment.GetEnvironmentVariable("SqlConnectionString"));

            return new SuperHeroContext(optionsBuilder.Options);
        }
    }
}
