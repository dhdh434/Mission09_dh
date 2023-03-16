using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Mission09_dh.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Mission09_dh.Models
{
    //inheret from basket class
    public class SessionBasket: Basket
    {
        public static Basket GetBasket (IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

            SessionBasket basket = session?.GetJson<SessionBasket>("Basket") ?? new SessionBasket();

            //set the session equal to the basket session
            basket.Session = session;

            return basket;
        }

        [JsonIgnore]
        public ISession Session { get; set; }

        //overide addItem function
        public override void AddItem(Book bo, int qty)
        {
            base.AddItem(bo, qty);
            Session.SetJson("Basket", this);
        }

        //overide RemoveItem function
        public override void RemoveItem(Book boo)
        {
            base.RemoveItem(boo);
            Session.SetJson("Basket", this);
        }

        //overide Clear Basket function
        public override void ClearBasket()
        {
            base.ClearBasket();
            Session.Remove("Basket");
        }
    }
}
