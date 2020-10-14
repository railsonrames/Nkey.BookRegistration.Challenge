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

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            Book registry;
            try
            {
                registry = _service.GetById(id);
            }
            catch (Exception e)
            {
                return StatusCode(404, e.Message);
            }

            return Ok(registry);
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
        public JsonResult Update([FromBody]Book book)
        {
            try
            {
                _service.UpdateBook(book);
            }
            catch (Exception e)
            {
                return new JsonResult(e.Message)
                {
                    StatusCode = 404
                };
            }
            return new JsonResult("Livro atualizado com sucesso.")
            {
                StatusCode = 204
            };
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

            return StatusCode(204, "Livro excluído com sucesso.");
        }
    }
}
