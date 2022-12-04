using System;
using BGD_Backend.WebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BGD_Backend.WebApi.Data
{
    public class InventoryDbContext : DbContext
    {
        public InventoryDbContext(DbContextOptions<InventoryDbContext> options)
            : base(options)
        {
            
        }
        
        public DbSet<Item> Items { get; set; }
        public DbSet<HistoryAction> History { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder){
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(InventoryDbContext).Assembly);
        }

     
    }
}
