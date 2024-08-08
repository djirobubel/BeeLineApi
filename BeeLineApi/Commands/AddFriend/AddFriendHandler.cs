using BeeLineApi.Interface;
using BeeLineApi.Models;
using MediatR;

namespace BeeLineApi.Commands.AddFriend
{
    public class AddFriendHandler : IRequestHandler<AddFriendCommand, AddFriendResult>
    {
        private readonly IFriendRepository _friendRepository;
        private readonly IUserRepository _userRepository;

        public AddFriendHandler(IFriendRepository friendRepository, 
            IUserRepository userRepository)
        {
            _friendRepository = friendRepository;
            _userRepository = userRepository;
        }

        public async Task<AddFriendResult> Handle(AddFriendCommand request,
            CancellationToken cancellationToken)
        {
            var user = await _userRepository.FindUserByNameAsync(request.UserName);

            var friend1 = new Friend
            {
                UserId = user.Id,
                FriendId = request.FriendId,
                IsCloseFriend = request.IsCloseFriend,
                FriendshipStartDate = DateTime.UtcNow
            };

            await _friendRepository.AddFriendAsync(friend1);

            var friend2 = new Friend
            {
                UserId = request.FriendId,
                FriendId = user.Id,
                IsCloseFriend = request.IsCloseFriend,
                FriendshipStartDate = DateTime.UtcNow
            };

            await _friendRepository.AddFriendAsync(friend2);

            return new AddFriendResult { Message = "Succesfully added." };
        }
    }
}
