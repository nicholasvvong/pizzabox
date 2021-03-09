namespace PizzaBox.Domain.Abstracts
{
    public class Size : APizzaComponent
    {
        protected Size()
        {
            
        }
        public Size(string type, decimal p) : base(type, p)
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