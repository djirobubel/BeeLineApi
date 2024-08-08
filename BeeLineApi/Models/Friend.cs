namespace BeeLineApi.Models
{
    public class Friend
    {
        public int Id { get; set; }
        public string? UserId { get; set; }
        public string? FriendId { get; set; }
        public bool IsCloseFriend { get; set; }
        public DateTime FriendshipStartDate { get; set; }
        public Profile? User { get; set; }
        public Profile? FriendProfile { get; set; }
    }
}
