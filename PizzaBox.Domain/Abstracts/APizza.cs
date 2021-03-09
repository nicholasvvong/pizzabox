using System.Collections.Generic;

namespace PizzaBox.Domain.Abstracts
{
    /// <summary>
    /// 
    /// </summary>
    /// 

    public abstract class APizza
    {
        public string type { get; set; }
        protected int _minToppings = 2;
        protected int _maxtoppings = 5;
        public decimal PizzaPrice { get; protected set; }
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
            AddCrust(new Crust("",0m));
            AddSize(new Size("", 0m));
            AddTopping(new Topping("", 0m));
        }

        public abstract void AddCrust(Crust c);
        public abstract void AddSize(Size s);
        public abstract void AddTopping(Topping t);

        public virtual decimal CalculatePrice()
        {
            PizzaPrice += Crust.Price;
            if(Crust.CheeseStuffed)
                PizzaPrice += Crust.StuffedPrice;

            PizzaPrice += Size.Price;
            
            foreach(Topping t in Toppings)
            {
                PizzaPrice += t.Price;
            }

            return PizzaPrice;
        }

        public override string ToString()
        {
            string pizzaDesc = "";
            pizzaDesc += Size.Name + " : ";
            pizzaDesc += Crust.Name + " : ";
            foreach(Topping t in Toppings)
            {
                pizzaDesc += t.Name + ", ";
            }
            return pizzaDesc;
        }
    }
}