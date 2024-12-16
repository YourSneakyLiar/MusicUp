using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]
public class ListenersController : ControllerBase
{
    private readonly WebMusicAppContext _context;

    public ListenersController(WebMusicAppContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Listener>>> GetListeners()
    {
        return await _context.Listeners.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Listener>> GetListener(int id)
    {
        var listener = await _context.Listeners.FindAsync(id);

        if (listener == null)
        {
            return NotFound();
        }

        return listener;
    }

    [HttpPost]
    public async Task<ActionResult<Listener>> PostListener(Listener listener)
    {
        _context.Listeners.Add(listener);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetListener", new { id = listener.Id }, listener);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutListener(int id, Listener listener)
    {
        if (id != listener.Id)
        {
            return BadRequest();
        }

        _context.Entry(listener).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ListenerExists(id))
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
    public async Task<IActionResult> DeleteListener(int id)
    {
        var listener = await _context.Listeners.FindAsync(id);
        if (listener == null)
        {
            return NotFound();
        }

        _context.Listeners.Remove(listener);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool ListenerExists(int id)
    {
        return _context.Listeners.Any(e => e.Id == id);
    }
}