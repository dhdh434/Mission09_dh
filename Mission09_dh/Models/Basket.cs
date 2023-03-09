using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission09_dh.Models
{
    public class Basket
    {
        public List<BasketLineItem> Items { get; set; } = new List<BasketLineItem>();

        public void AddItem(Book bo, int qty)
        {
            //filter item
            BasketLineItem line = Items
                .Where(p => p.Book.BookId == bo.BookId)
                .FirstOrDefault();

            //check to see if item exists. if so then add to it, if not then create it
            if (line == null)
            {
                Items.Add(new BasketLineItem
                {
                    Book = bo,
                    Quantity = qty
                });
            }
            else
            {
                line.Quantity += qty;
            }
        }

        //calculate the total in cart
        public double CalculateTotal()
        {
            double sum = Items.Sum(x => x.Quantity * x.Book.Price);

            double sumRounded = Math.Round(sum, 2);

            return sumRounded;
        }
    }

    //items that go in the basket
    public class BasketLineItem
    {
        public int LineID { get; set; }
        public Book Book { get; set; }
        public int Quantity { get; set; }

    }
}
