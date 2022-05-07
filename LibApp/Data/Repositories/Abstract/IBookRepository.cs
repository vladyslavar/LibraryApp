using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace Data.Repositories.Abstract
{
    public interface IBookRepository
    {
        void AddBook(BookEntity book);
        List<BookEntity> GetBook();
        void UpdateBook(BookEntity book);
        void DeleteBook(int id);
        /*
        List<BookEntity> GetByName(string name);
        List<BookEntity> GetByAuthor(string author);
        List<BookEntity> GetByTheme(string theme);
        List<BookEntity> GetByReader(ReaderEntity reader);
        */
    }
}
