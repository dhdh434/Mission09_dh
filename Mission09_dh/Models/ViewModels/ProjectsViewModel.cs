﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission09_dh.Models.ViewModels
{
    public class ProjectsViewModel
    {
        public IQueryable<Book> Books { get; set; }

        public PageInfo PageInfo { get; set; }
    }
}
