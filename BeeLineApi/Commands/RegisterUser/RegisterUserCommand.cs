using MediatR;

namespace BeeLineApi.Commands.RegisterUser
{
    public class RegisterUserCommand : IRequest<RegisterUserResult>
    {
        public string? Email { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
    }
}
