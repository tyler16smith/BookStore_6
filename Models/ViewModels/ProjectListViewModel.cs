using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreTyler.Models.ViewModels
{
    public class ProjectListViewModel
    {
        // Summary:
        //     An 'interface' that returns an enumerator that iterates through the collection, inheriting from "IEnumerable"
        //
        // Returns:
        //     An enumerator that can be used to iterate through the collection.
        public IEnumerable<Books> Books { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public string CurrentCategory { get; set; }
    }
}
