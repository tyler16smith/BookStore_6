using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreTyler.Models
{
    public class Books
    {
        // all properties
        [Key] [Required]
        public int BookId { get; set; }

        [Required]
        public string Title { get; set; }

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

        [Required]
        public double Price { get; set; }
        
        [Required]
        public double NumPages { get; set; }
    }
}
