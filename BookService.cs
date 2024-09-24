using LibraryAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace LibraryAPI.Services
{
    public class BookService
    {
        private static List<Book> Books = new List<Book>();

        // Get all books
        public List<Book> GetBooks()
        {
            return Books;
        }

        // Get a single book by ID
        public Book GetBookById(int id)
        {
            return Books.FirstOrDefault(b => b.Id == id);
        }

        // Add a new book
        public void AddBook(Book book)
        {
            book.Id = Books.Count + 1; // Simple auto-increment for ID
            Books.Add(book);
        }

        // Update an existing book
        public bool UpdateBook(int id, Book updatedBook)
        {
            var book = GetBookById(id);
            if (book == null)
                return false;

            book.Title = updatedBook.Title;
            book.Author = updatedBook.Author;
            book.Year = updatedBook.Year;
            book.Genre = updatedBook.Genre;
            return true;
        }

        // Delete a book
        public bool DeleteBook(int id)
        {
            var book = GetBookById(id);
            if (book == null)
                return false;

            Books.Remove(book);
            return true;
        }
    }
}
