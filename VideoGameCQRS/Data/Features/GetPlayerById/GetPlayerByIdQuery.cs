using MediatR;
using VideoGameCQRS.Models;

namespace VideoGameCQRS.Data.Features.GetPlayerById
{
    public record GetPlayerByIdQuery(int Id) : IRequest<Player>;
}
