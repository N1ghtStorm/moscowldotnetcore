using Moscowl.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Moscowl.Services
{
    public interface IPlayerSeasonService
    {
        Task<PlayerSeason> CreatePlayerSeason(PlayerSeason player_season);
        Task<PlayerSeason> GetPlayerSeason(int id);
        Task<List<PlayerSeason>> GetPlayersSeason();
        Task<PlayerSeason> DeletePlayerSeason(int id);
        Task<PlayerSeason> UpdatePlayerSeason(int id, PlayerSeason player_season);
    }
}
