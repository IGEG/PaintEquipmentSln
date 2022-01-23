using System;

namespace PaintEquipment.Models.ViewModels
{
    public class PageInfo
    {
        public int TotalProduct { get; set; }
        public int QuantityProductOnPage { set; get; }

        public int CurrentPage { set; get; }

        public int TotalPages => (int)Math.Ceiling((decimal)TotalProduct/QuantityProductOnPage);
    }
}
