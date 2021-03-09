namespace PizzaBox.Domain.Abstracts
{
    public class Topping : APizzaComponent
    {
        public Topping(string type, decimal p) : base(type, p)
        {

        }
        protected override void AddName(string type)
        {
            Name = type;
        }

        protected override void AddPrice(decimal p)
        {
            Price = p;
        }
    }
}