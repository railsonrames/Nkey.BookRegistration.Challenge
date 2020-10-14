using Microsoft.AspNetCore.Mvc;
using Nkey.BookRegistration.Challenge.Data.Entities;
using Nkey.BookRegistration.Challenge.Domain.Services.Interfaces;
using System;
using System.Collections.Generic;

namespace Nkey.BookRegistration.Challenge.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _service;

        public BooksController(IBookService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Book>> List()
        {
            List<Book> list;

            try
            {
                list = _service.BookList();
            }
            catch (Exception e)
            {
                return StatusCode(404, e.Message);
            }

            return Ok(list);
        }

        [HttpGet("filter")]
        public ActionResult<IEnumerable<Book>> GetByFilter(BookFilter filter)
        {
            List<Book> list;

            try
            {
                list = _service.FilteredBooks(filter);
            }
            catch (Exception e)
            {
                return StatusCode(404, e.Message);
            }

            return Ok(list);
        }

        [HttpPost]
        public JsonResult Save([FromBody]Book book)
        {
            try
            {
                _service.AddNewBook(book);
            }
            catch (Exception e)
            {
                return new JsonResult(e.Message)
                {
                    StatusCode = 400
                };
            }

            return new JsonResult("Livro cadastrado com sucesso.")
            {
                StatusCode = 201
            };
        }

        [HttpPut]
        public IActionResult Update(Book book)
        {
            try
            {
                _service.UpdateBook(book);
            }
            catch (Exception e)
            {
                return StatusCode(404, e.Message);
            }

            return StatusCode(204, "Updated.");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _service.RemoveBook(id);
            }
            catch (Exception e)
            {
                return StatusCode(404, e.Message);
            }

            return StatusCode(204, "Deleted.");
        }
    }
}
