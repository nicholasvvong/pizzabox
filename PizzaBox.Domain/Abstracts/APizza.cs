using System.Collections.Generic;

namespace PizzaBox.Domain.Abstracts
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class APizza
    {
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

        public virtual int calculatePrice()
        {

            return 0;
        }
    }
}