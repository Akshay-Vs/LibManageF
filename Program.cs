using System;

namespace Library_Management_System
{
    class Program : IO
    {
        public static string username;
        public static string password;

        static void Main(string[] args)
        {
            Console.WriteLine(Environment.CurrentDirectory);
            username = Input("Enter Your Username: ");
            password = Input("Enter Password: ");
            Console.Clear();
            Print(username);
            Print(password);
        }
    }
}
