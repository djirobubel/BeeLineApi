using BeeLineApi.Dto;
using BeeLineApi.Interface;
using MediatR;

namespace BeeLineApi.Queries.GetUserProfile
{
    public class GetUserProfileHandler : IRequestHandler<GetUserProfileQuery,
        GetUserProfileResult>
    {
        private readonly IUserRepository _userRepository;

        public GetUserProfileHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<GetUserProfileResult> Handle(GetUserProfileQuery request,
            CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserProfileAsync(request.UserName);

            var result = new GetUserProfileResult
            {
                Id = user.Id,
                Username = user.UserName,
                Email = user.Email,
                Friends = user.Friends.Select(f =>
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
