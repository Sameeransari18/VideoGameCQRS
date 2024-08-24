using MediatR;
using VideoGameCQRS.Models;

namespace VideoGameCQRS.Data.Features.UpdatePlayer
{
    public class UpdatePlayerCommanHandler : IRequestHandler<UpdatePlayerCommand, string?>
    {
        private readonly VideoGameAppDbContext _context;

        public UpdatePlayerCommanHandler(VideoGameAppDbContext context)
        {
            _context = context;
        }
        public async Task<string?> Handle(UpdatePlayerCommand request, CancellationToken cancellationToken)
        {
            var player = await _context.Players.FindAsync(request.id);
            if (player == null) { return null; }

            if (request.Name != null) { player.Name = request.Name; }
            if (request.Level != null) { player.Level = request.Level; }

            _context.Players.Update(player);
            await _context.SaveChangesAsync();

            return $"Player '{player.Name}' Updated Successfully!";

        }
    }
}
