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
            var watch = System.Diagnostics.Stopwatch.StartNew(); //Start timer

            try
            {
                Book book = new Book(bookURL);
                //string name = Input("Enter name of book: ");
                //Console.WriteLine("Searching...");
                //Console.WriteLine(await book.Search(name));

                book.Add("Wings of Fire", "APJ Abdul Kalam", "DC Books", 25, 180, 400);


            }

            catch (Exception error)
            {
                Console.WriteLine(error.Message);
            }

            watch.Stop();
            Print(watch.ElapsedMilliseconds);
        }
    }
}
