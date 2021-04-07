using Moscowl.Models;
using Moscowl.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Moscowl.Services
{
    public class PlayerService : IPlayerService
    {
        private readonly IPlayerRepository m_repo;

        public PlayerService(IPlayerRepository repo)
        {
            m_repo = repo;
        }

        public async Task<Player> CreatePlayer(Player player)
        {
            return await m_repo.CreatePlayer(player);
        }

        public async Task<Player> DeletePlayer(int id)
        {
            return await m_repo.DeletePlayer(id);
        }

        public async Task<Player> GetPlayer(int id)
        {
            return await m_repo.GetPlayer(id);
        }

        public async Task<List<Player>> GetPlayers()
        {
            return await m_repo.GetPlayers();
        }

        public async Task<Player> UpdatePlayer(int id, Player player)
        {
            return await m_repo.CreatePlayer(player);
        }
    }
}
