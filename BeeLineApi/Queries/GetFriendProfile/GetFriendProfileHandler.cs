using BeeLineApi.Dto;
using BeeLineApi.Interface;
using BeeLineApi.Queries.GetUserProfile;
using MediatR;

namespace BeeLineApi.Queries.GetFriendProfile
{
    public class GetFriendProfileHandler : IRequestHandler<GetFriendProfileQuery,
        GetFriendProfileResult>
    {
        private readonly IUserRepository _userRepository;

        public GetFriendProfileHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<GetFriendProfileResult> Handle(GetFriendProfileQuery request, 
            CancellationToken cancellationToken)
        {
            var friend = await _userRepository.GetFriendProfileAsync(request.FriendId);

            var result = new GetFriendProfileResult
            {
                Id = friend.Id,
                Username = friend.UserName,
                Email = friend.Email,
                Friends = friend.Friends.Select(f =>
                new FriendDto
                {
                    Id = f.FriendProfile.Id,
                    Name = f.FriendProfile.UserName
                }).ToList()
            };

            return result;
        }
    }
}
