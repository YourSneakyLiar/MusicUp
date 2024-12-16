using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]
public class LikesController : ControllerBase
{
    private readonly WebMusicAppContext _context;

    public LikesController(WebMusicAppContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Like>>> GetLikes()
    {
        return await _context.Likes.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Like>> GetLike(int id)
    {
        var like = await _context.Likes.FindAsync(id);

        if (like == null)
        {
            return NotFound();
        }

        return like;
    }

    [HttpPost]
    public async Task<ActionResult<Like>> PostLike(Like like)
    {
        _context.Likes.Add(like);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetLike", new { id = like.Id }, like);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutLike(int id, Like like)
    {
        if (id != like.Id)
        {
            return BadRequest();
        }

        _context.Entry(like).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!LikeExists(id))
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
    public async Task<IActionResult> DeleteLike(int id)
    {
        var like = await _context.Likes.FindAsync(id);
        if (like == null)
        {
            return NotFound();
        }

        _context.Likes.Remove(like);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool LikeExists(int id)
    {
        return _context.Likes.Any(e => e.Id == id);
    }
}