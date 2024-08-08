using BeeLineApi.Commands.AddFriend;
using BeeLineApi.Commands.ChangeStatus;
using BeeLineApi.Commands.DeleteFriend;
using BeeLineApi.Queries.GetFriendProfile;
using BeeLineApi.Queries.GetUserProfile;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BeeLineApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

    public class FriendsController : Controller
    {
        private readonly IMediator _mediator;

        public FriendsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        //Метод просмотра списка друзей + информация о профиле.
        [HttpGet]
        [ProducesResponseType(typeof(GetUserProfileResult), 200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetUserProfile()
        {
            var result = await _mediator.Send(new GetUserProfileQuery(User.Identity.Name));
            return Ok(result);
        }

        //Метод просмотра детальной информации о друге.
        [HttpGet("{friendId}")]
        [ProducesResponseType(typeof(GetFriendProfileResult), 200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetFriendProfile(string friendId)
        {
            var result = await _mediator.Send(new GetFriendProfileQuery(friendId));
            return Ok(result);
        }

        //Метод добавления в друзья.
        [HttpPost]
        [ProducesResponseType(typeof(AddFriendResult), 204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> AddFriend([FromBody] AddFriendCommand command)
        {
            command.UserName = User.Identity.Name;
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        //Метод изменения статуса близкого друга.
        [HttpPut("{friendId}/status")]
        [ProducesResponseType(typeof(ChangeStatusResult), 204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> ChangeStatus(string friendId,
            [FromBody] ChangeStatusCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        //Метод удаления из друзей.
        [HttpDelete("{friendId}")]
        [ProducesResponseType(typeof(DeleteFriendResult), 204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> DeleteFriend(string friendId,
            [FromBody] DeleteFriendCommand command)
        {
            command.UserName = User.Identity.Name;
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
