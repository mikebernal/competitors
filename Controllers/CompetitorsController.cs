using System;
using System.Net.Http;
using System.Threading.Tasks;
using competitors.Data;
using competitors.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace competitors.Controllers
{
  // http://localhost:5001/api/competitors
  [Route("api/[controller]")]
  [ApiController]
  public class CompetitorsController : ControllerBase
  {
    private readonly CompetitorsDbConnection _context;
    public ILogger<CompetitorsController> _logger { get; }

    public CompetitorsController(
          CompetitorsDbConnection context,
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

    // POST: api/competitors
    [HttpPost]
    public async Task<IActionResult> PostCompetitor(Competitor competitor)
    {
        _context.Competitors.Add(competitor);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetCompetitors", new { id = competitor.Id }, competitor);
    }

     // PUT: api/competitors/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutCompetitor(int id, Competitor competitor)
    {
        if (id != competitor.Id)
        {
            return BadRequest();
        }

        _context.Entry(competitor).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!await CompetitorExistsAsync(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

    // DELETE: api/games/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        _logger.LogInformation("Hello from Competitor Controllers' Delete Method");            

        var competitor = await _context.Competitors.FindAsync(id);
        
        if (competitor == null)
        {
            return NotFound();
        }

        _context.Competitors.Remove(competitor);
        await _context.SaveChangesAsync();

        return Ok(competitor);

    }

    private async Task<bool> CompetitorExistsAsync(int id) =>
      await _context.Competitors.AnyAsync(e => e.Id == id);

  }
}