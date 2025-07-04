﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApi.Domain.Entities
{
    /// <summary>
    /// Domain entity representing a restaurant menu item.
    /// </summary>
    public class MenuItem
    {
        public string Id { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal Price { get; set; }
        public string Category { get; set; } = null!;
        public bool IsAvailable { get; set; }
    }
}
