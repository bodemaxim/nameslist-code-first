using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NamesList.Context;
using NamesList.Models;

namespace NamesList.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NamesController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext; 

        public NamesController(ApplicationDbContext dbContext) 
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Get() 
        {
            var names = await _dbContext.Names.ToListAsync(); 
            return Ok(names);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id) 
        {
            var name = await _dbContext.Names.FindAsync(id); 
            if (name == null)
                return NotFound();

            return Ok(name);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Name name) 
        {
            _dbContext.Names.Add(name);
            await _dbContext.SaveChangesAsync(); 

            return CreatedAtAction(nameof(Get), new { id = name.Id }, name);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Name updatedName) 
        {
            var existingName = await _dbContext.Names.FindAsync(id); 
            if (existingName == null)
                return NotFound();

            existingName.FirstName = updatedName.FirstName;
            existingName.LastName = updatedName.LastName;

            await _dbContext.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id) 
        {
            var name = await _dbContext.Names.FindAsync(id); 
            if (name == null)
                return NotFound();

            _dbContext.Names.Remove(name);
            await _dbContext.SaveChangesAsync(); 
            return NoContent();
        }
    }
}
