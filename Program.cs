using System;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace Library_Management_System
{
    class Program : IO
    {
        public static string username;
        public static string password;

        static public string bookURL = @"https://raw.githubusercontent.com/Akshay-Vs/LibManage/master/Data/Books.json";

        static async Task Main(string[] args)
        {
            try
            {
                Book book = new Book();
                var Response = await Book.GetBooks(bookURL);

                foreach (var i in Response)
                {
                    Console.WriteLine($"{i.Title}, {i.Author}, {i.Publisher}, {i.Price}, {i.Pages}, {i.Availability}");
                }
            }

            catch (Exception error)
            {
                Console.WriteLine(error.Message);
            }

            
        }
    }
}
