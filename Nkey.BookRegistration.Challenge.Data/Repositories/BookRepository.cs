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
                return _context.Books.OrderBy(x => x.Name).ToList();

            throw new Exception("Não há livros cadastrados.");
        }

        public List<Book> GetByFilter(BookFilter filter)
        {
            var query = _context.Books.AsQueryable();
            if (filter.Id != null) query = query.Where(x => x.Id == filter.Id);
            if (filter.Code != null && filter.Code> 0) query = query.Where(x => x.Code == filter.Code);
            if (!string.IsNullOrEmpty(filter.Name)) query = query.Where(x => x.Name.Contains(filter.Name));
            if (!string.IsNullOrEmpty(filter.Author)) query = query.Where(x => x.Author.Contains(filter.Author));
            if (!string.IsNullOrEmpty(filter.Isbn)) query = query.Where(x => x.Isbn.Contains(filter.Isbn));
            if (filter.ReleaseYear != null && filter.ReleaseYear> 0) query = query.Where(x => x.ReleaseYear == filter.ReleaseYear);
            return query.OrderBy(x => x.Name).ToList();
        }

        public Book GetById(Guid id)
        {
            var bookRecovered = _context.Books.FirstOrDefault(x => x.Id == id);

            if (bookRecovered == null) throw new Exception("Livro não encontrado.");

            return bookRecovered;
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
