using BGD_Backend.WebApi.Data;
using BGD_Backend.WebApi.DTO;
using BGD_Backend.WebApi.Models;
using BGD_Backend.WebApi.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BGD_Backend.WebApi.Controllers {

    [Route("api/items")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly InventoryDbContext _context;
        private readonly RegisterHistoryActionService _service;

        public ItemController(InventoryDbContext context, RegisterHistoryActionService service)
        {
            _context = context;
            _service = service;
        }

        [HttpGet]
        public async Task<List<Item>> Get() 
            => await _context.Items.ToListAsync();
        
        [HttpGet("id")]
        [ProducesResponseType(typeof(Item), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id){
            var item = await _context.Items.FindAsync(id);
            return item == null ? NotFound() : Ok(item);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Create(ItemDTO itemDTO){
           
            var item = new Item(itemDTO);

            await _context.Items.AddAsync(item);

            _service.RegisterHistoryAction(item, ActionType.Register);

            await _context.SaveChangesAsync();

            var responseItem = new ItemDTO(item);

            return CreatedAtAction(nameof(GetById), new {id = item}, item.Name);
        }
        
        [HttpPut("withdraw/id")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> WithdrawFromStock(int id){

            var item = await _context.Items.FindAsync(id);

            if(item == null || item.ActualQuantity == 0) return BadRequest();
            
            item.ActualQuantity = item.ActualQuantity - 1;

            _service.RegisterHistoryAction(item, ActionType.Withdraw);

            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpPut("giveback/id")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GiveBackFromStock(int id){

            var item = await _context.Items.FindAsync(id);
            if(item == null || item.ActualQuantity >= item.FixedQuantity) return BadRequest();
            
            item.ActualQuantity = item.ActualQuantity + 1;

            _service.RegisterHistoryAction(item, ActionType.GiveBack);

            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }


    }

}