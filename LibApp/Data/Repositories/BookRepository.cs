using Data.Repositories.Abstract;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DateBase;

namespace Data.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly MysqlDBContext _context;
        public BookRepository(MysqlDBContext context)
        {
            _context = context;
        }
        public void AddBook(BookEntity book)
        {
            _context.Books.Add(book);
            _context.SaveChanges();
        }
        public List<BookEntity> GetBook()
        {
            return _context.Books.ToList();
        }
        public void DeleteBook(int id)
        {
            _context.Books.Remove(_context.Books.Find(id));
            _context.SaveChanges();
        }
        public void UpdateBook(BookEntity book)
        {
            _context.ChangeTracker.Clear();
            _context.Books.Update(book);
            _context.SaveChanges();
        }
        /*
        public List<BookEntity> GetByAuthor(string author)
        {
            return _context.Books.Where(x => x.Author == author).ToList();
        }

        public List<BookEntity> GetByName(string name)
        {
            return _context.Books.Where(x => x.Name == name).ToList();
        }

        public List<BookEntity> GetByReader(ReaderEntity reader)
        {
            return _context.Books.Where(x => x.CurrReaderId == reader.Id).ToList();
        }

        public List<BookEntity> GetByTheme(string theme)
        {
            return _context.Books.Where(x => x.Theme == theme).ToList();
        }
        */
    }
}
