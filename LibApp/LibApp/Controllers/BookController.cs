using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;
using Mappers;
using Services.Abstract;
using Services;

namespace LibApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBooksService _booksService;
        public BookController(IBooksService booksService)
        {
            _booksService = booksService;
        }
        [HttpPost("add")]
        public IActionResult AddBook([FromBody] BookModel model)
        {
            try
            {
                _booksService.AddBook(model.ModelToDomain());
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
        [HttpPut("update")]
        public IActionResult UpdateBook([FromBody] BookModel model)
        {
            try
            {
                _booksService.UpdateBook(model.ModelToDomain());
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
        [HttpDelete("delete")]
        public IActionResult DeleteBook([FromBody] BookModel model)
        {
            try
            {
                _booksService.DeleteBook(model.Id);
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
    }
}
