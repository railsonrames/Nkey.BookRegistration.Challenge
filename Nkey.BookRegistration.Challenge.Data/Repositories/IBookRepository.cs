using Nkey.BookRegistration.Challenge.Data.Entities;
using System;
using System.Collections.Generic;

namespace Nkey.BookRegistration.Challenge.Data.Repositories
{
    public interface IBookRepository
    {
        List<Book> GetAll();
        List<Book> GetByFilter(BookFilter filter);
        void Save(Book book);
        void Update(Book book);
        void Delete(Guid id);
    }
}
