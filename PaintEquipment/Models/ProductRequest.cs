using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace PaintEquipment.Models

{
    public class ProductRequest
    {
        [BindNever]
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string Company { get; set; }
        [Required(ErrorMessage = "Введите имя")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Укажите адрес электронной почты")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Некорректный адрес")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Укажите номер телефона для обратной связи")]
        [Phone]
        public string Number { get; set; }
        [Required(ErrorMessage = "Необходимо указать вопрос")]
        public string Desc { get; set; }
    }
}
