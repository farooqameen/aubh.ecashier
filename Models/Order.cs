﻿using System.ComponentModel.DataAnnotations;

namespace eCashier.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int CustomerId { get; set; } // required foreign key
        public Customer Customer { get; set; } = null!; // required reference
        public int Reference { get; set; }

        [Display(Name = "Created on")]
        public DateTime CreatedOn { get; set; } = DateTime.Now;

        [Display(Name = "Expiry Date")]
        public DateTime? ExpiryDate { get; set; }

        [Display(Name = "Internal Note")]
        public string InternalNote { get; set; }

        [Display(Name = "Checkout URL")]
        public string CheckoutUrl { get; set; }
        public List<Item> Items { get; } = [];

        //Navigation to join table
        public List<ItemOrder> ItemOrders { get; } = [];
    }
}
