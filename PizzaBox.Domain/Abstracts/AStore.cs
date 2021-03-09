using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using PizzaBox.Domain.Models;

namespace PizzaBox.Domain.Abstracts
{
    [XmlInclude(typeof(CaliforniaStore))]
    [XmlInclude(typeof(FreddyStore))]
    [XmlInclude(typeof(ChicagoStore))]
    [XmlInclude(typeof(NewYorkStore))]
    public class AStore
    {
        public string Name{ get; set; } //Property

        public List<Order> Orders { get; set; }

        public List<Topping> ToppingsList { get; set; }
        public List<Size> SizeList { get; set; }
        public List<Crust> CrustList { get; set; }

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
        public virtual void AddOrder(Order o)
        {
            Orders.Add(o);
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