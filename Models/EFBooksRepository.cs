using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreTyler.Models
{
    public class EFBooksRepository: IBooksRepository
    {
        private BooksDbContext _context;

        // BooksDbContext --> Books (which stores the data)
        public EFBooksRepository (BooksDbContext context)
        {
            // store BooksDbContext as a private "_context" variable
            _context = context;
        }

        // create iqueryable --> Books
        public IQueryable<Books> Books => _context.Books;
    }
}
