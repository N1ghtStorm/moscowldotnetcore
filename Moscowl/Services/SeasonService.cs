using Moscowl.Models;
using Moscowl.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Moscowl.Services
{
    public class SeasonService : ISeasonService
    {
        private readonly ISeasonRepository m_repo;

        public SeasonService(ISeasonRepository repo)
        {
            m_repo = repo;
        }

        public async Task<Season> CreateSeason(Season season)
        {
            return await m_repo.CreateSeason(season);
        }

        public async Task<Season> DeleteSeason(int id)
        {
            return await m_repo.DeleteSeason(id);
        }

        public async Task<Season> GetSeason(int id)
        {
            return await m_repo.GetSeason(id);
        }

        public async Task<List<Season>> GetSeasons()
        {
            return await m_repo.GetSeasons();
        }

        public async Task<Season> UpdateSeason(int id, Season season)
        {
            return await m_repo.UpdateSeason(id, season);
        }
    }
}
