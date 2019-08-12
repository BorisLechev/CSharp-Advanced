using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace IteratorsAndComparators
{
    public class LibraryIterator : IEnumerator<Book>
    {
        private int currentIndex;

        private Book[] books;

        public LibraryIterator(List<Book> books)
        {
            this.books = books.ToArray();
            Reset();
        }

        public Book Current
        {
            get
            {
                return this.books[currentIndex];
            }
        }

        object IEnumerator.Current => Current;

        public void Dispose()
        {
            this.books = null;
        }

        public bool MoveNext()
        {
            currentIndex = currentIndex + 1;
            bool result = currentIndex < this.books.Length;

            return result;
        }

        public void Reset()
        {
            currentIndex = -1;
        }
    }
}
