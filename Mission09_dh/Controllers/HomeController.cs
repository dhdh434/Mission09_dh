using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Mission09_dh.Models;
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

        public IActionResult Index()
        {
            var bookList = repo.Books.ToList();

            return View(bookList);
        }
    }
}
