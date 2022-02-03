using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace PaintEquipment.Models
{
    public class Order
    {
        [BindNever]
        public int OrderId { get; set; }

        [BindNever]
        public ICollection<CartRow> Rows { get; set; }

        [BindNever]
        public bool Shipped { get; set; }

        [Required(ErrorMessage ="Укажите название компании")]
        public string NameCompany { get; set; }

        [Required(ErrorMessage ="Укажите Имя")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Уакжите номер телефона")]
        public string Number { get; set; }

        [Required(ErrorMessage = "Введите адрес электронной почты")]
        public string Email { get; set; }

        public string Adding{ get; set; }
       
       



    }
}
