using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]
public class ListensController : ControllerBase
{
    private readonly WebMusicAppContext _context;

    public ListensController(WebMusicAppContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Listen>>> GetListens()
    {
        return await _context.Listens.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Listen>> GetListen(int id)
    {
        var listen = await _context.Listens.FindAsync(id);

        if (listen == null)
        {
            return NotFound();
        }

        return listen;
    }

    [HttpPost]
    public async Task<ActionResult<Listen>> PostListen(Listen listen)
    {
        _context.Listens.Add(listen);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetListen", new { id = listen.Id }, listen);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutListen(int id, Listen listen)
    {
        if (id != listen.Id)
        {
            return BadRequest();
        }

        _context.Entry(listen).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ListenExists(id))
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
    public async Task<IActionResult> DeleteListen(int id)
    {
        var listen = await _context.Listens.FindAsync(id);
        if (listen == null)
        {
            return NotFound();
        }

        _context.Listens.Remove(listen);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool ListenExists(int id)
    {
        return _context.Listens.Any(e => e.Id == id);
    }
}