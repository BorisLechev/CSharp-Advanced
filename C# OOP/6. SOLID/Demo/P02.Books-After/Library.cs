using System;
using System.Collections.Generic;
using System.Text;

namespace P02.Books_After
{
    public class Library
    {
        private IEnumerable<Book> books;

        public Library(IEnumerable<Book> books)
        {
            this.books = books;
        }

        public int FindPage(string title)
        {
            var book = books;
            return 42;
        }
    }
}
