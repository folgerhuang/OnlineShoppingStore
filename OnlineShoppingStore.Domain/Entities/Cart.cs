using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShoppingStore.Domain.Entities
{
    public class Cart
    {
        private List<CartLine> lineCollection = new List<CartLine>();

        public void AddItem(Product product, int quanlity)
        {
            CartLine line = lineCollection.Where(p => p.Product.ProductID == product.ProductID).FirstOrDefault();
            if (line == null)
            {
                lineCollection.Add(
                    new CartLine{Product=product,Quanlity=quanlity});
            }
            else
            {
                line.Quanlity += quanlity;
            }
        }

        public void RemoveLine(Product product)
        {
            lineCollection.RemoveAll(p=>p.Product.ProductID==product.ProductID);
        }

        public decimal ComputeTotalValue()
        {
            return lineCollection.Sum(p => p.Product.Price * p.Quanlity);
        }

        public IEnumerable<CartLine> Lines
        {
            get { return lineCollection; }
        }

        public void Clear()
        {
            lineCollection.Clear();
        }
    }
}
