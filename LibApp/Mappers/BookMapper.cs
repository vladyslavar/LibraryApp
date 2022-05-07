using Domain;
using Entities;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mappers
{
    public static class BookMapper
    {
        public static BookEntity ToEntity(this Book book)
        {
            return new BookEntity()
            {
                Id = book.Id,
                Name = book.Name,
                Author = book.Author,
                Theme = book.Theme,
                Year = book.Year,
                CurrReaderId = book.CurrReaderId
            };
        }
        public static List<Book> ToDomainBookList(this List<BookEntity> booksEnt)
        {
            List<Book> books = new List<Book>();
            foreach(var b in booksEnt)
            {
                books.Add(new Book()
                {
                    Id = b.Id,
                    Name = b.Name,
                    Author = b.Author,
                    Year = b.Year,
                    Theme = b.Theme,
                    CurrReaderId = b.CurrReaderId

                });
            }
            return books;
        }
        public static Book ModelToDomain(this BookModel book)
        {
            return new Book()
            {
                Id = book.Id,
                Name = book.Name,
                Author = book.Author,
                Theme = book.Theme,
                Year = book.Year,
                CurrReaderId = book.CurrReaderId
            };
        }
        public static List<BookModel> ToModelBookList(this List<Book> booksDom)
        {
            List<BookModel> books = new List<BookModel>();
            foreach (var b in booksDom)
            {
                books.Add(new BookModel()
                {
                    Id = b.Id,
                    Name = b.Name,
                    Author = b.Author,
                    Year = b.Year,
                    Theme = b.Theme,
                    CurrReaderId = b.CurrReaderId

                });
            }
            return books;
        }
    }
}
