using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibarerySystem
{
    internal class Book
    {
        public string Title;
        public string Author;
        public int Nums;
        public int Price;
       public Book(string title, string author, int price , int nums)
        {
            Title = title;
            Author = author;
            Nums = nums;
            Price = price;
        }
    }
}
