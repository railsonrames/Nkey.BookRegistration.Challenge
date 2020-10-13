using System;
using System.ComponentModel.DataAnnotations;

namespace Nkey.BookRegistration.Challenge.App.Models
{
    public class BookModel
    {
        public Guid? Id { get; set; }
        public int? Code { get; set; }
        [Display(Name = "Title")]
        public string Name { get; set; }
        public string Author { get; set; }
        [Display(Name = "ISBN")]
        public string Isbn { get; set; }
        [Display(Name = "Release Year")]
        public int? ReleaseYear { get; set; }
    }
}
