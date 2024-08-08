using Microsoft.AspNetCore.Identity;

namespace BeeLineApi.Models
{
    public class Profile : IdentityUser
    {
        public ICollection<Friend>? Friends { get; set; } = new List<Friend>();
        public ICollection<Friend>? FriendsTo { get; set; } = new List<Friend>();
    }
}
