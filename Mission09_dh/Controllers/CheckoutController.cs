using Microsoft.AspNetCore.Mvc;
using Mission09_dh.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission09_dh.Controllers
{
    public class CheckoutController : Controller
    {
        public IActionResult Purchase()
        {
            return View(new Checkout());
        }
    }
}
