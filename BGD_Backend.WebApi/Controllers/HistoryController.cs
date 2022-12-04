using System;
using BGD_Backend.WebApi.Data;
using BGD_Backend.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BGD_Backend.WebApi.Controllers
{
    [Route("api/history")]
    [ApiController]
    public class HistoryController : ControllerBase
    {
        private readonly InventoryDbContext _context;

        public HistoryController(InventoryDbContext context) => _context = context;
        
        [HttpGet]
        public async Task<IActionResult> Get() 
            => Ok(await _context.History.Include(c => c.Item).ToListAsync());
    }
}
