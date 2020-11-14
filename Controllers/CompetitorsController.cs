using System.Threading.Tasks;
using games.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace competitors.Controllers
{
  // http://localhost:5000/api/competitors
  [Route("[api/controller]")]
  [ApiController]
  public class CompetitorsController : ControllerBase
  {
    private readonly GameDbConnection _context;
    public ILogger<CompetitorsController> _logger { get; }

    public CompetitorsController(
          GameDbConnection context,
          ILogger<CompetitorsController> logger
      )
      {
          _context = context;
          _logger = logger;
      }

    // Get api/competitors/5
    [HttpGet("{id}")]
    public async Task<IActionResult> GetCompetitor(int id)
    {
        var competitor = await _context.Competitors.FirstOrDefaultAsync(x => x.Id == id);
        return Ok(competitor);
    }

    // Get api/competitors
    [HttpGet]
    public async Task<IActionResult> GetCompetitors()
    {
        var competitors = await _context.Competitors.ToListAsync();
        return Ok(competitors);
    }

  }
}