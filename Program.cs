using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LibarerySystem
{
    internal class Program
    {
        static public List<Book> Books = new List<Book>(); 
        static public List<User> Users = new List<User>();
        static public List<Order> Orders = new List<Order>();

        static void Main(string[] args)
        {
            
            MainSystem();
        }
        static void MainSystem()
        {
            Console.WriteLine();
            Console.WriteLine("1. Manage Books");
            Console.WriteLine("2. Manage Users");
            Console.WriteLine("3. Exit");
            Console.Write("Enter Action: ");
            int action = Convert.ToInt32(Console.ReadLine());
            switch (action)
            {
                case 1:
                    ManageBooks();
                    break;
                case 2:
                    ManageUsers();
                    break;
                case 3:
                    Console.WriteLine("Thank for use system.");
                    break;
                default:
                    Console.WriteLine("Please Enter Valid Action???");
                    MainSystem();
                    break;
            }
        }
        static void ManageUsers() {
            Console.WriteLine();
            Console.WriteLine("1. Add user");
            Console.WriteLine("2. Delete user");
            Console.WriteLine("3. Print All Users");
            Console.WriteLine("4. Back");
            Console.Write("Enter Action: ");
            int action = Convert.ToInt32(Console.ReadLine());
            switch (action)
            {
                case 1:
                    AddUser();
                    ManageUsers();
                    break;
                case 2:
                    DeleteUser();
                    ManageUsers();
                    break;
                case 3:
                    PrintAllUsers();
                    ManageUsers();
                    break;
                case 4:
                    MainSystem();
                    break;
                default:
                    Console.WriteLine("Please Enter Vaild Action..");
                    ManageUsers();
                    break;
            }
           
        }
        static void AddUser() {

            Console.WriteLine();
            Console.Write("Enter FullName: ");
            string fullName = Console.ReadLine();
            Console.Write("Enter ID: ");
            string id = Console.ReadLine();
            User CurrentUser = Users.Find(user => user.Id == id);
            if(CurrentUser != null) Console.WriteLine("This user already have account.");
            else
            {
                Users.Add(new User(fullName, id));
                Console.WriteLine("Successfull Add User");
            }
        }
        static void DeleteUser() {
            Console.WriteLine();
            Console.Write("Enter ID Of User: ");
            string id = Console.ReadLine();
            User CurrentUser = Users.Find(user => user.Id == id);
            if (CurrentUser != null)
            {
                Users.Remove(CurrentUser);
                Console.WriteLine("Successfull Remove User");
            }
            else Console.WriteLine("This user not found");
           
        }
        static void PrintAllUsers() {
            Console.WriteLine();
            Console.WriteLine("Users: ");
            foreach (User user in Users)
            {
                Console.WriteLine($"\tName: {user.FullName} ,  ID: {user.Id} ");
            }
        }
        static void ManageBooks()
        {
            Console.WriteLine();
            Console.WriteLine("1. Add New Book");
            Console.WriteLine("2. Remove Book");
            Console.WriteLine("3. Borrow Book");
            Console.WriteLine("4. Return Book");
            Console.WriteLine("5. Show All Books");
            Console.WriteLine("6. Show All Orderes");
            Console.WriteLine("7. Back");
            Console.Write("Enter Action: ");
            int action = Convert.ToInt32(Console.ReadLine());
            switch (action)
            {
               
                case 1:
                    AddNewBook();
                    ManageBooks();

                    break;
                case 2:
                    RemoveBook();
                    ManageBooks();

                    break;
                case 3:
                    BorrowBook();
                    ManageBooks();

                    break;
                case 4: 
                    ReturnBook();
                    ManageBooks();

                    break;
                case 5:
                    PrintAllBooks();
                    ManageBooks();

                    break;
                case 6:
                    PrintOrdersNotComplete();
                    ManageBooks();

                    break;
                case 7:
                    MainSystem();
                    break;
        
                default:
                    Console.WriteLine();
                    Console.WriteLine("Pleas Enter Vaild Action???");
                    ManageBooks();
                    break;
            }
        }
        static void AddNewBook() {
            Console.WriteLine();
            Console.Write("Enter Title Of Book: ");
            string title = Console.ReadLine();
            Console.Write("Enter Author Of Book: ");
            string author = Console.ReadLine();
            Console.Write("Enter Price Of Book: ");
            int price = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Number Of Copies: ");
            int nums = Convert.ToInt32(Console.ReadLine());
        
            Books.Add(new Book(title, author , price , nums));
            Console.WriteLine("Add Book Successful");
        }
        static void RemoveBook() {

            Console.WriteLine();
            Console.Write("Enter Title Of Book: ");
            string title = Console.ReadLine();
            Book CurrentBook = Books.Find(book => book.Title == title);
            if(CurrentBook != null)
            {
                Books.Remove(CurrentBook);
                Console.WriteLine("Successful Remove Book");
            }
            else
            {
                Console.WriteLine("Please Enter vaild Book.");
            }
        }
        static void BorrowBook()
        {
            Console.WriteLine();
            Console.Write("Enter Title Of Book: ");
            string title = Console.ReadLine();
            Console.Write("Enter Id of User: ");
            string id = Console.ReadLine();

            Book CurrentBook = Books.Find(book => book.Title == title);
            User CurrentUser = Users.Find(user => user.Id == id);
            if (CurrentBook != null && CurrentUser != null )
            {
                if (CurrentBook.Nums > 1)
                {
                    CurrentBook.Nums -= 1;
                    Orders.Add(new Order(CurrentUser, CurrentBook, false));
                    Console.WriteLine("Borrow Book Successful");
                }
                else Console.WriteLine("This Book Sold Out");
            }
            else
            {
                Console.WriteLine("Book Or User Not Found");
            }
        }
        static void ReturnBook()
        {
            Console.WriteLine();
            Console.Write("Enter Title Of Book: ");
            string title = Console.ReadLine();
            Console.Write("Enter Id of User: ");
            string id = Console.ReadLine();

            Book CurrentBook = Books.Find(book => book.Title == title);
            User CurrentUser = Users.Find(user => user.Id == id);
            if (CurrentBook != null && CurrentUser != null)
            {
                Order currentOrder = Orders.Find(order => order.user == CurrentUser && order.book == CurrentBook);
                if(currentOrder != null)
                {
                CurrentBook.Nums += 1;
                    currentOrder.isComplete = true;
                    Console.WriteLine("Return Book Successful");
                }else Console.WriteLine("Order Not Found");
            }
            else
            {
                Console.WriteLine("Book Or User Not Found");
              
            }
        }
        static void PrintAllBooks()
        {
            Console.WriteLine();
            Console.WriteLine("Books: ");
            foreach(Book book in Books)
            {
                Console.WriteLine($"\tTitle: {book.Title} ,  Author: {book.Author} ,  Nums: {book.Nums}");
            }
        }
        static void PrintOrdersNotComplete() {

            Console.WriteLine();
            Console.WriteLine("Orders: ");
            foreach (Order order in Orders)
            {
                if(order.isComplete == false)
                {
                    Console.WriteLine($"/tTitle: {order.book.Title} ,  User: {order.user.FullName} .");
                }
            }
        }
        static void PrintOrdersComplete() {

            Console.WriteLine();
            Console.WriteLine("Orders: ");
            foreach (Order order in Orders)
            {
                if (order.isComplete == true)
                {
                    Console.WriteLine($"/tTitle: {order.book.Title} ,  User: {order.user.FullName} .");
                }
            }

        } 
    }
}

/*
 * books 
 * users
 * search by book using complex like trie
 * sorted and catogries
 * 
*/