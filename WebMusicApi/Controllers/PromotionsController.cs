using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]
public class PromotionsController : ControllerBase
{
    private readonly WebMusicAppContext _context;

    public PromotionsController(WebMusicAppContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Promotion>>> GetPromotions()
    {
        return await _context.Promotions.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Promotion>> GetPromotion(int id)
    {
        var promotion = await _context.Promotions.FindAsync(id);

        if (promotion == null)
        {
            return NotFound();
        }

        return promotion;
    }

    [HttpPost]
    public async Task<ActionResult<Promotion>> PostPromotion(Promotion promotion)
    {
        _context.Promotions.Add(promotion);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetPromotion", new { id = promotion.Id }, promotion);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutPromotion(int id, Promotion promotion)
    {
        if (id != promotion.Id)
        {
            return BadRequest();
        }

        _context.Entry(promotion).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!PromotionExists(id))
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
    public async Task<IActionResult> DeletePromotion(int id)
    {
        var promotion = await _context.Promotions.FindAsync(id);
        if (promotion == null)
        {
            return NotFound();
        }

        _context.Promotions.Remove(promotion);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool PromotionExists(int id)
    {
        return _context.Promotions.Any(e => e.Id == id);
    }
}