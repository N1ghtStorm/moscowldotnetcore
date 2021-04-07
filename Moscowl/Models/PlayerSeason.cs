using System.Collections.Generic;

namespace Moscowl.Models
{
    public class PlayerSeason
    {
        public int Id { get; set; }
        public int Score { get; set; }

        public int PlayerId { get; set; }
        public int SeasonId { get; set; }

        public Player Player { get; set; }
        public Season Season { get; set; }
        public List<Feature> Features { get; set; }
    }
}
