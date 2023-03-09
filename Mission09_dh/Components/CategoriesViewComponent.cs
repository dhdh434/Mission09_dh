using Microsoft.AspNetCore.Mvc;
using Mission09_dh.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission09_dh.Components
{
    public class CategoriesViewComponent : ViewComponent
    {
        private iMission9Repository repo { get; set; }

        public CategoriesViewComponent(iMission9Repository temp)
        {
            repo = temp;
        }

        //go into the book list
        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedCategory = RouteData?.Values["category"];

            var categories = repo.Books
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x);

            return View(categories);
        }
    }
}
