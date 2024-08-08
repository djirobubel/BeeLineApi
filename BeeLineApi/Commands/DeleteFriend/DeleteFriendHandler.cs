using BeeLineApi.Interface;
using MediatR;

namespace BeeLineApi.Commands.DeleteFriend
{
    public class DeleteFriendHandler : IRequestHandler<DeleteFriendCommand,
        DeleteFriendResult>
    {
        private readonly IFriendRepository _friendRepository;
        private readonly IUserRepository _userRepository;

        public DeleteFriendHandler(IFriendRepository friendRepository,
            IUserRepository userRepository)
        {
            _friendRepository = friendRepository;
            _userRepository = userRepository;
        }

        public async Task<DeleteFriendResult> Handle(DeleteFriendCommand request, 
            CancellationToken cancellationToken)
        {
            var friend = await _friendRepository.GetFriendByIdAsync(request.FriendId);
            _friendRepository.DeleteFriend(friend);

            var user = await _userRepository.FindUserByNameAsync(request.UserName);
            var userFriend = await _friendRepository.GetFriendByIdAsync(user.Id);
            _friendRepository.DeleteFriend(userFriend);

            return new DeleteFriendResult { Message = "Successfully deleted." };
        }
    }
}
