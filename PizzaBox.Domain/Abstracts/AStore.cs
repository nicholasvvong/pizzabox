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
        public List<APizza> PresetPizza { get; set; }
        public List<Topping> ToppingsList { get; set; }
        public List<Size> SizeList { get; set; }
        public List<Crust> CrustList { get; set; }

        protected AStore()
        {
            
        }

        public virtual decimal GetTotalSales(int LastNumDays)
        {
            decimal total = 0;
            for(int i = 0; i < Orders.Count; i++)
            {
                if(DateTime.UtcNow.Subtract(Orders[i].OrderTime).TotalDays <= LastNumDays)
                {
                    total += Orders[i].CurTotal;
                }
            }

            return total;
            /*
            for(int i = 0; i < Orders.Count; i++)
            {
                total += Orders[i].CurTotal;
            }
            return total;
            */
        }

        public virtual decimal GetTotalSales()
        {
            decimal total = 0;
            
            for(int i = 0; i < Orders.Count; i++)
            {
                total += Orders[i].CurTotal;
            }
            return total;
        }

        public virtual Dictionary<string, int> GetPizzaCount(int numDays)
        {
            Dictionary<string, int> count = new Dictionary<string, int>();
            for(int i = 0; i < PresetPizza.Count; i++)
            {
                count.Add(PresetPizza[i].Type, 0);
            }

            count.Add("Custom Pizza", 0);

            for(int i = 0; i < Orders.Count; i++)
            {
                if(DateTime.UtcNow.Subtract(Orders[i].OrderTime).TotalDays <= numDays)
                {
                    for(int j = 0; j < Orders[i].Pizzas.Count; j++)
                    {
                        count[Orders[i].Pizzas[j].Type]++;
                    }
                }
            }
            
            return count;
        }
        public virtual Dictionary<string, int> GetTotalPizzaCount()
        {
            return GetPizzaCount(Int32.MaxValue);
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
        protected virtual void InitPresetPizza(){}

        public override string ToString()
        {
            return Name;
        }
    }
}