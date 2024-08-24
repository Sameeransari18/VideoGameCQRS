using MediatR;
using Microsoft.EntityFrameworkCore;
using VideoGameCQRS.Models;

namespace VideoGameCQRS.Data.Features.GetPlayers
{
    public class GetPlayersQueryHandler : IRequestHandler<GetPlayersQuery, List<Player>>
    {
        private readonly VideoGameAppDbContext _context;

        public GetPlayersQueryHandler(VideoGameAppDbContext context)
        {
            _context = context;
        }
        public async Task<List<Player>> Handle(GetPlayersQuery request, CancellationToken cancellationToken)
        {
            var player = await _context.Players.ToListAsync();
            return player;
        }
    }
}
