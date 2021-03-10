using System;
using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models
{
    public class CustomPizza : APizza
    {
        public CustomPizza() : base()
        {
            type = "Custom Pizza";
        }
        public override void AddCrust(Crust c)
        {
            Crust = new Crust("medium", 3);
        }

        public override void AddSize(Size s)
        {
            Size = new Size("medium", 3);
        }

        public override void AddTopping(Topping t)
        {
            if(Toppings.Count > _maxtoppings)
            {
                Console.WriteLine("Max Amount of Toppings reached ({0}). ", _maxtoppings);
                return;
            }
            else
            {
                Toppings.Add(t);
            }
        }
    }
}