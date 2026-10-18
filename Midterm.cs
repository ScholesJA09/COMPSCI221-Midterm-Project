using System;
using System.IO;
using System.Security.Policy;

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
        static void PrintBooks(string path)
        {
            Book[] books = ReadBooksFromFile(path);
            for (int i = 0; i < books.Length; i++)
            {
                Console.WriteLine(books[i]);
            }
        }
        static void PrintBooksAvailable(string path)
        {
            Book[] books = ReadBooksFromFile(path);
            for (int i = 0; i < books.Length; i++)
            {
                if (!books[i].CheckedOut)
                {
                    Console.WriteLine(books[i]);
                }
            }
        }
        static void PrintBooksByAuthor(string path, string author)
        {
            Book[] books = ReadBooksFromFile(path);
            bool foundAuthor = false;
            for (int i = 0; i < books.Length; i++)
            {
                if (books[i].Author == author)
                {
                    Console.WriteLine(books[i]);
                    foundAuthor = true;
                }
            }
            if (!foundAuthor)
            {
                Console.WriteLine($"No books written by {author}.");
            }
        }
        static void SortBooksByTitle(string path)
        {
            Book[] books = ReadBooksFromFile(path);
            for (int i = 0; i < books.Length - 1; i++)
            {
                int minIndex = i;

                for (int j = i + 1; j < books.Length; j++)
                {
                    if (books[j].Title.CompareTo(books[minIndex].Title) < 0)
                    {
                        minIndex = j;
                    }
                }

                if (i != minIndex)
                {
                    (books[i], books[minIndex]) = (books[minIndex], books[i]);
                }
            }

            for (int i = 0; i < books.Length; i++)
            {
                Console.WriteLine(books[i]);
            }
        }

        static void PrintBooksByYear(string path, int year) {
			Book[] books = ReadBooksFromFile(path);
            bool foundYear = false;
            for (int i = 0; i < books.Length; i++) {
                if (books[i].YearPublished >= year) {
                    Console.WriteLine(books[i]);
                    foundYear = true;
                }
            }
            if (!foundYear) {
                Console.WriteLine($"No books were published on or after {year}");
            }
		}
        static void SortBooksByPages(string path) {
            Book[] books = ReadBooksFromFile(path);

            for (int i = 1; i < books.Length; i++) {
                int j = i;
                Book tempBook = books[i];
                while (j > 0 && tempBook.PageLength > books[j-1].PageLength) {
                    books[j] = books[j - 1];
                    j--;
                }
                books[j] = tempBook;
            }
            for (int i = 0; i < books.Length; i++) {
                Console.WriteLine(books[i]);
            }
        }
		static void PrintBookByTitle(string path, string title) {
            Book[] books = ReadBooksFromFile(path);
            int i = 0;
            int bookID = -1;
            while (i < books.Length) {
                if (books[i].Title.ToLower() == title.ToLower()) {
                    bookID = i;
                    i = books.Length;
                }
                i++;
            }
            if (bookID > -1) {
                Console.WriteLine(books[bookID]);
            } else {
                Console.WriteLine($"Couldn't find a book with the title \"{title}\"");
            }
        }
        static void DonateBook(string path) {
            Book[] books = ReadBooksFromFile(path);
			using StreamWriter writer = new StreamWriter(path);
            writer.WriteLine("Title,Author,Genre,Page Length,Year Published,Checked Out");
			for (int i = 0; i < books.Length; i++) {
                writer.WriteLine($"{books[i].Title},{books[i].Author},{books[i].Genre},{books[i].PageLength},{books[i].YearPublished},False");
            }
            Console.Write("Book title: ");
            string title = Console.ReadLine();
            Console.Write("Book author: ");
            string author = Console.ReadLine();
			Console.Write("Book genre: ");
			string genre = Console.ReadLine();
			Console.Write("Page length: ");
			int pages = int.Parse(Console.ReadLine());
			Console.Write("Year published: ");
			int year = int.Parse(Console.ReadLine());
            writer.WriteLine($"{title},{author},{genre},{pages},{year},False");
            Book temp = new Book(title, author, genre, pages, year, false);
            Console.WriteLine($"You successfully donated the following book:\n{temp}");
		}


		static void Main()
        {
            string path = "books.csv";

            int number = 0;
            while (number != 11) //Loop until user selcets 9
            {

                //Listing out commands
                Console.WriteLine("Enter the corresponding number to execute the following command:");
                Console.WriteLine("(1) Print out all books");
                Console.WriteLine("(2) Print out all books available for check out");
                Console.WriteLine("(3) Print out all books by given author");
                Console.WriteLine("(4) Print out all books published on or after a given year");
                Console.WriteLine("(5) Sort all books by page length");
                Console.WriteLine("(6) Sort all books by title");
                Console.WriteLine("(7) Print out information about a single book given its title");
                Console.WriteLine("(8) Donate a book");
                Console.WriteLine("(9) Check out a book");
                Console.WriteLine("(10) Return a book");
                Console.WriteLine("(11) Quit");
                Console.WriteLine();

                //Determining number inputed
                number = int.Parse(Console.ReadLine());

                if (number > 11 || number < 1) {
                    throw new Exception("Number must be 1-11.");
                } else if (number == 1) {
                    PrintBooks(path);
                } else if (number == 2) {
                    PrintBooksAvailable(path);
                } else if (number == 3) {
                    Console.Write("Author: ");
                    string author = Console.ReadLine();
                    PrintBooksByAuthor(path, author);
                } else if (number == 4) {
                    Console.Write("Year: ");
                    int year = int.Parse(Console.ReadLine());
                    PrintBooksByYear(path, year);
                } else if (number == 5) {
                    SortBooksByPages(path);
                } else if (number == 6) {
                    SortBooksByTitle(path);
                } else if (number == 7) {
                    Console.Write("Title: ");
                    string title = Console.ReadLine();
                    PrintBookByTitle(path, title);
                }
                else if (number == 8)
                {
                    DonateBook(path);
                }
                else if (number == 9)
                {
                    //Call function
                }
                else if (number == 10)
                {
                    //Call function
                }
            }
            Console.WriteLine("Come back soon!");
        }
    }
}