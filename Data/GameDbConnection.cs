using competitors.Models;
using Microsoft.EntityFrameworkCore;

namespace games.Data
{
  public class GameDbConnection : DbContext
  {
    public  GameDbConnection(DbContextOptions<GameDbConnection> options) : base(options) {}
    public DbSet<Competitor> Competitors { get; set; }
  }
}