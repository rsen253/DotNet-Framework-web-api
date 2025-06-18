using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sample.API.Models;
using Sample.API.Areas.HelpPage.ModelDescriptions;

namespace Sample.API.Services
{
    public interface IBookService
    {
        List<Book> GetAll();
        Book GetBookById(int id);
        List<Book> SearchByTitle(string title);
        void Create(Book book);
        void Update(int id, Book book);
        void Delete(int id);
    }


    public class BookService : IBookService
    {
        private static List<Book> _books = new List<Book>
        {
            new Book { BookId = 1, Title = "Book One", Description = "Description One", Price = 9.99m, Author = "Author One", Category = "Category One" },
            new Book { BookId = 2, Title = "Book Two", Description = "Description Two", Price = 19.99m, Author = "Author Two", Category = "Category Two" }
        };

        public List<Book> GetAll() 
        {
            return _books;
        }

        public Book GetBookById(int id)
        {
            return _books.FirstOrDefault(x => x.BookId == id);
        }

        public List<Book> SearchByTitle(string title)
        {
            return _books.Where(b => b.Title.IndexOf(title, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
        }

        public void Create(Book book)
        {
           _books.Add(book);
        }

        public void Update(int id, Book book)
        {
            var existing = GetBookById(id);
            if (existing != null)
            {
                existing.Title = book.Title;
                existing.Description = book.Description;
                existing.Author = book.Author;
                existing.Price = book.Price;
                existing.Category = book.Category;
            }
        }

        public void Delete(int id)
        {
            var book = GetBookById(id);
            if (book != null)
                _books.Remove(book);
        }
    }
}
