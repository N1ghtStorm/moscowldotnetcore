using System.Collections.Generic;

namespace Moscowl.Models
{
    public class Feature
    {
        public int Id { get; set; }

        public string FeatureName { get; set; }
        public List<PlayerSeason> PlayerSeasons { get; set; }
    }
}