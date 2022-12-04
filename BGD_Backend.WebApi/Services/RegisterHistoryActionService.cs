using System;
using BGD_Backend.WebApi.Data;
using BGD_Backend.WebApi.Models;

namespace BGD_Backend.WebApi.Services
{
    public class RegisterHistoryActionService
    {
        private readonly InventoryDbContext _context;

        public RegisterHistoryActionService(InventoryDbContext context) => _context = context;

        public async void RegisterHistoryAction(Item item, ActionType action){
            var historyAction = new HistoryAction();

            historyAction.Action = action;
            historyAction.UserId = 0;
            historyAction.Item = item;
            historyAction.ActionDate = DateTime.UtcNow;

            await _context.History.AddAsync(historyAction);
        }
    }
}
