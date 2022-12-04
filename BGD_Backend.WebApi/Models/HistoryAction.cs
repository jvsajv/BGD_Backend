using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BGD_Backend.WebApi.Models
{
    public class HistoryAction
    {
        public int Id { get; set; }
        [Required]
        public ActionType Action { get; set; }

        [Required]
        public int UserId { get; set; }
        public Item Item {get; set;}

        public int ItemId {get; set;}
        
        [Required]
        public DateTime ActionDate {get; set;}
    }

    public enum ActionType {
        Withdraw, GiveBack, Register
    }
}
