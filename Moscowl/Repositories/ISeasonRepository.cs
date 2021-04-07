using Moscowl.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Moscowl.Repositories
{
    public interface  ISeasonRepository
    {
        Task<Season> CreateSeason(Season season);
        Task<Season> GetSeason(int id);
        Task<List<Season>> GetSeasons();
        Task<Season> DeleteSeason(int id);
        Task<Season> UpdateSeason(int id, Season season);
    }
}
