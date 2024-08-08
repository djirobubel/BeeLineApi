using BeeLineApi.Dto;

namespace BeeLineApi.Queries.GetFriendProfile
{
    public class GetFriendProfileResult
    {
        public string? Id { get; set; }
        public string? Username { get; set; }
        public string? Email { get; set; }
        public List<FriendDto>? Friends { get; set; }
    }
}
