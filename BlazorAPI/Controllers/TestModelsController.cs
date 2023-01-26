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
    public class TestModelsController : ControllerBase
    {
        private readonly PoEDBContext _context;

        public TestModelsController(PoEDBContext context)
        {
            _context = context;
        }

        // GET: api/TestModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TestModel>>> GetTestModel()
        {
          if (_context.TestModel == null)
          {
              return NotFound();
          }
            return await _context.TestModel.ToListAsync();
        }

        // GET: api/TestModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TestModel>> GetTestModel(int id)
        {
          if (_context.TestModel == null)
          {
              return NotFound();
          }
            var testModel = await _context.TestModel.FindAsync(id);

            if (testModel == null)
            {
                return NotFound();
            }

            return testModel;
        }

        // PUT: api/TestModels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTestModel(int id, TestModel testModel)
        {
            if (id != testModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(testModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TestModelExists(id))
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

        // POST: api/TestModels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TestModel>> PostTestModel(TestModel testModel)
        {
          if (_context.TestModel == null)
          {
              return Problem("Entity set 'PoEDBContext.TestModel'  is null.");
          }
            _context.TestModel.Add(testModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTestModel", new { id = testModel.Id }, testModel);
        }

        // DELETE: api/TestModels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTestModel(int id)
        {
            if (_context.TestModel == null)
            {
                return NotFound();
            }
            var testModel = await _context.TestModel.FindAsync(id);
            if (testModel == null)
            {
                return NotFound();
            }

            _context.TestModel.Remove(testModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TestModelExists(int id)
        {
            return (_context.TestModel?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
