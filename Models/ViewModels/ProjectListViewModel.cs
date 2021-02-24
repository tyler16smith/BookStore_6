using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreTyler.Models.ViewModels
{
    public class ProjectListViewModel
    {
        // add the books to the total list
        public IEnumerable<Books> Books { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}
