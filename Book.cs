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
            Title = title;

            Author = author;

            Genre = genre;

            PageLength = pageLength;

            YearPublished = yearPublished;

            this.checkedOut = checkedOut;
        }

        public override string ToString()
        {
            return $"{title} written by {author} was published in {yearPublished}.\nIt's genre is {genre} with a page length of {pageLength}.\nChecked Out: {checkedOut}\n";
        }

        public string Title
        {
            get => title;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception("Title cannot be null and must have non-zero length.");
                }
                title = value;
            }
        }

        public string Author
        {
            get => author;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception("Author cannot be null and must have non-zero length.");
                }
                author = value;
            }
        }

        public string Genre
        {
            get => genre;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception("Genre cannot be null and must have non-zero length.");
                }
                genre = value;
            }
        }

        public int PageLength
        {
            get => pageLength;
            set
            {
                if (value < 1)
                {
                    throw new Exception("Page length has to be at least 1.");
                }
                pageLength = value;
            }
        }

        public int YearPublished
        {
            get => yearPublished;
            set
            {
                if (value < 1900 || value > 2026)
                {
                    throw new Exception("Year must be from 1900 to 2026.");
                }
                yearPublished = value;
            }
        }

        public bool CheckedOut
        {
            get => checkedOut;
        }

    }
}