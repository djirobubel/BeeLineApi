using BeeLineApi.Data;
using BeeLineApi.Interface;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BeeLineApi.Commands.ChangeStatus
{
    public class ChangeStatusHandler : IRequestHandler<ChangeStatusCommand,
        ChangeStatusResult>
    {
        private readonly IFriendRepository _friendRepository;
        private readonly DataContext _context;
        private readonly IUserRepository _userRepository;

        public ChangeStatusHandler(IFriendRepository friendRepository, DataContext context,
            IUserRepository userRepository)
        {
            _friendRepository = friendRepository;
            _context = context;
            _userRepository = userRepository;
        }

        public async Task<ChangeStatusResult> Handle(ChangeStatusCommand request,
            CancellationToken cancellationToken)
        {
            var friend = await _friendRepository.GetFriendByIdAsync(request.FriendId);

            friend.IsCloseFriend = request.IsCloseFriend;

            _context.Entry(friend).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return new ChangeStatusResult { Message = "Successfully updated" };
        }
    }
}
