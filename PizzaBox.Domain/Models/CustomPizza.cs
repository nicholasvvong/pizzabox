using System;
using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models
{
    public class CustomPizza : APizza
    {
        public CustomPizza() : base()
        {
            Type = "Custom Pizza";
        }
        public override void AddCrust(Crust c)
        {
            Crust = c;
            CalculatePrice();
        }

        public override void AddSize(Size s)
        {
            Size = s;
            CalculatePrice();
        }

        public override void AddTopping(Topping t)
        {
            if(Toppings.Count > MaxToppings + 1)
            {
                Console.WriteLine("Max Amount of Toppings reached ({0}). ", MaxToppings);
                return;
            }
            else
            {
                Toppings.Add(t);
            }
            CalculatePrice();
        }
    }
}