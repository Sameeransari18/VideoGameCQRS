using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Numerics;
using VideoGameCQRS.Data;
using VideoGameCQRS.Data.Features.CreatePlayer;
using VideoGameCQRS.Data.Features.DeletePlayer;
using VideoGameCQRS.Data.Features.GetPlayerById;
using VideoGameCQRS.Data.Features.GetPlayers;
using VideoGameCQRS.Data.Features.UpdatePlayer;
using VideoGameCQRS.Models;

namespace VideoGameCQRS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private readonly ISender _sender;

        public PlayerController(VideoGameAppDbContext context, ISender sender)
        {
            _sender = sender;
        }

        [HttpPost("Add")]
        public async Task<IActionResult> CreatePlayer(CreatePlayerCommand request)
        {
            var player = await _sender.Send(request);
            return Ok(player);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPlayerById(int id)
        {
            Player player = await _sender.Send(new GetPlayerByIdQuery(id));

            if (player is null)
                return NotFound();

            return Ok(player);
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllPlayers()
        {
            List<Player> players = await _sender.Send(new GetPlayersQuery());

            if (players is null)
                return NotFound();

            return Ok(players);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<string>> DeletePlayer(int id)
        {
            var player = await _sender.Send(new DeletePlayerCommand(id));

            if (player is null) { return NotFound(); }

            return Ok(player);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<string>> UpdatePlayer(UpdatePlayerCommand command)
        {
            var player = await _sender.Send(command);

            if (player is null) { return NotFound(); };

            return Ok(player);
        }
    }
}
