using BeeLineApi.Interface;
using BeeLineApi.Service;
using MediatR;

namespace BeeLineApi.Commands.LoginUser
{
    public class LoginUserHandler : IRequestHandler<LoginUserCommand, LoginUserResult>
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtService _jwtService;

        public LoginUserHandler(IUserRepository userRepository, IJwtService jwtService)
        {
            _userRepository = userRepository;
            _jwtService = jwtService;
        }

        public async Task<LoginUserResult> Handle(LoginUserCommand request,
            CancellationToken cancellationToken)
        {
            var existingUser = await _userRepository.FindUserByNameAsync(request.UserName);

            if (existingUser == null)
                throw new ArgumentException("User not found.");

            var isPasswordCorrect = await _userRepository.CheckPasswordAsync(existingUser,
                request.Password);

            if (!isPasswordCorrect)
                throw new ArgumentException("Invalid Password.");

            var token = _jwtService.GenerateToken(existingUser);

            return new LoginUserResult { AccessToken = token };
        }
    }
}
