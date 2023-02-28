using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission09_dh.Models
{
    public interface iMission9Repository
    {
        IQueryable<Book> Books { get; }
    }
}
