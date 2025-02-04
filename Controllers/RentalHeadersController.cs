using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VideoRentalShopAPI.Models;
using VideoShopRentalAPIv3.Data;

namespace VideoRentalShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentalHeadersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public RentalHeadersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/RentalHeaders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RentalHeader>>> GetRentals()
        {
            return await _context.RentalHeaders.ToListAsync();
        }

        // GET: api/RentalHeaders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RentalHeader>> GetRentalHeader(int? id)
        {
            var rentalHeader = await _context.RentalHeaders.FindAsync(id);

            if (rentalHeader == null)
            {
                return NotFound();
            }

            return rentalHeader;
        }

        // PUT: api/RentalHeaders/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRentalHeader(int? id, RentalHeader rentalHeader)
        {
            if (id != rentalHeader.RentalHeaderId)
            {
                return BadRequest();
            }

            _context.Entry(rentalHeader).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RentalHeaderExists(id))
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

        // POST: api/RentalHeaders
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<RentalHeader>> PostRentalHeader(RentalHeader rentalHeader)
        {
            _context.RentalHeaders.Add(rentalHeader);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRentalHeader", new { id = rentalHeader.RentalHeaderId }, rentalHeader);
        }

        // DELETE: api/RentalHeaders/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRentalHeader(int? id)
        {
            var rentalHeader = await _context.RentalHeaders.FindAsync(id);
            if (rentalHeader == null)
            {
                return NotFound();
            }

            _context.RentalHeaders.Remove(rentalHeader);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RentalHeaderExists(int? id)
        {
            return _context.RentalHeaders.Any(e => e.RentalHeaderId == id);
        }
    }
}
