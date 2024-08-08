using BeeLineApi.Models;

namespace BeeLineApi.Interface
{
    public interface IFriendRepository
    {
        Task<int> AddFriendAsync(Friend friend);
        Task<Friend> GetFriendByIdAsync(string friendId);
        int DeleteFriend(Friend friend);
    }
}
