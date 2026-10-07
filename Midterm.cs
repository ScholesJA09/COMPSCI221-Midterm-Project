using System;
<<<<<<< HEAD
using System.IO;
=======
>>>>>>> 8d85eeb5c4cd174d42f8170218b8058b85d6bf0a

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
            Book[] movies = new Book[lineCount - 1];
            using StreamReader reader = new StreamReader(path);
            reader.ReadLine();
            for (int i = 0; i < movies.Length; i++)
            {
                string line = reader.ReadLine();
                string[] cols = line.Split(',');
                string title = cols[0];
                string directorLast = cols[1];
                string directorFirst = cols[2];
                int year = int.Parse(cols[3]);
                double rating = double.Parse(cols[4]);
                movies[i] = new Book(title, year, directorFirst, directorLast,rating);
            }
            return movies;
        }

        static void Main()
        {
<<<<<<< HEAD
            //Task 2/4
            string path = "books.csv";
            Book[] books = ReadBooksFromFile(path);
            for (int i = 0; i < books.Length; i++)
            {
                Console.WriteLine(books[i]);
            }
=======
            Console.WriteLine("Test");
>>>>>>> 8d85eeb5c4cd174d42f8170218b8058b85d6bf0a
        }
    }
}