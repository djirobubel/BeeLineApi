
namespace BeeLineApi.Dto
{
    public class UserDto
    {
        public string? Id { get; set; }
        public string? Username { get; set; }
        public string? Email { get; set; }
        public List<FriendDto>? Friends { get; set; }
    }
}
