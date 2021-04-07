using Moscowl.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Moscowl.Services
{
    public interface IPlayerService
    {
        Task<Player> CreatePlayer(Player player);
        Task<Player> GetPlayer(int id);
        Task<List<Player>> GetPlayers();
        Task<Player> DeletePlayer(int id);
        Task<Player> UpdatePlayer(int id, Player player);
    }
}
