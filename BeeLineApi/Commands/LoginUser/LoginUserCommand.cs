using MediatR;

namespace BeeLineApi.Commands.LoginUser
{
    public class LoginUserCommand : IRequest<LoginUserResult>
    {
        public string? UserName { get; set; }
        public string? Password { get; set; }
    }
}
