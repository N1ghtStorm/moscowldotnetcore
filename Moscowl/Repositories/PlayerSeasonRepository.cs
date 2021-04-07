using Microsoft.EntityFrameworkCore;
using Moscowl.Data;
using Moscowl.Exceptions;
using Moscowl.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Moscowl.Repositories
{
    public class PlayerSeasonRepository : IPlayerSeasonRepository
    {
        private readonly OwlDbContext m_db_context;

        public PlayerSeasonRepository(OwlDbContext db_context)
        {
            m_db_context = db_context;
        }

        public async Task<PlayerSeason> CreatePlayerSeason(PlayerSeason player_season)
        {
            await m_db_context.AddAsync(player_season);
            await m_db_context.SaveChangesAsync();
            return player_season;
        }

        public async Task<PlayerSeason> DeletePlayerSeason(int id)
        {
            var player_season = await m_db_context.PlayerSeasons.FindAsync(id);

            if (player_season == null)
            {
                throw new NotFoundException();
            }

            m_db_context.Remove(player_season);
            await m_db_context.SaveChangesAsync();
            return player_season;
        }

        public async Task<PlayerSeason> GetPlayerSeason(int id)
        {
            return await m_db_context.PlayerSeasons.FindAsync(id);
        }

        public async Task<List<PlayerSeason>> GetPlayersSeason()
        {
            return await m_db_context.PlayerSeasons.ToListAsync();
        }

        public async Task<PlayerSeason> UpdatePlayerSeason(int id, PlayerSeason player_season)
        {
            var found_player_season = await m_db_context.PlayerSeasons.FindAsync(id);

            if (found_player_season == null)
            {
                throw new NotFoundException();
            }

            player_season.Id = id;
            m_db_context.Update(player_season);
            await m_db_context.SaveChangesAsync();
            return player_season;
        }
    }
}
