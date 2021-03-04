using BookStoreTyler.Models;
using BookStoreTyler.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreTyler.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        // make a private repository, to assign later
        private IBooksRepository _repository;

        // number of items per page; the ? means it is nullable
        public int PageSize = 5;

        // assigns public variable to private class variable
        public HomeController(ILogger<HomeController> logger, IBooksRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        // The Controller contains "Actions"
        public IActionResult Index(string category, int page = 1)
        {
            //Create new ProjectListViewModel object to display on the page
            return View(new ProjectListViewModel
            {
                Books = _repository.Books
                    .Where(p => category == null || p.Classification == category)
                    .OrderBy(p => p.BookId)
                    .Skip((page - 1) * PageSize)
                    .Take(PageSize)
                ,
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalNumItems = category == null ? _repository.Books.Count() :
                        _repository.Books.Where(x => x.Classification == category).Count()
                        // ^ gives us only the count of the number of pages
                },
                CurrentCategory = category
            });
        }

        //goes to the confirmation page
        public IActionResult Confirmation()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
