using BookStoreTyler.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreTyler.Components
{
    // inherits from "ViewComponent" class, coding by convention: "
    public class NavigationMenuViewComponent: ViewComponent
    {
        // get it from the class
        private IBooksRepository _repository;

        public NavigationMenuViewComponent (IBooksRepository b)
        {
            // set private class variable to models
            _repository = b;
        }

        // drop a View into a View
        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedType = RouteData?.Values["Category"];

            // SQL statement for what's in the view
            return View(_repository.Books
                .Select(x => x.Classification)
                .Distinct()
                .OrderBy(x => x));
        }
    }
}
