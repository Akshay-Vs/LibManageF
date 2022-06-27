using System;
using System.IO;
using System.Text;
using System.Text.Json;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Collections.Specialized;

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
        [JsonProperty("Title")]
        public string Title { get; set; }

        [JsonProperty("Author")]
        public string Author { get; set; }

        [JsonProperty("Publisher")]
        public string Publisher { get; set; }

        [JsonProperty("Price")]
        public int Price { get; set; }

        [JsonProperty("Pages")]
        public int Pages { get; set; }

        [JsonProperty("Availability")]
        public int Availability { get; set; }

        private string Url;

        //Constructure
        public Book() { }
        public Book(string url)
        {
            this.Url = url;
        }

        public void Add(string title, string author, string publisher, int price, int pages, int availability)
        {
            //Append new data to the database

            Book newData = new Book()
            {
                Title = title,
                Author = author,
                Publisher = publisher,
                Price = price,
                Pages = pages,
                Availability = availability
            };

            string jsonRaw = JsonConvert.SerializeObject(newData, Formatting.None);
            Console.WriteLine(jsonRaw);


            //Pust New data to database

        }

        public async Task GetList()
        {
            //Print all details about books to console
            var Response = await this.GetBooks();
            foreach (var i in Response)
            {
                Console.WriteLine($"Title: {i.Title}, Author: {i.Author}, Publisher: {i.Publisher}, Price: {i.Price}, Pages: {i.Pages}, Availability: {i.Availability}");
            }
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

        public async Task<Book[]> GetBooks()
        {
            HttpClient httpClient = new();

            var httpResponseMessage = await httpClient.GetAsync(this.Url);
            //Read string from the response's content
            string jsonResponse = await httpResponseMessage.Content.ReadAsStringAsync();
            //Console.WriteLine(jsonResponse);

            //Deserialize the json Response in to a C# array of type TypeBook
            Book[] JsonData =  JsonConvert.DeserializeObject<Book[]>(jsonResponse);

            httpClient.Dispose();
            return JsonData;

        }


        public async Task<string> Search(string nameOfBook)
        {
            var Response = await this.GetBooks();
            foreach(var i in Response)
            {
                if (i.Title == nameOfBook)
                {
                    return $"Title: {i.Title}, Author: {i.Author}, Publisher: {i.Publisher}, Price: {i.Price}, Pages: {i.Pages}, Availability: {i.Availability}";
                }
            }
            return $"{nameOfBook} is not found";
        }
    }

}