using Nkey.BookRegistration.Challenge.Data.Entities;
using Nkey.BookRegistration.Challenge.Data.Repositories;
using Nkey.BookRegistration.Challenge.Domain.Services.Interfaces;
using System;
using System.Collections.Generic;

namespace Nkey.BookRegistration.Challenge.Domain.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _repository;

        public BookService(IBookRepository repository)
        {
            _repository = repository;
        }

        public List<Book> BookList()
        {
            try
            {
                return _repository.GetAll();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<Book> FilteredBooks(BookFilter filter)
        {
            try
            {
                return _repository.GetByFilter(filter);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Book GetById(Guid id)
        {
            try
            {
                return _repository.GetById(id);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void AddNewBook(Book book)
        {
            try
            {
                _repository.Save(book);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void UpdateBook(Book book)
        {
            try
            {
                _repository.Update(book);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void RemoveBook(Guid id)
        {
            try
            {
                _repository.Delete(id);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
