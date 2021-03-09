using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models
{
    public class CustomPizza : APizza
    {
        protected override void AddCrust()
        {
            Crust = new Crust("medium", 3);
        }

        protected override void AddSize()
        {
            Size = new Size("medium", 3);
        }

        protected override void AddToppings()
        {
            Toppings = new List<Topping>
            {
                new Topping("Pepporino", 5),
                new Topping("Pineapple", 3),
                new Topping("Mushroom", 2)
            };
        }
    }
}