using System;
using System.Collections.Generic;
using System.Text;

namespace SuperHeroGames.Models
{
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Moto { get; set; }

        public ICollection<SuperHero> Heroes { get; set; }
    }
}
