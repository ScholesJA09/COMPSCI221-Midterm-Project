using System;
using System.IO;

namespace COMPSCI221_Midterm_Project
{
    static class Midterm
    {
        static int GetLineCount(string path)
        {
            if (!File.Exists(path))
            {
                throw new FileNotFoundException("File not found.", path);
            }
            int count = 0;
            using StreamReader reader = new StreamReader(path);
            while (!reader.EndOfStream)
            {
                reader.ReadLine();
                count++;
            }
            return count;
        }
        static Book[] ReadBooksFromFile(string path)
        {
            if (!File.Exists(path))
            {
                throw new FileNotFoundException("File not found.", path);
            }
            int lineCount = GetLineCount(path);
            Book[] books = new Book[lineCount - 1];
            using StreamReader reader = new StreamReader(path);
            reader.ReadLine();
            for (int i = 0; i < books.Length; i++)
            {
                string line = reader.ReadLine();
                string[] cols = line.Split(',');
                string title = cols[0];
                string author = cols[1];
                string genre = cols[2];
                int pageLength = int.Parse(cols[3]);
                int yearPublished = int.Parse(cols[4]);
                bool checkedOut = bool.Parse(cols[5]);
                books[i] = new Book(title, author, genre, pageLength, yearPublished, checkedOut);
            }
            return books;
        }

        static void Main()
        {
            string path = "books.csv";
            Book[] books = ReadBooksFromFile(path);
            for (int i = 0; i < books.Length; i++)
            {
                Console.WriteLine(books[i]);
            }
        }
    }
}