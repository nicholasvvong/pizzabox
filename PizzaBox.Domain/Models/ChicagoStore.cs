using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models
{
    public class ChicagoStore : AStore
    {
        public ChicagoStore()
        {
            Name = "Chicago Pizza Store";
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
            AddTopping("beef", 0.75m);
            AddTopping("chicken", 1.5m);
            AddTopping("ham", 0.57m);
            AddTopping("mushroom", 0.45m);
            AddTopping("olive", 0.25m);
            AddTopping("peppers", 0.30m);
            AddTopping("pepporoni", 0.50m);
            AddTopping("pineapple", 0.50m);
            AddTopping("salami", 0.70m);
            AddTopping("sausage", 0.70m);
            AddTopping("bacon", 1.0m);
            AddTopping("onion", 0.25m);
        }
        protected override void InitSize()
        {
            AddSize("small", 4.50m);
            AddSize("medium", 5.50m);
            AddSize("large", 6.50m);
        }
        protected override void InitCrust()
        {
            AddCrust("regular", 0.50m);
            AddCrust("hand-tossed", 1.0m);
            AddCrust("thin", 0.50m);
        }

        protected override void InitPresetPizza()
        {
            /*Meat*/
            CustomPizza tempP = new CustomPizza();
            tempP.Type = "Meat Pizza";
            tempP.AddCrust(CrustList[0]);
            tempP.AddTopping(ToppingsList[0]);
            tempP.AddTopping(ToppingsList[10]);
            tempP.AddTopping(ToppingsList[2]);
            tempP.AddTopping(ToppingsList[6]);
            tempP.AddTopping(ToppingsList[8]);
            tempP.CalculatePrice();
            PresetPizza.Add(tempP);
            /*Deluxe*/
            tempP = new CustomPizza();
            tempP.Type = "Deluxe Pizza";
            tempP.AddCrust(CrustList[0]);
            tempP.AddTopping(ToppingsList[6]);
            tempP.AddTopping(ToppingsList[9]);
            tempP.AddTopping(ToppingsList[3]);
            tempP.AddTopping(ToppingsList[5]);
            tempP.AddTopping(ToppingsList[11]);
            tempP.CalculatePrice();
            PresetPizza.Add(tempP);
        }
    }
}