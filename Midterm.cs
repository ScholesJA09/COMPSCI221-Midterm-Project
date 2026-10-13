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
            //Book[] books = ReadBooksFromFile(path);
            //for (int i = 0; i < books.Length; i++)
            //{
            //    Console.WriteLine(books[i]);
            //}

            int number = 0;
            while (number != 9) //Loop until user selcets 9
            {

                //Listing out commands
                Console.WriteLine("Enter the corresponding number to execute the following command:");
                Console.WriteLine("(1) Print out all books");
                Console.WriteLine("(2) Print out all books available for check out");
                Console.WriteLine("(3) Print out all books by given author");
                Console.WriteLine("(4) Print out all books published on or after a given year");
                Console.WriteLine("(5) Sort all books by page length");
                Console.WriteLine("(6) Print out information about a single book given its title");
                Console.WriteLine("(7) Check out a book");
                Console.WriteLine("(8) Return a book");
                Console.WriteLine("(9) Quit");
                Console.WriteLine();

                //Determining number inputed
                number = int.Parse(Console.ReadLine());

                if (number > 9 || number < 1)
                {
                    throw new Exception("Number must be 1-9.");
                }

                if (number == 1)
                {
                    //Call function 1
                }
                else if (number == 2)
                {
                    //Call function 2
                }
                else if (number == 3)
                {
                    //Call function 2
                }
                else if (number == 4)
                {
                    //Call function 2
                }
                else if (number == 5)
                {
                    //Call function 2
                }
                else if (number == 6)
                {
                    //Call function 2
                }
                else if (number == 7)
                {
                    //Call function 2
                }
                else if (number == 8)
                {
                    //Call function 2
                }
            }
            Console.WriteLine("Come back soon!");
        }
    }
}