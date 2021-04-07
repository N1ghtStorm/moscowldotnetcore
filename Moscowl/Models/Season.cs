namespace Moscowl.Models
{
    public class Season
    {
        public int Id { get; set; }
        public string SeasonName { get; set; }

        public PlayerSeason PlayerSeasons { get; set; }
    }
}
