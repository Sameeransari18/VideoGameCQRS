using MediatR;
using VideoGameCQRS.Models;

namespace VideoGameCQRS.Data.Features.GetPlayers
{
    public record GetPlayersQuery:IRequest<List<Player>>;
}
