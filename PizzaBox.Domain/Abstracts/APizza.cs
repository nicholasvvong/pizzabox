using System.Collections.Generic;

namespace PizzaBox.Domain.Abstracts
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class APizza
    {
        private int _minToppings = 2;
        private int _maxtoppings = 5;
        public List<Topping> Toppings { get; set; }
        public Crust Crust { get; set; }
        public Size Size{ get; set; }

        public APizza()
        {
            FactoryMethod();
        }

        private void FactoryMethod()
        {
            AddCrust();
            AddSize();
            AddToppings();
        }

        protected abstract void AddCrust();
        protected abstract void AddSize();
        protected abstract void AddToppings();

        public virtual int CalculatePrice()
        {

            return 0;
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