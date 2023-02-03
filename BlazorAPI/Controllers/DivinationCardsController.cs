using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BlazorAPI.Models;

namespace BlazorAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DivinationCardsController : ControllerBase
    {
        private readonly PoEDBContext _context;

        public DivinationCardsController(PoEDBContext context)
        {
            _context = context;
        }

        // GET: api/DivinationCards
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DivinationCard>>> GetDivinationCard()
        {
          if (_context.DivinationCard == null)
          {
              return NotFound();
          }
            return await _context.DivinationCard.ToListAsync();
        }

        // GET: api/DivinationCards/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DivinationCard>> GetDivinationCard(string id)
        {
          if (_context.DivinationCard == null)
          {
              return NotFound();
          }
            var divinationCard = await _context.DivinationCard.FindAsync(id);

            if (divinationCard == null)
            {
                return NotFound();
            }

            return divinationCard;
        }

        // PUT: api/DivinationCards/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDivinationCard(string id, DivinationCard divinationCard)
        {
            if (id != divinationCard.id)
            {
                return BadRequest();
            }

            _context.Entry(divinationCard).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DivinationCardExists(id))
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

        // POST: api/DivinationCards
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<DivinationCard>> PostDivinationCard(DivinationCard divinationCard)
        //{
        //  if (_context.DivinationCard == null)
        //  {
        //      return Problem("Entity set 'PoEDBContext.DivinationCard'  is null.");
        //  }
        //    _context.DivinationCard.Add(divinationCard);
        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateException)
        //    {
        //        if (DivinationCardExists(divinationCard.id))
        //        {
        //            return Conflict();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return CreatedAtAction("GetDivinationCard", new { id = divinationCard.id }, divinationCard);
        //}

        // POST: api/DivinationCards
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<List<DivinationCard>>> PostDivinationCards(List<DivinationCard> divinationCard)
        {
            if (_context.DivinationCard == null)
            {
                return Problem("Entity set 'PoEDBContext.DivinationCard'  is null.");
            }

            _context.DivinationCard.ExecuteDelete();

            foreach (var item in divinationCard)
            {
                _context.DivinationCard.Add(item);
            }
            
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
               
            }

            return Ok();
        }

        // DELETE: api/DivinationCards/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDivinationCard(string id)
        {
            if (_context.DivinationCard == null)
            {
                return NotFound();
            }
            var divinationCard = await _context.DivinationCard.FindAsync(id);
            if (divinationCard == null)
            {
                return NotFound();
            }

            _context.DivinationCard.Remove(divinationCard);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DivinationCardExists(string id)
        {
            return (_context.DivinationCard?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
