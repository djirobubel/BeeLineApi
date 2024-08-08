using MediatR;

namespace BeeLineApi.Queries.GetUserProfile
{
    public class GetUserProfileQuery : IRequest<GetUserProfileResult>
    {
        public string UserName { get; set; }

        public GetUserProfileQuery(string userName)
        {
            UserName = userName;
        }
    }
}
