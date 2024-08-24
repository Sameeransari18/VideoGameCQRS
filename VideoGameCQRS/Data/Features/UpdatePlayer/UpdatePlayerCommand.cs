using MediatR;

namespace VideoGameCQRS.Data.Features.UpdatePlayer
{
    public record UpdatePlayerCommand(int id, string Name, int Level) : IRequest<string?>;
}
