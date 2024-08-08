using BeeLineApi.Data;
using BeeLineApi.Dto;
using BeeLineApi.Interface;
using BeeLineApi.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BeeLineApi.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<Profile> _userManager;
        private readonly DataContext _context;

        public UserRepository(UserManager<Profile> userManager, DataContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        public async Task<bool> CheckPasswordAsync(Profile user, string password)
        {
            return await _userManager.CheckPasswordAsync(user, password);
        }

        public async Task<Profile> FindUserByNameAsync(string name)
        {
            return await _userManager.FindByNameAsync(name);
        }

        public async Task<Profile> GetFriendProfileAsync(string friendId)
        {
            var friend = await _context.Users.Include(f => f.Friends).
                ThenInclude(f => f.FriendProfile).
                FirstOrDefaultAsync(i => i.Id == friendId);

            return friend;
        }

        public async Task<Profile> GetUserProfileAsync(string name)
        {
            var user = await _context.Users.Include(f => f.Friends).
                ThenInclude(f => f.FriendProfile).
                FirstOrDefaultAsync(u => u.UserName == name);

            return user;
        }

        public async Task<bool> RegisterUserAsync(RegisterUserDto userDto)
        {
            var newUser = new Profile
            {
                Email = userDto.Email,
                UserName = userDto.Username
            };

            var identityResult = await _userManager.CreateAsync(newUser, userDto.Password);
            var result = identityResult.Succeeded;
            return result;
        }
    }
}
