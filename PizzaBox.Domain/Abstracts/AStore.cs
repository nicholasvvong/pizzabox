using System;
using System.Collections.Generic;
using PizzaBox.Domain.Models;

namespace PizzaBox.Domain.Abstracts
{
    public class AStore
    {
        public string Name{ get;  protected set; } //Property

        public List<Order> Orders { get; protected set; }

        public List<APizzaComponent> ToppingsList { get; protected set; }
        public List<APizzaComponent> SizeList { get; protected set; }
        public List<APizzaComponent> CrustList { get; protected set; }

        protected AStore()
        {
            
        }

        protected virtual void ViewOrders()
        {
            for(int i = 0; i < Orders.Count; i++)
            {
                Console.WriteLine("Order #{0}", i);
                Console.WriteLine(Orders[i]);
                Console.WriteLine("-------------------------");
            }
        }
        protected virtual void ViewSales(string type)
        {

        }
        protected virtual void AddTopping(string type, decimal price)
        {
            ToppingsList.Add(new Topping(type, price));
        }
        protected virtual void AddSize(string type, decimal price)
        {
            SizeList.Add(new Size(type, price));
        }
        protected virtual void AddCrust(string type, decimal price)
        {
            CrustList.Add(new Crust(type, price));
        }

        protected virtual void InitToppings(){}
        protected virtual void InitCrust(){}
        protected virtual void InitSize(){}

        public override string ToString()
        {
            return Name;
        }
    }
}