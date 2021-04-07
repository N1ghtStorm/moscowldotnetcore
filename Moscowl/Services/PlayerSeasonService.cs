using Moscowl.Models;
using Moscowl.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Moscowl.Services
{
    public class PlayerSeasonService : IPlayerSeasonService
    {
        private readonly IPlayerSeasonRepository m_repo;

        public PlayerSeasonService(IPlayerSeasonRepository repo)
        {
            m_repo = repo;
        }

        public async Task<PlayerSeason> CreatePlayerSeason(PlayerSeason player_season)
        {
            return await m_repo.CreatePlayerSeason(player_season);
        }

        public async Task<PlayerSeason> DeletePlayerSeason(int id)
        {
            return await m_repo.DeletePlayerSeason(id);
        }

        public async Task<PlayerSeason> GetPlayerSeason(int id)
        {
            return await m_repo.GetPlayerSeason(id);
        }

        public async Task<List<PlayerSeason>> GetPlayersSeason()
        {
            return await m_repo.GetPlayersSeason();
        }

        public async Task<PlayerSeason> UpdatePlayerSeason(int id, PlayerSeason player_season)
        {
            return await m_repo.UpdatePlayerSeason(id, player_season);
        }
    }
}
