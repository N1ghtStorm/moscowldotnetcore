using Microsoft.EntityFrameworkCore;
using Moscowl.Data;
using Moscowl.Exceptions;
using Moscowl.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Moscowl.Repositories
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly OwlDbContext m_db_context;

        public PlayerRepository(OwlDbContext db_context)
        {
            m_db_context = db_context;
        }

        public async Task<Player> CreatePlayer(Player player)
        {
            await m_db_context.AddAsync(player);
            await m_db_context.SaveChangesAsync();
            return player;
        }

        public async Task<Player> DeletePlayer(int id)
        {
            var player = await m_db_context.Players.FindAsync(id);

            if(player == null)
            {
                throw new NotFoundException();
            }

            m_db_context.Remove(player);
            await m_db_context.SaveChangesAsync();
            return player;
        }

        public async Task<Player> GetPlayer(int id)
        {
            return await m_db_context.Players.FindAsync(id);
        }

        public async Task<List<Player>> GetPlayers()
        {
            return await m_db_context.Players.ToListAsync();
        }

        public async Task<Player> UpdatePlayer(int id, Player player)
        {
            var found_player = await m_db_context.Players.FindAsync(id);

            if (found_player == null)
            {
                throw new NotFoundException();
            }

            player.Id = id;
            m_db_context.Update(player);
            await m_db_context.SaveChangesAsync();
            return player;
        }
    }
}
