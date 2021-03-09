using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models
{
    public class MeatPizza : APizza
    {
        protected List<string> _presetToppings;

        public MeatPizza()
        {
            _presetToppings = new List<string>{
                "pepperoni",
                "ham",
                "sauage",
                "salami"
            };
        }

        public MeatPizza(List<string> toppings)
        {

        }

        public override void AddCrust(Crust c)
        {
            Crust = c;
        }

        public override void AddSize(Size s)
        {
            Size = s;
        }

        public override void AddTopping(Topping t)
        {
            Toppings = new List<Topping>
            {
                new Topping("Pepporino", 5),
                new Topping("Ham", 3),
                new Topping("Sausage", 2),
                new Topping("Salami", 3)
            };
        }

        public void AddToppings(AStore store)
        {
            foreach(string s in _presetToppings)
            {
                foreach(Topping t in store.ToppingsList)
                {
                    if(t.Name == s)
                    {
                        Toppings.Add(t);
                        break;
                    }
                }
            }
        }
    }
}