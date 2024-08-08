using BeeLineApi.Dto;
using BeeLineApi.Models;

namespace BeeLineApi.Interface
{
    public interface IUserRepository
    {
        Task<bool> RegisterUserAsync(RegisterUserDto userDto);
        Task<Profile> FindUserByNameAsync(string name);
        Task<bool> CheckPasswordAsync(Profile user, string password);
        Task<Profile> GetUserProfileAsync(string userName);
        Task<Profile> GetFriendProfileAsync(string friendId);
    } 
}
