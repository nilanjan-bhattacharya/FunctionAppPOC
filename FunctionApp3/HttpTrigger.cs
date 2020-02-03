using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Linq;
using System;
using System.Threading;
using Newtonsoft.Json;
using System.IO;
using SuperHeroGames.Models;

namespace SuperHeroGames
{
    public class HttpTrigger
    {
        private readonly SuperHeroContext _context;
        public HttpTrigger(SuperHeroContext context)
        {
            _context = context;
        }

        [FunctionName("GetTestOp")]
        public IActionResult GetTestOp(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "testOp")] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP GET/posts trigger function processed a request.");

            return new OkObjectResult("Test Success");
        }

        [FunctionName("GetHeroes")]
        public IActionResult GetPosts(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "heroes")] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP GET/posts trigger function processed a request.");

            var postsArray = _context.SuperHeroes.OrderBy(p => p.Name).ToArray();
            return new OkObjectResult(postsArray);
        }

        [FunctionName("CreateHero")]
        public async Task<IActionResult> AddHeroAsync(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = "superhero/{heroId}/add")] HttpRequest req,
            int heroId,
            CancellationToken cts,
            ILogger log)
        {
            log.LogInformation("C# HTTP POST/post trigger function processed a request.");

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            var data = JsonConvert.DeserializeObject<SuperHero>(requestBody);

            var superHero = new SuperHero
            {
                Id = heroId,
                Name = data.Name,
                Power = data.Power
            };
            var entity = await _context.SuperHeroes.AddAsync(superHero, cts);
            await _context.SaveChangesAsync(cts);
            return new OkObjectResult(JsonConvert.SerializeObject(entity.Entity));
        }

        [FunctionName("CreateTeam")]
        public async Task<IActionResult> CreateTeamAsync(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = "team")] HttpRequest req,
            CancellationToken cts,
            ILogger log)
        {
            log.LogInformation("C# HTTP POST/blog trigger function processed a request.");

            var entity = await _context.Teams.AddAsync(new Team(), cts);
            await _context.SaveChangesAsync(cts);
            return new OkObjectResult(JsonConvert.SerializeObject(entity.Entity));
        }
    }
}
