using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]
public class TracksController : ControllerBase
{
    private readonly WebMusicAppContext _context;

    public TracksController(WebMusicAppContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Track>>> GetTracks()
    {
        return await _context.Tracks.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Track>> GetTrack(int id)
    {
        var track = await _context.Tracks.FindAsync(id);

        if (track == null)
        {
            return NotFound();
        }

        return track;
    }

    [HttpPost]
    public async Task<ActionResult<Track>> PostTrack(Track track)
    {
        _context.Tracks.Add(track);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetTrack", new { id = track.Id }, track);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutTrack(int id, Track track)
    {
        if (id != track.Id)
        {
            return BadRequest();
        }

        _context.Entry(track).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!TrackExists(id))
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
    public async Task<IActionResult> DeleteTrack(int id)
    {
        var track = await _context.Tracks.FindAsync(id);
        if (track == null)
        {
            return NotFound();
        }

        _context.Tracks.Remove(track);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool TrackExists(int id)
    {
        return _context.Tracks.Any(e => e.Id == id);
    }
}