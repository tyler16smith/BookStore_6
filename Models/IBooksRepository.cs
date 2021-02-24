using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreTyler.Models
{
    // access features presented by the "BooksDbContext.cs" Class; reduce duplication, increase efficiency, most widely used
    public interface IBooksRepository
    {
        // defines what has to be set up in what way
        IQueryable<Books> Books { get; }
    }
}
