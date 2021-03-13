using System;
using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models
{
    public class CaliforniaStore : AStore
    {
        public CaliforniaStore()
        {
            Name = "CPK";
            PresetPizza = new List<APizza>();
            ToppingsList = new List<Topping>();
            SizeList = new List<Size>();
            CrustList = new List<Crust>();
            
            /* InitToppings();
            InitSize();
            InitCrust();  
            InitPresetPizza(); */
            
        }

        protected override void InitToppings()
        {
            AddTopping("beef", 0.66m);
            AddTopping("chicken", 1.0m);
            AddTopping("ham", 0.75m);
            AddTopping("mushroom", 0.50m);
            AddTopping("olive", 0.33m);
            AddTopping("peppers", 0.40m);
            AddTopping("pepporoni", 0.75m);
            AddTopping("pineapple", 0.50m);
            AddTopping("salami", 0.70m);
            AddTopping ("sausage", 0.80m);
        }
        protected override void InitSize()
        {
            AddSize("small", 3.0m);
            AddSize("medium", 4.0m);
            AddSize("large", 5.0m);
            AddSize("extra large", 6.0m);
        }
        protected override void InitCrust()
        {
            AddCrust("regular", 1.0m);
            AddCrust("hand-tossed", 1.5m);
            AddCrust("thin", 1.0m);
        }
        
        protected override void InitPresetPizza()
        {
            /*Meat*/
            CustomPizza tempP = new CustomPizza();
            tempP.Type = "Meat Pizza";
            tempP.AddCrust(CrustList[0]);
            tempP.AddTopping(ToppingsList[0]);
            tempP.AddTopping(ToppingsList[1]);
            tempP.AddTopping(ToppingsList[2]);
            tempP.AddTopping(ToppingsList[6]);
            tempP.AddTopping(ToppingsList[8]);
            tempP.CalculatePrice();
            PresetPizza.Add(tempP);
            /*Hawaiian*/
            tempP = new CustomPizza();
            tempP.Type = "Hawaiian Pizza";
            tempP.AddCrust(CrustList[0]);
            tempP.AddTopping(ToppingsList[2]);
            tempP.AddTopping(ToppingsList[5]);
            tempP.AddTopping(ToppingsList[7]);
            tempP.CalculatePrice();
            PresetPizza.Add(tempP);
        }
        
    }
}