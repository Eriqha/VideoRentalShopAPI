using Microsoft.AspNetCore.Mvc;
using VideoRentalShopAPI.Data;
using VideoRentalShopAPI.Models;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]
public class RentalTransactionsController : ControllerBase
{
    private readonly VideoShopContext _context;

    public RentalTransactionsController(VideoShopContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<ActionResult<RentalDetail>> AddRental(RentalDetail rentalHeader)
    {
        _context.RentalTransactionDetails.Add(rentalHeader);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(AddRental), new { id = rentalHeader.RentalDetailId }, rentalHeader);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteRental(int id)
    {
        var transaction = await _context.RentalTransactions.Include(rt => rt.CustomerId)
           .FirstOrDefaultAsync(rt => rt.CustomerId == id);
        if (transaction == null)
            return NotFound();

        _context.RentalTransactions.Remove(transaction);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}
