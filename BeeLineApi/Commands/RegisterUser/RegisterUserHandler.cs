using BeeLineApi.Dto;
using BeeLineApi.Interface;
using MediatR;

namespace BeeLineApi.Commands.RegisterUser
{
    public class RegisterUserHandler : IRequestHandler<RegisterUserCommand, RegisterUserResult>
    {
        private readonly IUserRepository _userRepository;

        public RegisterUserHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<RegisterUserResult> Handle(RegisterUserCommand request,
            CancellationToken cancellationToken)
        {
            var user = new RegisterUserDto
            {
                Email = request.Email,
                Username = request.Username,
                Password = request.Password
            };

            var result = await _userRepository.RegisterUserAsync(user);

            return new RegisterUserResult { IsRegistered = result };
        }
    }
}
