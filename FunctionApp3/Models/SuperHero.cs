using System;
using System.Collections.Generic;
using System.Text;

namespace SuperHeroGames.Models
{
    public class SuperHero
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Power { get; set; }
        public Team Team { get; set; }
    }
}
