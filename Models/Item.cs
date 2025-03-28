﻿using System.ComponentModel.DataAnnotations;

namespace eCashier.Models
{
    public class Item
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public int CategoryId { get; set; } // required foreign key
        public Category Category { get; set; } = null!; // required reference

        public int SKU { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int Price { get; set; }

        [Required]
        public int Tax { get; set; }

        [Display(Name = "Notification Emails")]
        public string NotificationEmails { get; set; }

        [Display(Name = "Internal Description")]
        public string InternalDescription { get; set; }
        [Display(Name = "External Description")]
        public string ExternalDescription { get; set; }

        [Display(Name = "Any price?")]
        public bool AllowAnyPrice { get; set; }

        [Display(Name = "Visible?")]
        public bool IsVisible { get; set; }
        public List<Order> Orders { get; } = [];

        //Navigation to join table
        public List<ItemOrder> ItemOrders { get; } = [];
    }
}
