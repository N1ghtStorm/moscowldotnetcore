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
        public Feature Feature { get; set; }
    }
}