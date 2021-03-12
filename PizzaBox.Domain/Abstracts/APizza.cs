using System.Collections.Generic;
using System.Xml.Serialization;
using PizzaBox.Domain.Models;

namespace PizzaBox.Domain.Abstracts
{
    /// <summary>
    /// 
    /// </summary>
    /// 

    [XmlInclude(typeof(CustomPizza))]
    public abstract class APizza
    {
        public string Type { get; set; }
        protected int _minToppings = 2;
        protected int _maxtoppings = 5;
        public int MaxToppings { get; set; }
        private decimal PizzaPrice { get; set; }
        public List<Topping> Toppings { get; set; }
        public Crust Crust { get; set; }
        public Size Size{ get; set; }

        public APizza()
        {
            FactoryMethod();
        }

        private void FactoryMethod()
        {
            PizzaPrice = 0;
            Toppings = new List<Topping>();
            AddCrust(new Crust("",0m));
            AddSize(new Size("", 0m));
            MaxToppings = _minToppings + _maxtoppings;
            //AddDefaults();
        }

        public abstract void AddCrust(Crust c);
        public abstract void AddSize(Size s);
        public abstract void AddTopping(Topping t);
        
        private bool DefaultsAdded()
        {
            if(Toppings.Count > 0)
                return true;
            else
                return false;
        }

        public void AddDefaults()
        {
            if(!DefaultsAdded())
            {
                AddTopping(new Topping("sauce", 0m));
                AddTopping(new Topping("cheese", 0m));
            }
        }

        public virtual decimal CalculatePrice()
        {
            PizzaPrice = 0;
            if(Crust != null)
            {
                PizzaPrice += Crust.Price;
            
                if(Crust.CheeseStuffed)
                    PizzaPrice += Crust.StuffedPrice;
            }

            if(Size != null)
            {
                PizzaPrice += Size.Price;
            }
            if(Toppings != null)
            {
                foreach(Topping t in Toppings)
                {
                    PizzaPrice += t.Price;
                }
            }

            return PizzaPrice;
        }

        public void CopyPizza(APizza oldPizza)
        {
            Type = oldPizza.Type;
            PizzaPrice = oldPizza.PizzaPrice;
            Crust = oldPizza.Crust;
            foreach(Topping t in oldPizza.Toppings)
            {
                AddTopping(t);
            }
        }

        public override string ToString()
        {
            string pizzaDesc = "";
            pizzaDesc += Type + " : ";
            pizzaDesc += Size.Name + " : ";
            pizzaDesc += PrintNoSize(false);
            return pizzaDesc;
        }

        public string PrintNoSize(bool typePrint)
        {
            string pizzaDesc = "";
            if(typePrint)
            {
                pizzaDesc += Type + " : ";
            }

            pizzaDesc += Crust.Name + " : ";
            foreach(Topping t in Toppings)
            {
                pizzaDesc += t.Name + " ";
            }

            pizzaDesc += "- " + CalculatePrice();
            return pizzaDesc;
        }
    }
}