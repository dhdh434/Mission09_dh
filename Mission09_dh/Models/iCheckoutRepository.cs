﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission09_dh.Models
{
    public interface iCheckoutRepository
    {
        IQueryable<Checkout> Checkouts { get; }

        void SaveCheckout(Checkout checkout);
    }
}