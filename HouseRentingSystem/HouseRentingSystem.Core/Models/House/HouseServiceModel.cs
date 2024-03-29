﻿using System.ComponentModel.DataAnnotations;

namespace HouseRentingSystem.Core.Models.House
{
    public class HouseServiceModel
    {
        public int Id { get; init; }

        public string Title { get; init; } = null!;

        public string Address { get; init; } = null!;

        [Display(Name = "Image URL")]
        public string ImageUrl { get; init; } = null!;

        [Display(Name = "Price Per Month")]
        public decimal PricePerMonth { get; set; }

        [Display(Name = "Is Rented")]
        public bool IsRented { get; init; } 
    }
}
