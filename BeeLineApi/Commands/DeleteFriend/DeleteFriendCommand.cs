using MediatR;

namespace BeeLineApi.Commands.DeleteFriend
{
    public class DeleteFriendCommand : IRequest<DeleteFriendResult>
    {
        public string? UserName { get; set; }
        public string? FriendId { get; set; }
    }
}
