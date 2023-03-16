using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Mission09_dh.Infrastructure;
using Mission09_dh.Models;

namespace Mission09_dh.Pages
{
    public class CartModel : PageModel
    {
        //Add a repo
        private iMission9Repository repo { get; set; }

        public Basket basket { get; set; }
        public string ReturnUrl { get; set; }

        public CartModel (iMission9Repository temp)
        {
            repo = temp;
        }

        //get method
        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
        }

        //post method
        public IActionResult OnPost(int bookId, string returnUrl)
        {
            Book b = repo.Books.FirstOrDefault(x => x.BookId == bookId);

            basket.AddItem(b, 1);

            return RedirectToPage(new { ReturnUrl = returnUrl });
        }

        public IActionResult OnPostRemove(int bookId, string returnUrl)
        {
            basket.RemoveItem(basket.Items.First(x => x.Book.BookId == bookId).Book);

            return RedirectToPage(new { ReturnUrl = returnUrl });
        }
    }
}
