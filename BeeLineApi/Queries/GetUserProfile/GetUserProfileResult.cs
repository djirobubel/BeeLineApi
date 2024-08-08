using BeeLineApi.Dto;

namespace BeeLineApi.Queries.GetUserProfile
{
    public class GetUserProfileResult
    {
        public string? Id { get; set; }
        public string? Username { get; set; }
        public string? Email { get; set; }
        public List<FriendDto>? Friends { get; set; }
    }
}
