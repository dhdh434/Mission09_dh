using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Mission09_dh.Models;
using Mission09_dh.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Mission09_dh.Controllers
{
    public class HomeController : Controller
    {

        private iMission9Repository repo;

        public HomeController (iMission9Repository temp)
        {
            repo = temp;
        }

        public IActionResult Index(string category, int pageNum = 1)
        {
            int pageSize = 10;

            var x = new ProjectsViewModel
            {
                Books = repo.Books
                .Where(p => p.Category == category | category == null)
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize),

                PageInfo = new PageInfo
                {
                    TotalNumBooks =
                        (category == null 
                            ? repo.Books.Count() 
                            : repo.Books.Where(x => x.Category == category).Count()),
                    BooksPerPage = pageSize,
                    CurrentPage = pageNum
                }
            };

            return View(x);
        }
    }
}
