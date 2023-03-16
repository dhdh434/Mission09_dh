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
        private iCheckoutRepository repo { get; set; }
        private Basket basket { get; set; }
        public CheckoutController(iCheckoutRepository temp, Basket b)
        {
            repo = temp;
            basket = b;
        }

        //get method
        [HttpGet]
        public IActionResult Purchase()
        {
            return View(new Checkout());
        }

        //postMethod
        [HttpPost]
        public IActionResult Purchase(Checkout checkout)
        {
            //check if item in basket
            if (basket.Items.Count() == 0)
            {
                ModelState.AddModelError("", "Sorry, your basket is empty!");
            }

            //make sure the modelstate is valid
            if (ModelState.IsValid)
            {
                checkout.Lines = basket.Items.ToArray();
                repo.SaveCheckout(checkout);
                basket.ClearBasket();

                return RedirectToPage("/CheckoutCompleted");
            }
            else
            {
                return View();
            }
        }
    }
}
