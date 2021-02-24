using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreTyler.Models
{
    // tells the program how to access the database
    public class BooksDbContext: DbContext
    {
        // constructor
        public BooksDbContext (DbContextOptions<BooksDbContext> options): base (options)
        {

        }

        // list of 'Books.cs' objects
        public DbSet<Books> Books { get; set; }
    }
}
