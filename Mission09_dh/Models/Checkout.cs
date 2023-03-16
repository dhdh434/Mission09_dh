using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mission09_dh.Models
{
    public class Checkout
    {
        //create the database for checking out
        [Key]
        [BindNever]
        public int CheckoutId { get; set; }

        [BindNever]
        public ICollection<BasketLineItem> Lines { get; set; }

        [Required(ErrorMessage = "Please enter a name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter a address line")]
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }

        [Required(ErrorMessage = "Please enter a city name")]
        public string City { get; set; }

        [Required(ErrorMessage = "Please enter a state")]
        public string State { get; set; }

        public string Zip { get; set; }

        [Required(ErrorMessage = "Please enter a country")]
        public string Country { get; set; }

        [Required(ErrorMessage = "Please enter a phone number")]
        public string phone { get; set; }

        [Required(ErrorMessage = "Please enter an email")]
        public string email { get; set; }

        public double ComputeTotalValue()
        {
            double num = Lines.Count();
            return num;
        }

    }
}
