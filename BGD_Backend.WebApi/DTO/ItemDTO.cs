using System;
using System.ComponentModel.DataAnnotations;
using BGD_Backend.WebApi.Models;

namespace BGD_Backend.WebApi.DTO
{
    public class ItemDTO
    {
        [Required]
        public string Name { get; set; }
        public int Quantity { get; set; }
        
        public ItemType Type { get; set; }

        public ItemDTO(Item item)
        {
            Name = item.Name;
            Quantity = item.FixedQuantity;
            Type = item.ItemType;
        }

        public ItemDTO()
        {
            
        }
    }
}
