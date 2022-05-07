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
using Data;

namespace LibApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReaderController : ControllerBase
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
            try
            {
                _readerService.AddReader(model.ModelToDomain());
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
        public IActionResult UpdateReader([FromBody] ReaderModel model)
        {
            try
            {
                _readerService.UpdateReader(model.ModelToDomain());
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
        public IActionResult DeleteReader([FromBody] ReaderModel model)
        {
            try
            {
                _readerService.DeleteReader(model.ID);
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

