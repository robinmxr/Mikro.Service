using Microsoft.AspNetCore.Mvc;
using Mikro.Catalog.Service.Dtos;

namespace Mikro.Catalog.Service.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ItemsController : ControllerBase
    {
        private static readonly List<ItemDto> items = new()
        {
            new ItemDto(Guid.NewGuid(), "Gems", "Used to Buy Things", 9.99m, DateTimeOffset.UtcNow),
            new ItemDto(Guid.NewGuid(), "Tools", "Used to Build thi8ngs", 19.99m, DateTimeOffset.UtcNow),
            new ItemDto(Guid.NewGuid(), "Weapons", "Used to kill things", 29.99m, DateTimeOffset.UtcNow),
            new ItemDto(Guid.NewGuid(), "Food", "Used to fill hunger", 39.99m, DateTimeOffset.UtcNow)
        };

        [HttpGet]
        public IEnumerable<ItemDto> GetItems()
        {
            return items;
        }


        [HttpGet("{id}")]
        public ActionResult<ItemDto> GetItemById(Guid id)
        {
            var item = items.FirstOrDefault(item => item.Id == id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        [HttpPost]
        public ActionResult<ItemDto> CreateItem(CreateItemDto createItemDto)
        {
            var item = new ItemDto(Guid.NewGuid(), createItemDto.Name, createItemDto.Description, createItemDto.Price, DateTimeOffset.UtcNow);
            items.Add(item);
            return CreatedAtAction(nameof(GetItemById), new { id = item.Id }, item);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateItem(Guid id, UpdateItemDto updateItemDto)
        {
            var existingItem = items.FirstOrDefault(item => item.Id == id);
            if(existingItem is null)
            {
                return NotFound();
            }
            var updatedItem = existingItem with
            {
                Name = updateItemDto.Name,
                Description = updateItemDto.Description,
                Price = updateItemDto.Price,
            };
            var index = items.IndexOf(existingItem);
            items[index] = updatedItem; 

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteItem(Guid id)
        {
            var existingItem = items.FirstOrDefault(item => item.Id == id);
            if (existingItem is null)
            {
                return NotFound();
            }
            items.Remove(existingItem);
            return NoContent();
        }
    }
}
