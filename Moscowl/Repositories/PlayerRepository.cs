using Moscowl.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Moscowl.Repositories
{
    public class PlayerRepository : IPlayerRepository
    {
        public Task<Player> CreatePlayer(Player player)
        {
            throw new NotImplementedException();
        }

        public Task<Player> DeletePlayer(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Player> GetPlayer(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Player>> GetPlayers()
        {
            throw new NotImplementedException();
        }

        public Task<Player> UpdatePlayer(int id, Player player)
        {
            throw new NotImplementedException();
        }
    }
}
