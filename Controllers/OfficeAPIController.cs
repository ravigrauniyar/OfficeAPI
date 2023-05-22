using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OfficeAPI.Data;
using OfficeAPI.Models;
using OfficeAPI.Models.Domain;


namespace OfficeAPI.Controllers
{
    [ApiController]
    [Route("todos/")]

    public class OfficeAPIController : Controller
    {
        private readonly DbContextAPI newItemContext;

        public OfficeAPIController(DbContextAPI newItemContext)
        {
            this.newItemContext = newItemContext;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateItemTodo incomingItem)
        {
            var newItem = new ItemTodo()
            {
                Id = Guid.NewGuid(),
                Title = incomingItem.Title,
                Description = incomingItem.Description
            };
            await newItemContext.ItemTodos.AddAsync(newItem);
            await newItemContext.SaveChangesAsync();
            return Ok(newItem);
        }

        [HttpGet]
        public async Task<IActionResult> Read()
        {
            var items = await newItemContext.ItemTodos.ToListAsync();
            return Ok(items);
        }

        [HttpGet]
        [Route("get")]
        public async Task<IActionResult> Details([FromQuery] Guid id)
        {
            var item = await newItemContext.ItemTodos.FindAsync(id);
            if (item != null)
            {
                return Ok(item);
            }
            return NotFound();
        }

        [HttpPut]
        [Route("put")]
        public async Task<IActionResult> Update([FromQuery] Guid id, UpdateItemTodo updateItem)
        {
            var item = await newItemContext.ItemTodos.FindAsync(id);

            if (item != null)
            {
                item.Title = updateItem.Title;
                item.Description = updateItem.Description;

                await newItemContext.SaveChangesAsync();
                return Ok(item);
            }
            return NotFound();
        }

        [HttpDelete]
        [Route("delete")]
        public async Task<IActionResult> Delete([FromQuery] Guid id)
        {
            var delItem = await newItemContext.ItemTodos.FindAsync(id);
            if (delItem != null)
            {
                newItemContext.ItemTodos.Remove(delItem);
                await newItemContext.SaveChangesAsync();
                return Ok();
            }
            return NotFound();
        }
    }
}
