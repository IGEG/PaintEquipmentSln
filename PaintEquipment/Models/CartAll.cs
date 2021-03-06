using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace PaintEquipment.Models
{
    public class CartAll
    {
        public List<CartRow> Rows { get; set; }=new List<CartRow>();
        public virtual void AddRow(Product product, int quantity)
        {
            CartRow row = Rows.Where(p => p.Product.Id == product.Id).FirstOrDefault();
            if (row == null)
            {
                Rows.Add(new CartRow
                {
                    Product = product,
                    Quantity = quantity
                });
            }
          
            else if (row.Quantity >= 1)
            {
                row.Quantity += quantity;
            }
            else
            {
                Rows.RemoveAll(p => p.Product.Id == product.Id);
            }
        }

        public virtual void DeleteOneRow(Product product,int quantity)
        {
            CartRow row = Rows.Where(p => p.Product.Id == product.Id).First();
        
            row.Quantity += quantity;

        }

        public virtual void DeleteRow(Product product)
        {
            Rows.RemoveAll(p => p.Product.Id == product.Id);
        }
        public decimal GetTotalSum()
        {
            // return Rows.Sum(p => p.Product.Price * p.Quantity);
            return 0;
        }
        public virtual void ClearCart() => Rows.Clear();
    
    }

    public class CartRow
    {
        public int Id { get; set; }
        
        public long? ProductId { get; set; }
        [ForeignKey("ProductId")]
        public Product Product { get; set; }

        public int Quantity { get; set; }

    }
}
