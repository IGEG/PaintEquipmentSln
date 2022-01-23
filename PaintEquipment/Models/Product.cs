﻿using System.ComponentModel.DataAnnotations.Schema;
namespace PaintEquipment.Models
{
    public class Product
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        [Column(TypeName ="decimal(10,2)")]
        public decimal Price { get; set; }
        public string Category { get; set; }

    }
}