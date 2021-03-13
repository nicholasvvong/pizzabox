using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models
{
    public class FreddyStore : AStore
    {
        public FreddyStore()
        {
            Name = "Freddy's Pizza Store";
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
            AddTopping("mushroom", 1.00m);
            AddTopping("olive", 0.40m);
            AddTopping("peppers", 0.45m);
            AddTopping("pineapple", 0.75m);
            AddTopping("onions", 0.33m);
            AddTopping("tomatoes", 0.50m);
            AddTopping("spinach", 0.60m);
        }
        protected override void InitSize()
        {
            AddSize("medium", 5.0m);
            AddSize("large", 6.0m);
        }
        protected override void InitCrust()
        {
            AddCrust("regular", 1.5m);
            AddCrust("hand-tossed", 2.0m);
            AddCrust("thin", 1.0m);
        }

        protected override void InitPresetPizza()
        {
            /*Veggie*/
            CustomPizza tempP = new CustomPizza();
            tempP.Type = "Basic Veggie Pizza";
            tempP.AddCrust(CrustList[0]);
            tempP.AddTopping(ToppingsList[0]);
            tempP.AddTopping(ToppingsList[1]);
            tempP.AddTopping(ToppingsList[4]);
            tempP.AddTopping(ToppingsList[6]);
            tempP.CalculatePrice();
            PresetPizza.Add(tempP);
        }
    }
}