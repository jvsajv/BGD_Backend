using System;
using System.ComponentModel.DataAnnotations;
using BGD_Backend.WebApi.DTO;

namespace BGD_Backend.WebApi.Models
{
    public class Item
    {

        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int FixedQuantity { get; set; }
        public int ActualQuantity { get; set; }
        
        public ItemType ItemType { get; set; }

        public Item(ItemDTO itemDTO)
        {
            Name = itemDTO.Name;
            FixedQuantity = itemDTO.Quantity;
            ActualQuantity = itemDTO.Quantity;
            ItemType = itemDTO.Type;
        }
        
        public Item()
        {
        }
    }

    public enum ItemType
    {
        Ball, Accessory 
    }
}
