using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission09_dh.Models
{
    public class EFMission9Repository : iMission9Repository
    {
        private BookstoreContext context { get; set; }

        public EFMission9Repository(BookstoreContext temp)
        {
            context = temp;
        }

        public IQueryable<Book> Books => context.Books;
    }
}
