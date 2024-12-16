using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]
public class DonationsController : ControllerBase
{
    private readonly WebMusicAppContext _context;

    public DonationsController(WebMusicAppContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Donation>>> GetDonations()
    {
        return await _context.Donations.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Donation>> GetDonation(int id)
    {
        var donation = await _context.Donations.FindAsync(id);

        if (donation == null)
        {
            return NotFound();
        }

        return donation;
    }

    [HttpPost]
    public async Task<ActionResult<Donation>> PostDonation(Donation donation)
    {
        _context.Donations.Add(donation);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetDonation", new { id = donation.Id }, donation);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutDonation(int id, Donation donation)
    {
        if (id != donation.Id)
        {
            return BadRequest();
        }

        _context.Entry(donation).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!DonationExists(id))
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
    public async Task<IActionResult> DeleteDonation(int id)
    {
        var donation = await _context.Donations.FindAsync(id);
        if (donation == null)
        {
            return NotFound();
        }

        _context.Donations.Remove(donation);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool DonationExists(int id)
    {
        return _context.Donations.Any(e => e.Id == id);
    }
}