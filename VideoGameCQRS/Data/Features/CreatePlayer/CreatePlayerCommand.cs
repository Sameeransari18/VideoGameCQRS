using MediatR;
using VideoGameCQRS.Models;

namespace VideoGameCQRS.Data.Features.CreatePlayer
{
    public record CreatePlayerCommand(string Name, int Level):IRequest<Player>;
}
