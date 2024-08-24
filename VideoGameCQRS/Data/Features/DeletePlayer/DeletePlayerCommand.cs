using MediatR;

namespace VideoGameCQRS.Data.Features.DeletePlayer
{
    public record DeletePlayerCommand(int Id) : IRequest<string?>;
}
