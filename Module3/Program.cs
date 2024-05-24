using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;


namespace modul3
{

    [Serializable]
    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int Year { get; set; }

        public Book(string title, string author, int year)
        {
            Title = title;
            Author = author;
            Year = year;
        }
        public Book()
        {
            Title = "default";
            Author = "default";
            Year = 0;
        }
    }

    class Program
    {
        static void Main()
        {
            string inputFilePath = "input.xml";
            string sortedXmlFilePath = "sorted_books.xml";
            string textFilePath = "books.txt";
            List<Book> books = LoadBooksFromXml(inputFilePath);

            var sortedBooks = books.OrderBy(b => b.Year).ToList();
            SaveBooksToXml(sortedBooks, sortedXmlFilePath);
            SaveBooksToTextFile(sortedBooks, textFilePath);

            Console.WriteLine("Done! Press enter to exit ...");
            Console.Read();
        }

        static List<Book> LoadBooksFromXml(string filePath)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Book>));
            using (FileStream fs = new FileStream(filePath, FileMode.Open))
            {
                return (List<Book>)serializer.Deserialize(fs);
            }
        }

        static void SaveBooksToXml(List<Book> books, string filePath)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Book>));
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                serializer.Serialize(writer, books);
            }
        }

        static void SaveBooksToTextFile(List<Book> books, string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (var book in books)
                {
                    writer.WriteLine($"Title: {book.Title} Author: {book.Author} Year: {book.Year}");
                }
            }
        }
    }
}
