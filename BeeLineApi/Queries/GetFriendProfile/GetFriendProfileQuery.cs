using MediatR;

namespace BeeLineApi.Queries.GetFriendProfile
{
    public class GetFriendProfileQuery : IRequest<GetFriendProfileResult>
    {
        public string FriendId { get; set; }

        public GetFriendProfileQuery(string friendId)
        {
            FriendId = friendId;
        }
    }
}
