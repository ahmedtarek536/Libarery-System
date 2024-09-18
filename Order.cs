using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibarerySystem
{
    internal class Order
    {
        public User user { get; set; }
        public Book book;
        public bool isComplete;
        // false -> not return the book just borrow
        // true -> order done and he return the book
        public Order(User user, Book book, bool isComplete)
        {
            this.user = user;
            this.book = book;
            this.isComplete = isComplete;
        }

      
    }
}
