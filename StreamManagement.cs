using System;
using System.IO;
using System.Text;
using System.Text.Json;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace Library_Management_System
{
    class IO
    {
        public static string Input(string str = "")
        {
            Console.Write(str);
            return Console.ReadLine();
        }


        public static void Print(string str = "")
        {
            Console.WriteLine(str);
        }

        public static void Print(float num)
        {
            Console.WriteLine(num);
        }

        public static void Print(int num)
        {
            Console.WriteLine(num);
        }

        public static void Print(double num)
        {
            Console.WriteLine(num);
        }

        public static void Print(char ch)
        {
            Console.WriteLine(ch);
        }

        public static void Print(bool val)
        {
            Console.WriteLine(val);
        }
    }

    public class Storage
    {
        string PathToDir;

        public Storage(string path)
        {
            PathToDir = path;
        }

        public void NewFile(string filename)
        {
            //Create New File
            using (FileStream fs = File.Create(this.PathToDir))
            {
                byte[] info = new UTF8Encoding(true).GetBytes("This is the file");
                fs.Write(info, 0, info.Length);
            }
        }

        public string[] Read(string filename)
        {

            return new[] { "" };
        }
    }

    public class Customer
    {
        private int TotalMembers;
        public string? Name { get; set; }
        public float Fees { get; set; }
        public int TotalBorrowedBooks { get; set; }
        public int TotalGivenBooks { get; set; }
        public int TotalPendings { get; set; }
        public int Penalties { get; set; }
        public int Status { get; set; }
        public Book BookDetails { get; }
        public DateTime Date { get; set; }
        public int ID
        {
            get { return ID; }
            set
            { //Set a unique identity to a new member
                if (ID > 100 && ID > TotalMembers) ID = value;
                else ID = TotalMembers++;
            }
        }

        string Path;
        public Customer(string path) //Constructor
        {
            //Create a new json file to store score details
            Path = path;
        }

        public string Write(Customer _json)
        //write json file to desired path
        {
            //string json = JsonSerializer.Serialize(_json);
            //File.WriteAllText(Path, json);
            return "\0";
        }

        public string[] Read(string path)
        {
            //Read json file from path

            var json = File.ReadAllText(path);
            //Customer? jsonFile = JsonSerializer.Deserialize<Customer>(json);

            /*string Player = jsonFile.Player;
            string Point = Convert.ToString(jsonFile.Point);
            string HighScore = Convert.ToString(jsonFile.HighScore);
            string Level = Convert.ToString(jsonFile.Level);
            */
            return new[] { "\0" };
        }
    }

    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public int Price { get; set; }
        public int Pages { get; set; }
        public int Availability { get; set; }

        public void Add(string title, string author, string publisher, int price, int pages, int availability)
        {
            this.Title = title;
            this.Author = author;
            this.Publisher = publisher;
            this.Price = price;
            this.Pages = pages;
            this.Availability = availability;

            //Pust New data to server
        }

        public string Get()
        {
            return ToString();
        }

        public string GetElement(string name)
        {
            //Return value of a specific element provided

            if (name.ToLower() == "title") return this.Title;
            else if (name.ToLower() == "author") return this.Author;
            else if (name.ToLower() == "price") return $"{this.Price}";
            else if (name.ToLower() == "pages") return $"{this.Pages}";
            else if (name.ToLower() == "availability") return $"{this.Availability}";
            else return $"Element {name} is invalid";
        }

        public static async Task<TypeBook[]> GetBooks(string url)
        {
            HttpClient httpClient = new();

            var httpResponseMessage = await httpClient.GetAsync(url);
            //Read string from the response's content
            string jsonResponse = await httpResponseMessage.Content.ReadAsStringAsync();
            //Console.WriteLine(jsonResponse);

            //Deserialize the json Response in to a C# array of type TypeBook
            TypeBook[] JsonData =  JsonConvert.DeserializeObject<TypeBook[]>(jsonResponse);

            httpClient.Dispose();
            return JsonData;

        }

        public string Formate()
        {
            return " " + ToString().Replace(',', '\n');
        }


        public override string ToString()
        {
            return $"Title:{Title}, Author: {Author}, Publisher: {Publisher}, Price: {Price}, Pages: {Pages}, Availability: {Availability}";
        }

    }

    public class DataStream
    {
        public static Book Serialize(string title, string author, string publisher, int price, int pages, int availability)
        {
            Book book = new Book();
            book.Add(title, author, publisher, price, pages, availability);
            return book;
        }

        public Book AvailableBooks()
        {
            string[] json;

            Storage Database = new Storage(Environment.CurrentDirectory);
            json = Database.Read($"{Environment.CurrentDirectory}\\Books.txt");
            return DataStream.Serialize(json[0], json[1], json[2], Int32.Parse(json[3]), Int32.Parse(json[4]), Int32.Parse(json[5]));
        }


    }
}