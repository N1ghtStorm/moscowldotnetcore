using Moscowl.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Moscowl.Repositories
{
    public interface IPlayerSeasonRepository
    {
        Task<PlayerSeason> CreatePlayerSeason(PlayerSeason player_season);
        Task<PlayerSeason> GetPlayerSeason(int id);
        Task<List<PlayerSeason>> GetPlayersSeason();
        Task<PlayerSeason> DeletePlayerSeason(int id);
        Task<PlayerSeason> UpdatePlayerSeason(int id, PlayerSeason player_season);
    }
}
