using MediatR;

namespace BeeLineApi.Commands.AddFriend
{
    public class AddFriendCommand : IRequest<AddFriendResult>
    {
        public string? UserName { get; set; }
        public string? FriendId { get; set; }
        public bool IsCloseFriend { get; set; }
        public DateTime FriendshipStartDate { get; set; }
    }
}
