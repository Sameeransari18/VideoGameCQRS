using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using VideoGameCQRS.Models;

namespace VideoGameCQRS.Data.Features.GetPlayerById
{
    public class GetPlayerByIdQueryHandler : IRequestHandler<GetPlayerByIdQuery, Player>
    {
        private readonly VideoGameAppDbContext _context;

        public GetPlayerByIdQueryHandler(VideoGameAppDbContext context)
        {
            _context = context;
        }
        public async Task<Player> Handle(GetPlayerByIdQuery request, CancellationToken cancellationToken)
        {
            var player = await _context.Players.FindAsync(request.Id);
            return player;
        }
    }
}
