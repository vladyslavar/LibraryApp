using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Repositories.Abstract;
using Domain;
using Services.Abstract;
using Mappers;

namespace Services
{
    public class BookService : IBooksService
    {
        private readonly IBookRepository _book;
        public BookService(IBookRepository book)
        {
            _book = book;
        }
        public void AddBook(Book book)
        {
            _book.AddBook(book.ToEntity());
        }

        public List<Book> GetByAuthor(string author)
        {
            return _book.GetBook().Where(p => p.Author == author).ToList().ToDomainBookList();
        }
        public List<Book> GetByName(string name)
        {
            return _book.GetBook().Where(p => p.Name == name).ToList().ToDomainBookList();
        }
        public List<Book> GetByTheme(string theme)
        {
            return _book.GetBook().Where(p => p.Theme == theme).ToList().ToDomainBookList();
        }

        public List<Book> GetFreeByAuthor(string author)
        {
            return _book.GetBook().Where(p => p.Author == author && p.CurrReaderId == null).ToList().ToDomainBookList();
        }
        public List<Book> GetFreeByName(string name)
        {
            return _book.GetBook().Where(p => p.Name == name && p.CurrReaderId == null).ToList().ToDomainBookList();
        }
        public List<Book> GetFreeByTheme(string theme)
        {
            return _book.GetBook().Where(p => p.Theme == theme && p.CurrReaderId == null).ToList().ToDomainBookList();
        }

        public List<Book> GetAllBooksOfReader(Reader reader)
        {
            return _book.GetBook().Where(p => p.CurrReaderId == reader.ID).ToList().ToDomainBookList();
        }
        public bool GiveBookToReader(Reader reader, Book book)
        {
            var availBook = GetFreeByName(book.Name);
            var numTaken = GetAllBooksOfReader(reader);
            if (availBook.Count > 0 && numTaken.Count < 10)
            {
                SetReader(book, reader);
                return true;
            }
            else return false;
        }
        public void SetReader(Book book, Reader reader)
        {
            _book.UpdateBook(new Entities.BookEntity()
            {
                Id = book.Id,
                Name = book.Name,
                Author = book.Author,
                Theme = book.Theme,
                Year = book.Year,
                CurrReaderId = reader.ID
            });
        }

        public void DeleteBook(int id)
        {
            _book.DeleteBook(id);
        }
        public void UpdateBook(Book book)
        {
            _book.UpdateBook(book.ToEntity());
        }
    }
}
