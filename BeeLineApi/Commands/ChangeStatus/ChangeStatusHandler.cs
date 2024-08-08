using BeeLineApi.Interface;
using MediatR;

namespace BeeLineApi.Commands.ChangeStatus
{
    public class ChangeStatusHandler : IRequestHandler<ChangeStatusCommand,
        ChangeStatusResult>
    {
        private readonly IFriendRepository _friendRepository;

        public ChangeStatusHandler(IFriendRepository friendRepository)
        {
            _friendRepository = friendRepository;

        }

        public async Task<ChangeStatusResult> Handle(ChangeStatusCommand request,
            CancellationToken cancellationToken)
        {
            var friend = await _friendRepository.GetFriendByIdAsync(request.FriendId);

            friend.IsCloseFriend = request.IsCloseFriend;

            await _friendRepository.ChangeStatusAsync(friend);

            return new ChangeStatusResult { Message = "Successfully updated" };
        }
    }
}
