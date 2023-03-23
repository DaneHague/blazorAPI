using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BlazorAPI.Models;
using MyBackgroundWorkerService;

namespace BlazorAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrenciesController : ControllerBase
    {
        private readonly PoEDBContext _context;
        private readonly Worker _worker;

        public CurrenciesController(PoEDBContext context, Worker worker)
        {
            _context = context;
            _worker = worker;
        }

        [HttpPost("enqueue-task")]
        public IActionResult EnqueueTask([FromBody] string task)
        {
            _worker.EnqueueTask(task);
            return Ok("Task added to the queue.");
        }

        // GET: api/Currencies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Currency>>> GetCurrency()
        {
          if (_context.Currency == null)
          {
              return NotFound();
          }
            return await _context.Currency.ToListAsync();
        }

        // GET: api/Currencies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Currency>> GetCurrency(string id)
        {
          if (_context.Currency == null)
          {
              return NotFound();
          }
            var currency = await _context.Currency.FindAsync(id);

            if (currency == null)
            {
                return NotFound();
            }

            return currency;
        }

        // PUT: api/Currencies/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCurrency(string id, Currency currency)
        {
            if (id != currency.id)
            {
                return BadRequest();
            }

            _context.Entry(currency).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CurrencyExists(id))
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

        //// POST: api/Currencies
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<Currency>> PostCurrency(Currency currency)
        //{
        //  if (_context.Currency == null)
        //  {
        //      return Problem("Entity set 'PoEDBContext.Currency'  is null.");
        //  }
        //    _context.Currency.Add(currency);
        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateException)
        //    {
        //        if (CurrencyExists(currency.id))
        //        {
        //            return Conflict();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return CreatedAtAction("GetCurrency", new { id = currency.id }, currency);
        //}

        [HttpPost]
        public async Task<ActionResult<List<Currency>>> PostCurrencies(List<Currency> tst)
        {
            if (_context.Currency == null)
            {
                return Problem("Entity set 'PoEDBContext.DivinationCard'  is null.");
            }

            _context.Currency.ExecuteDelete();

            foreach (var item in tst)
            {
                _context.Currency.Add(item);
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

        // DELETE: api/Currencies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCurrency(string id)
        {
            if (_context.Currency == null)
            {
                return NotFound();
            }
            var currency = await _context.Currency.FindAsync(id);
            if (currency == null)
            {
                return NotFound();
            }

            _context.Currency.Remove(currency);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CurrencyExists(string id)
        {
            return (_context.Currency?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
