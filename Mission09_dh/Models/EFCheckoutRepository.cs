using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission09_dh.Models
{
    public class EFCheckoutRepository: iCheckoutRepository
    {
        private BookstoreContext context;

        public EFCheckoutRepository(BookstoreContext temp)
        {
            context = temp;
        }

        public IQueryable<Checkout> Checkouts => context.Checkouts.Include(x => x.Items);

        public void SaveCheckout(Checkout checkout)
        {

        }
    }
}
