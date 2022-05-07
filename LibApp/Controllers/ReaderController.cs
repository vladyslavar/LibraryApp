using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Models;
using Services.Abstract;

namespace Controllers
{
    [ApiController]
    [Route("[api/controller]")]
    public class ReaderController
    {
        private readonly IReaderService _readerService;
        public ReaderController(IReaderService readerService)
        {
            _readerService = readerService;
        }

        [HttpGet]
        public IActionResult testReader()
        {
            return new ContentResult()
            {
                StatusCode = 200,
                Content = "Hello"
            };
        }

        [HttpPost("add")]
        public IActionResult AddReader([FromBody] ReaderModel model)
        {
            _readerService.AddReader(model.ModelToDomain());
            return new ContentResult()
            {
                StatusCode = 200,
                Content = "Ok"
            };
        }
        [HttpPut("update")]
        public IActionResult UpdateReader([FromBody] ReaderModel model)
        {
            _readerService.UpdateReader(model.ModelToDomain());
            return new ContentResult()
            {
                StatusCode = 200,
                Content = "Ok"
            };
        }
        [HttpDelete("delete")]
        public IActionResult DeleteReader([FromBody] ReaderModel model)
        {
            _readerService.DeleteReader(model.ID);
            return new ContentResult()
            {
                StatusCode = 200,
                Content = "Ok"
            };
        }
    }
}
