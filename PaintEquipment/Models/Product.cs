using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace PaintEquipment.Models
{
    public class Product
    {
        public long Id { get; set; }

        [Required(ErrorMessage = "Введите наименоваание товара")]
        public string Name { get; set; }

        public string URLadress { get; set; }

        [Required(ErrorMessage = "Укажите описание товара")]
        public string Description { get; set; }

        [Column(TypeName ="decimal(14,2)")]
        [Required]
        [Range(0.01, double.MaxValue,ErrorMessage = "Укажите стоимость товара")]
        public decimal Price { get; set; }

        public int? CategoryId { get; set; }

        [Required(ErrorMessage = "Укажите категорию")]
       
        public Category Category { get; set; }
        public string Img { get; set; }

    }
}
