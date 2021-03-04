using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
// .Linq is the default language for querying the database

// databases in ASP.NET do NOT have to be built from the models; OR you could build the database on SQL Server
// databases is NOT automatically normalized by ASP.NET when created from the models
// creating database from the models = "Migration"
namespace BookStoreTyler.Models
{
    public class Books
    {
        // "Key" identifies the Primary Key in the model
        [Key] [Required]
        public int BookId { get; set; }
        //public int? BookId { get; set; } = 12
        //          ^this field is optional  ^default value if null is 12

        [Required]
        public string Title { get; set; }
        // properties in the model do not HAVE to have a get; and set;

        [Required]
        public string AuthorFirstName { get; set; }

        public string AuthorMInitial { get; set; }

        [Required]
        public string AuthorLastName { get; set; }

        [Required]
        public string Publisher { get; set; }

        [Required]
        [RegularExpression(@"^\d{3}-\d{10}$", 
            ErrorMessage = "Please enter the ISBN in the format of ###-#######")]
        public string ISBN { get; set; }

        [Required]
        public string Classification { get; set; }

        [Required]
        public string Category { get; set; }

        public double Price { get; set; } = 12;
        
        [Required]
        public double NumPages { get; set; }
    }
}
