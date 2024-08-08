using BeeLineApi.Data;
using BeeLineApi.Interface;
using BeeLineApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BeeLineApi.Repository
{
    public class FriendRepository : IFriendRepository
    {
        private readonly DataContext _context;

        public FriendRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<int> AddFriendAsync(Friend friend)
        {
            await _context.Friends.AddAsync(friend);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> ChangeStatusAsync(Friend friend)
        {
            _context.Entry(friend).State = EntityState.Modified;
            return await _context.SaveChangesAsync();
        }

        public int DeleteFriend(Friend friend)
        {
            _context.Friends.Remove(friend);
            return _context.SaveChanges();
        }

        public async Task<Friend> GetFriendByIdAsync(string friendId)
        {
            return await _context.Friends.Where(f => f.FriendId == friendId).
                FirstOrDefaultAsync();
        }
    }
}
