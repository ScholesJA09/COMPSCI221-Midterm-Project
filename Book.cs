using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMPSCI221_Midterm_Project
{
    internal class Book
    {
        private string title;
        private string author;
        private string genre;
        private int pageLength;
        private int yearPublished;
        private bool checkedOut;

        public Book(string title, string author, string genre, int pageLength, int yearPublished, bool checkedOut)
        {
            if(string.IsNullOrWhiteSpace(title))
{
                throw new Exception("Title cannot be null and must have non-zero length.");
}
            this.title = title;

            if (string.IsNullOrWhiteSpace(author))
            {
                throw new Exception("Author cannot be null and must have non-zero length.");
            }
            this.author = author;

            if (string.IsNullOrWhiteSpace(genre))
            {
                throw new Exception("Genre cannot be null and must have non-zero length.");
            }
            this.genre = genre;

            if (pageLength < 1)
            {
                throw new Exception("Page length has to be at least 1.");
            }
            this.pageLength = pageLength;

            if (yearPublished < 1900 || yearPublished > 2026)
            {
                throw new Exception("Year must be from 1900 to 2026.");
            }
            this.yearPublished = yearPublished;
        }

        public override string ToString()
        {
            return $"{title} written by {author} was published in {yearPublished}.\nIt's genre is {genre} with a page length of {pageLength}.\nChecked Out: {checkedOut}";
        }

        public string Title
        {
            get => title;
        }

        public string Author
        {
            get => author;
        }

        public string Genre
        {
            get => genre;
        }

        public int PageLength
        {
            get => pageLength;
        }

        public int YearPublished
        {
            get => yearPublished;
        }

        public bool CheckedOut
        {
            get => checkedOut;
        }

    }
}
