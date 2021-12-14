using ASP.Net_Core_Project.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.Net_Core_Project.Models
{
    public class Cart
    {
        public Dictionary<int, CartItem> Items { get; set; }
        public Cart()
        {
            Items = new Dictionary<int, CartItem>();
        }

        public int Count
        {
            get
            {
                return Items.Sum(item => item.Value.Quantity);
            }
        }

        public double CalculateTotalPrice
        {
            get
            {
                return Items.Sum(item => item.Value.Quantity * item.Value.Book.Price);
            }
        }
        
        public virtual void AddToCart(Book book)
        {
            if (Items.ContainsKey(book.BookId))
                Items[book.BookId].Quantity++;
            else
                Items.Add(book.BookId, new CartItem
                {
                    Book = book,
                    Quantity = 1
                });
        }

        public virtual void RemoveFromCart(int id)
        {
            Items.Remove(id);
        }
        public virtual void ClearAll()
        {
            Items.Clear();
        }
    }

    public class CartItem
    {
        public Book Book { get; set; }
        public int Quantity { get; set; }
    }
}
