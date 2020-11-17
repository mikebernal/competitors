using competitors.Models;
using Microsoft.EntityFrameworkCore;

namespace competitors.Data
{
  public class CompetitorsDbConnection : DbContext
  {
    public CompetitorsDbConnection(DbContextOptions<CompetitorsDbConnection> options) : base(options) {}
    public DbSet<Competitor> Competitors { get; set; }
  }
}