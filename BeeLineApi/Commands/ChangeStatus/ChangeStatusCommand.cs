using MediatR;

namespace BeeLineApi.Commands.ChangeStatus
{
    public class ChangeStatusCommand : IRequest<ChangeStatusResult>
    {
        public string? FriendId { get; set; }
        public bool IsCloseFriend { get; set; }
    }
}
