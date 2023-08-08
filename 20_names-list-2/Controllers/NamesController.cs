using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore; // Добавим этот using
using NamesList.Context; // Импортируем контекст базы данных
using NamesList.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks; // Добавим этот using

namespace NamesList.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NamesController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext; // Изменяем поле для использования контекста

        public NamesController(ApplicationDbContext dbContext) // Внедряем контекст в конструктор
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Get() // Изменяем на асинхронный метод
        {
            var names = await _dbContext.Names.ToListAsync(); // Извлекаем данные из базы данных асинхронно
            return Ok(names);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id) // Изменяем на асинхронный метод
        {
            var name = await _dbContext.Names.FindAsync(id); // Извлекаем данные из базы данных асинхронно
            if (name == null)
                return NotFound();

            return Ok(name);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Name name) // Изменяем на асинхронный метод
        {
            _dbContext.Names.Add(name);
            await _dbContext.SaveChangesAsync(); // Сохраняем изменения в базе данных асинхронно

            return CreatedAtAction(nameof(Get), new { id = name.Id }, name);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Name updatedName) // Изменяем на асинхронный метод
        {
            var existingName = await _dbContext.Names.FindAsync(id); // Извлекаем данные из базы данных асинхронно
            if (existingName == null)
                return NotFound();

            existingName.FirstName = updatedName.FirstName;
            existingName.LastName = updatedName.LastName;

            await _dbContext.SaveChangesAsync(); // Сохраняем изменения в базе данных асинхронно

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id) // Изменяем на асинхронный метод
        {
            var name = await _dbContext.Names.FindAsync(id); // Извлекаем данные из базы данных асинхронно
            if (name == null)
                return NotFound();

            _dbContext.Names.Remove(name);
            await _dbContext.SaveChangesAsync(); // Сохраняем изменения в базе данных асинхронно

            return NoContent();
        }
    }
}
