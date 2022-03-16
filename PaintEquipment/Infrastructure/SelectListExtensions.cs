using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace PaintEquipment.Infrastructure
{
    public static class SelectListExtensions
    {
        public static IEnumerable<SelectListItem> ToSelectListItems<T>(this IEnumerable<T> Items)
        { 
        List<SelectListItem> selectListItems = new List<SelectListItem>();
            SelectListItem listItem = new SelectListItem
            {
                Text = "выберете категорию",
                Value = "0"
            };
            selectListItems.Add(listItem);
            foreach (var item in Items)
            {
                listItem = new SelectListItem
                {
                    Text = item.GetType().GetProperty("Name").GetValue(item, null).ToString(),
                    Value = item.GetType().GetProperty("Id").GetValue(item, null).ToString()
                };
                selectListItems.Add(listItem);
            }
            return selectListItems;
        }
    }
}
