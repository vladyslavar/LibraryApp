using System;
using Data.Repositories.Abstract;
using Domain;
using Services;
using Data.Repositories;
using LibApp;
using Microsoft.EntityFrameworkCore;


namespace Vizualization
{
    class Program
    {
        static void Main(string[] args)
        {
            const string connStr = "server=127.0.0.1;uid=root;pwd=12345;database=DotNet";
            DbContextOptionsBuilder<MyDBContext> optBuilder = new DbContextOptionsBuilder<MyDBContext>();
            optBuilder.UseMySQL(connStr);
            MyDBContext context = new MyDBContext(optBuilder.Options);

            iReaderRepository reader = new ReaderRepository(context);
            ReaderService readerService = new ReaderService(reader);
            IBookRepository book = new BookRepository(context);
            BookService bookService = new BookService(book);

            //menu
            while (true)
            {
                Console.WriteLine("HELP INFO\n--reader\n--book\n--lib\n--exit");
                var str = Console.ReadLine();
                if (str == "--book")
                {
                    while (true)
                    {
                        Console.WriteLine("BOOK: --add; --update; --delete; --exit;");

                        var bookStr = Console.ReadLine();
                        if (bookStr == "--add")
                        {
                            Console.Write("Name: "); var nameEnt = Console.ReadLine();
                            Console.Write("Author: "); var authorEnt = Console.ReadLine();
                            Console.Write("Theme: "); var themeEnt = Console.ReadLine();
                            Console.Write("Year: "); var yearEnt = Console.ReadLine();
                            Console.Write("Save? "); var checkEnt = Console.ReadLine();
                            if (checkEnt == "+")
                            {
                                bookService.AddBook(new Book()
                                {
                                    Name = nameEnt,
                                    Author = authorEnt,
                                    Theme = themeEnt,
                                    Year = Convert.ToInt32(yearEnt)
                                });
                            }
                        }
                        if (bookStr == "--update")
                        {
                            Console.Write("Name: "); var nameEnt = Console.ReadLine();
                            Console.Write("Author: "); var authorEnt = Console.ReadLine();
                            Console.Write("Theme: "); var themeEnt = Console.ReadLine();
                            Console.Write("Year: "); var yearEnt = Console.ReadLine();
                            Console.Write("Save? "); var checkEnt = Console.ReadLine();
                            if (checkEnt == "+")
                            {
                                bookService.UpdateBook(new Book()
                                {
                                    Name = nameEnt,
                                    Author = authorEnt,
                                    Theme = themeEnt,
                                    Year = Convert.ToInt32(yearEnt)
                                });
                            }
                        }
                        if (bookStr == "--delete")
                        {
                            Console.Write("Id: "); var idEnt = Console.ReadLine();
                            Console.Write("Save? "); var checkEnt = Console.ReadLine();
                            if (checkEnt == "+")
                            {
                                bookService.DeleteBook(Convert.ToInt32(idEnt));
                            }
                        }
                        if (bookStr == "--exit") break;
                    }
                }
                if (str == "--reader")
                {
                    while (true)
                    {
                        Console.WriteLine("READER: --add; --update; --delete; --exit;");

                        var readStr = Console.ReadLine();
                        if (readStr == "--add")
                        {
                            Console.Write("Name: "); var nameEnt = Console.ReadLine();
                            Console.Write("Surname: "); var surnameEnt = Console.ReadLine();
                            Console.Write("Save? "); var checkEnt = Console.ReadLine();
                            if (checkEnt == "+")
                            {
                                readerService.AddReader(new Reader()
                                {
                                    Name = nameEnt,
                                    Surname = surnameEnt,
                                    BooksOfReader = null
                                });
                            }
                        }
                        if (readStr == "--update")
                        {
                            Console.Write("Name: "); var nameEnt = Console.ReadLine();
                            Console.Write("Surname: "); var surnameEnt = Console.ReadLine();
                            Console.Write("Save? "); var checkEnt = Console.ReadLine();
                            if (checkEnt == "+")
                            {
                                readerService.UpdateReader(new Reader()
                                {
                                    Name = nameEnt,
                                    Surname = surnameEnt,
                                    BooksOfReader = null
                                });
                            }
                        }
                        if (readStr == "--delete")
                        {
                            Console.Write("Id: "); var idEnt = Console.ReadLine();
                            Console.Write("Save? "); var checkEnt = Console.ReadLine();
                            if (checkEnt == "+")
                            {
                                readerService.DeleteReader(Convert.ToInt32(idEnt));
                            }
                        }
                        if (readStr == "--exit") break;
                    }
                }
                if (str == "--lib")
                {
                    while (true)
                    {
                        Console.WriteLine("LIBRARY ACTIONS: --getBname; --getBauthor; --getBtheme; --checkTaken; --giveBook; --exit;");

                        var libStr = Console.ReadLine();
                        if (libStr == "--getBname")
                        {
                            Console.Write("Name: "); var nameEnt = Console.ReadLine();
                            var booksEnt = bookService.GetByName(nameEnt);
                            foreach (var b in booksEnt)
                            {
                                Console.WriteLine(b.Id + ") " +b.Name + " by " + b.Author);
                            }
                        }
                        if (libStr == "--getBauthor")
                        {
                            Console.Write("Author: "); var authorEnt = Console.ReadLine();
                            var booksEnt = bookService.GetByAuthor(authorEnt);
                            foreach (var b in booksEnt)
                            {
                                Console.WriteLine(b.Id + ") " + b.Name + " by " + b.Author);
                            }
                        }
                        if (libStr == "--getBtheme")
                        {
                            Console.Write("Theme: "); var themeEnt = Console.ReadLine();
                            var booksEnt = bookService.GetByTheme(themeEnt);
                            foreach (var b in booksEnt)
                            {
                                Console.WriteLine(b.Id + ") " + b.Name + " by " + b.Author);
                            }
                        }
                        if (libStr == "--checkTaken")
                        {
                            Console.Write("Name: "); var nameEnt = Console.ReadLine();
                            Console.Write("Surname: "); var surnameEnt = Console.ReadLine();
                            var _reader = readerService.GetReader("Misha", "Didur");
                            var bs = bookService.GetAllBooksOfReader(_reader);
                            Console.WriteLine(bs.Count + " books: ");
                            foreach (var b in bs)
                            {
                                Console.WriteLine(b.Id + ") " + b.Name + " by " + b.Author);
                            }
                        }
                        if (libStr == "--giveBook")
                        {
                            Console.Write("Book name: "); var bnameEnt = Console.ReadLine();
                            Console.Write("Reader's name: "); var rnameEnt = Console.ReadLine();
                            Console.Write("Reader's surname: "); var rsurnameEnt = Console.ReadLine();
                            var freebook = bookService.GetFreeByName(bnameEnt);
                            var _myreader = readerService.GetReader(rnameEnt, rsurnameEnt);
                            try
                            {
                                bookService.GiveBookToReader(_myreader, freebook[0]);
                                Console.WriteLine("Done!");
                            }
                            catch(Exception e)
                            {
                                Console.WriteLine(e.Message);
                            }
                        }
                        if (libStr == "--exit") break;
                    }
                }
                if (str == "--exit") break;
            }
        }
    }
}
