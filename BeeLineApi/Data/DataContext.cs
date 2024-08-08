using BeeLineApi.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BeeLineApi.Data
{
    public class DataContext : IdentityDbContext<Profile>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DataContext()
        {

        }

        public DbSet<Friend> Friends { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Friend>()
                .HasKey(i => i.Id);
            modelBuilder.Entity<Friend>()
                .Property(f => f.FriendshipStartDate).HasDefaultValue(DateTime.UtcNow);

            modelBuilder.Entity<Friend>()
                .HasOne(f => f.User)
                .WithMany(f => f.Friends)
                .HasForeignKey(u => u.UserId);

            modelBuilder.Entity<Friend>()
                .HasOne(f => f.FriendProfile)
                .WithMany(f => f.FriendsTo)
                .HasForeignKey(u => u.FriendId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
