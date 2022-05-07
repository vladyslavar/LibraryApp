using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;
using Mappers;
using Services.Abstract;

namespace LibApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibraryController : ControllerBase
    {
        private readonly IBooksService _libraryService;
        public LibraryController(IBooksService booksService)
        {
            _libraryService = booksService;
        }

        [HttpGet("takenbooks")]
        public List<BookModel> TakenBooks([FromBody] ReaderModel reader)
        {
            return _libraryService.GetAllBooksOfReader(reader.ModelToDomain()).ToModelBookList();
        }
        [HttpPut("givebook")]
        public IActionResult GiveBook([FromBody] LibraryModel model)
        {
            try
            {
                BookModel bookModel = new BookModel()
                {
                    Id = model.BookId,
                    Name = model.BookName,
                    Author = model.BookAuthor,
                    Theme = model.BookTheme,
                    Year = model.BookYear,
                    CurrReaderId = model.BookCurrReaderId
                };
                ReaderModel readerModel = new ReaderModel()
                {
                    ID = model.ReaderID,
                    Name = model.ReaderName,
                    Surname = model.ReaderSurname
                };
                _libraryService.GiveBookToReader(readerModel.ModelToDomain(), bookModel.ModelToDomain());
                return new ContentResult()
                {
                    StatusCode = 200,
                    Content = "Ok"
                };
            }
            catch(Exception e)
            {
                return new ContentResult()
                {
                    StatusCode = 500,
                    Content = e.Message
                };
            }
        }


        [HttpGet("byname")]
        public List<BookModel> GetByName([FromBody] string name)
        {
            return _libraryService.GetByName(name).ToModelBookList();
        }
        [HttpGet("byauthor")]
        public List<BookModel> GetByAuthor([FromBody] string author)
        {
            return _libraryService.GetByAuthor(author).ToModelBookList();
        }
        [HttpGet("bytheme")]
        public List<BookModel> GetByTheme([FromBody] string theme)
        {
            return _libraryService.GetByTheme(theme).ToModelBookList();
        }

        [HttpGet("freebyname")]
        public List<BookModel> GetFreeByName([FromBody] string name)
        {
            return _libraryService.GetFreeByName(name).ToModelBookList();
        }
        [HttpGet("freebyauthor")]
        public List<BookModel> GetFreeByAuthor([FromBody] string author)
        {
            return _libraryService.GetFreeByAuthor(author).ToModelBookList();
        }
        [HttpGet("freebytheme")]
        public List<BookModel> GetFreeByTheme([FromBody] string theme)
        {
            return _libraryService.GetByTheme(theme).ToModelBookList();
        }
    }
}
