using Microsoft.EntityFrameworkCore.Internal;
using Nkey.BookRegistration.Challenge.Data.Context;
using Nkey.BookRegistration.Challenge.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Nkey.BookRegistration.Challenge.Data.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly BookRegistrationContext _context;

        public BookRepository(BookRegistrationContext context)
        {
            _context = context;
        }

        public List<Book> GetAll()
        {
            if (_context.Books.Any())
                return _context.Books.ToList();

            throw new Exception("Não há livros cadastrados.");
        }

        public List<Book> GetByFilter(BookFilter filter)
        {
            return _context.Books
                .Where(x =>
                    (x.Id == filter.Id) ||
                    (x.Code == filter.Code) ||
                    (x.Name.Contains(filter.Name)) ||
                    (x.Author.Contains(filter.Author)) ||
                    (x.Isbn == filter.Isbn) ||
                    (x.ReleaseYear == filter.ReleaseYear)
                ).OrderBy(x => x.Name)
                .ToList();
        }

        public void Save(Book book)
        {
            var bookRecovered = _context.Books
                .FirstOrDefault(x => x.Isbn.Equals(book.Isbn));

            if (bookRecovered != null) throw new Exception($"Livro com ISBN {book.Isbn} já cadastrado.");

            _context.Books.Add(book);
            _context.SaveChanges();
        }

        public void Update(Book book)
        {
            var bookRecovered = _context.Books
                .FirstOrDefault(x => x.Isbn.Equals(book.Isbn));

            if (bookRecovered == null) throw new Exception($"Livro com ISBN {book.Isbn} não encontrado.");

            bookRecovered.Code = book.Code;
            bookRecovered.Name = book.Name;
            bookRecovered.Author = book.Author;
            bookRecovered.ReleaseYear = book.ReleaseYear;

            _context.Books.Update(bookRecovered);
            _context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var bookRecovered = _context.Books
                .FirstOrDefault(x => x.Id == id);

            if (bookRecovered == null) throw new Exception("Livro não encontrado.");

            _context.Books.Remove(bookRecovered);
            _context.SaveChanges();
        }
    }
}
