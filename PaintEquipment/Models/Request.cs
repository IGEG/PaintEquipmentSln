using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace PaintEquipment.Models
{
    public class Request
    {
        [BindNever]
        public int Id { get; set; }

        public string Company { get; set; }
        [Required(ErrorMessage = "Введите имя")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Укажите адрес электронной почты")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Некорректный адрес")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Укажите номер телефона для обратной связи")]
        [Phone]
        public string  Number { get; set; }
        [Required(ErrorMessage ="Необходимо указать запрос")]
        public string  Desc { get; set; }

    }
}
