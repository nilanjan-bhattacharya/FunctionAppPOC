using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore.SqlServer;
using System;

[assembly: FunctionsStartup(typeof(SuperHeroGames.Startup))]

namespace SuperHeroGames
{
    class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            string SqlConnection = Environment.GetEnvironmentVariable("SqlConnectionString");
            builder.Services.AddDbContext<SuperHeroContext>(
                options => options.UseSqlServer(SqlConnection));
        }
    }
}
