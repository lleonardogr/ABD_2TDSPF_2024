using Microsoft.EntityFrameworkCore;
using PrimeiraAppWeb_2TDSPF.Models;

namespace PrimeiraAppWeb_2TDSPF.Data;

public class BoardgameDbContext : DbContext
{
    public DbSet<Boardgame> Boardgames { get; set; }

    public BoardgameDbContext(DbContextOptions<BoardgameDbContext> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Boardgame>().HasData(
            new Boardgame { Id = -1, Name = "Catan", Description = "Collect and trade resources to build up the island of Catan in this modern classic. " },
            new Boardgame { Id = -2, Name = "Carcassonne", Description = "Shape the medieval landscape of France, claiming cities, monasteries and farms. " },
            new Boardgame { Id = -3, Name = "Ticket to Ride", Description = "Build your railroad across North America to connect cities and complete tickets. " }
        );
    }
}