using Microsoft.EntityFrameworkCore;

namespace nthAPIWeb.models;

public class PlayerContext : DbContext
{
    public PlayerContext(DbContextOptions<PlayerContext> options)
        : base(options)
    {
    }

    public DbSet<Player> Players { get; set; } = null!;
}