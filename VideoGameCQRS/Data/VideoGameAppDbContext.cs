using Microsoft.EntityFrameworkCore;
using VideoGameCQRS.Models;

namespace VideoGameCQRS.Data
{
    public class VideoGameAppDbContext : DbContext
    {
        public VideoGameAppDbContext(DbContextOptions option):base(option)
        {
            
        }

        public DbSet<Player> Players { get; set; }
    }
}
