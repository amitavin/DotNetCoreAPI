using Microsoft.AspNetCore.Mvc;
using RestaurantApi.API.Models;
using RestaurantApi.Application.Services;
using RestaurantApi.Domain.Entities;

namespace RestaurantApi.API.Controllers
{
    /// <summary>
    /// API endpoints for managing restaurant menu items.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class MenuItemsController : ControllerBase
    {
        private readonly MenuItemService _service;
        private readonly ILogger<MenuItemsController> _logger;

        public MenuItemsController(MenuItemService service, ILogger<MenuItemsController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var items = await _service.GetAllAsync();
            _logger.LogInformation("Fetched {Count} menu items.", items.Count);
            return Ok(items);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var item = await _service.GetByIdAsync(id);
            if (item == null)
                return NotFound();

            return Ok(item);
        }

        [HttpPost]
        public async Task<IActionResult> Create(MenuItemDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var newItem = new MenuItem
            {
                Name = dto.Name,
                Description = dto.Description,
                Price = dto.Price,
                Category = dto.Category,
                IsAvailable = dto.IsAvailable
            };

            await _service.CreateAsync(newItem);

            return CreatedAtAction(nameof(GetById), new { id = newItem.Id }, newItem);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, MenuItem item)
        {
            item.Id = id;
            await _service.UpdateAsync(item);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }

        [HttpGet("test-error")]
        public IActionResult TestError()
        {
            throw new Exception("Test exception thrown!");
        }

    }
}
