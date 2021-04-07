using Microsoft.EntityFrameworkCore;
using Moscowl.Data;
using Moscowl.Exceptions;
using Moscowl.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Moscowl.Repositories
{
    public class SeasonRepository : ISeasonRepository
    {
        private readonly OwlDbContext m_db_context;

        public SeasonRepository(OwlDbContext db_context)
        {
            m_db_context = db_context;
        }

        public async Task<Season> CreateSeason(Season season)
        {
            await m_db_context.AddAsync(season);
            await m_db_context.SaveChangesAsync();
            return season;
        }

        public async Task<Season> DeleteSeason(int id)
        {
            var season = await m_db_context.Seasons.FindAsync(id);

            if (season == null)
            {
                throw new NotFoundException();
            }

            m_db_context.Remove(season);
            await m_db_context.SaveChangesAsync();
            return season;
        }

        public async Task<Season> GetSeason(int id)
        {
            return await m_db_context.Seasons.FindAsync(id);
        }

        public async Task<List<Season>> GetSeasons()
        {
            return await m_db_context.Seasons.ToListAsync();
        }

        public async Task<Season> UpdateSeason(int id, Season season)
        {
            var found_season = await m_db_context.Seasons.FindAsync(id);

            if (found_season == null)
            {
                throw new NotFoundException();
            }

            season.Id = id;
            m_db_context.Update(season);
            await m_db_context.SaveChangesAsync();
            return season;
        }
    }
}
