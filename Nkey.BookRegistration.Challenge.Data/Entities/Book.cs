using System;

namespace Nkey.BookRegistration.Challenge.Data.Entities
{
    public class Book
    {
        public Guid Id { get; set; }
        public int Code { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public string Isbn { get; set; }
        public int ReleaseYear { get; set; }
    }
}
