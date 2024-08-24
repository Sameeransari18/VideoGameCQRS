using MediatR;

namespace VideoGameCQRS.Data.Features.DeletePlayer
{
    public class DeletePlayerCommandHandler : IRequestHandler<DeletePlayerCommand, string?>
    {
        private readonly VideoGameAppDbContext _context;

        public DeletePlayerCommandHandler(VideoGameAppDbContext context)
        {
            _context = context;
        }
        public async Task<string?> Handle(DeletePlayerCommand request, CancellationToken cancellationToken)
        {
            var player = await _context.Players.FindAsync(request.Id);

            if (player == null) { return null; }

            _context.Players.Remove(player);
            await _context.SaveChangesAsync();

            return "Player deleted successfully";
        }
    }
}
