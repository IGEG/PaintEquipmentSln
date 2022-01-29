using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace PaintEquipment.Models
{
    public class Order
    {
        [BindNever]
        public int OrderId { get; set; }
        [BindNever]
        public ICollection<CartRow> Rows { get; set; }
        [Required(ErrorMessage ="Введите имя")]
        public string Name { get; set; }
        [Required(ErrorMessage ="Введите адрес")]
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string Line3 { get; set; }
        [Required(ErrorMessage = "Введите название города")]
        public string City { get; set; }
        [Required(ErrorMessage = "Введите регион страны")]
        public string State { get; set; }
        public string Zip { get; set; }
        [Required(ErrorMessage = "Введите название страны")]
        public string Country { get; set; }
        public bool GiftWrap { get; set; }



    }
}
