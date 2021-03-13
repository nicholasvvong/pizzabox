using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models
{
    public class NewYorkStore : AStore
    {
        public NewYorkStore()
        {
            Name = "NewYork Pizza Store";
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
            AddTopping("beef", 1.00m);
            AddTopping("chicken", 0.75m);
            AddTopping("ham", 0.75m);
            AddTopping("mushroom", 0.40m);
            AddTopping("olive", 0.20m);
            AddTopping("peppers", 0.35m);
            AddTopping("pepporoni", 0.65m);
            AddTopping("pineapple", 0.55m);
            AddTopping("salami", 0.80m);
            AddTopping("sausage", 0.85m);
            AddTopping("meat ball", 1.00m);
            AddTopping("anchovies", 1.20m);
        }
        protected override void InitSize()
        {
            AddSize("medium", 4.5m);
            AddSize("large", 5.5m);
            AddSize("extra large", 6.5m);
        }
        protected override void InitCrust()
        {
            AddCrust("regular", 1.0m);
            AddCrust("hand-tossed", 1.0m);
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