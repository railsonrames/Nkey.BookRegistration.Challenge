using Nkey.BookRegistration.Challenge.Data.Entities;
using System;
using System.Collections.Generic;

namespace Nkey.BookRegistration.Challenge.Domain.Services.Interfaces
{
    public interface IBookService
    {
        List<Book> BookList();
        List<Book> FilteredBooks(BookFilter filter);
        void AddNewBook(Book book);
        void UpdateBook(Book book);
        void RemoveBook(Guid id);
    }
}
