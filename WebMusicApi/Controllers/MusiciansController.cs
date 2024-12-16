using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]
public class MusiciansController : ControllerBase
{
    private readonly WebMusicAppContext _context;

    public MusiciansController(WebMusicAppContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Musician>>> GetMusicians()
    {
        return await _context.Musicians.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Musician>> GetMusician(int id)
    {
        var musician = await _context.Musicians.FindAsync(id);

        if (musician == null)
        {
            return NotFound();
        }

        return musician;
    }

    [HttpPost]
    public async Task<ActionResult<Musician>> PostMusician(Musician musician)
    {
        _context.Musicians.Add(musician);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetMusician", new { id = musician.Id }, musician);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutMusician(int id, Musician musician)
    {
        if (id != musician.Id)
        {
            return BadRequest();
        }

        _context.Entry(musician).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!MusicianExists(id))
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

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteMusician(int id)
    {
        var musician = await _context.Musicians.FindAsync(id);
        if (musician == null)
        {
            return NotFound();
        }

        _context.Musicians.Remove(musician);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool MusicianExists(int id)
    {
        return _context.Musicians.Any(e => e.Id == id);
    }
}