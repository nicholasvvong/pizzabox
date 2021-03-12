using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models
{
    public class FreddyStore : AStore
    {
        public FreddyStore()
        {
            Name = "Freddy's Pizza Store";
            ToppingsList = new List<Topping>();
            SizeList = new List<Size>();
            CrustList = new List<Crust>();
            InitToppings();
            InitSize();
            InitCrust();
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
            AddSize("medium", 4.0m);
            AddSize("large", 5.0m);
        }
        protected override void InitCrust()
        {
            AddCrust("regular", 1.0m);
            AddCrust("hand-tossed", 1.5m);
            AddCrust("thin", 1.0m);
        }
    }
}