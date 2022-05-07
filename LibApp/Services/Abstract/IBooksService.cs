using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace Services.Abstract
{
    public interface IBooksService
    {
        void AddBook(Book book);
        List<Book> GetByName(string name);
        List<Book> GetByAuthor(string author);
        List<Book> GetByTheme(string theme);
        List<Book> GetFreeByName(string name);
        List<Book> GetFreeByAuthor(string author);
        List<Book> GetFreeByTheme(string theme);
        List<Book> GetAllBooksOfReader(Reader reader);
        bool GiveBookToReader(Reader reader, Book book);
        void UpdateBook(Book book);
        void DeleteBook(int id);
    }
}
