namespace PizzaBox.Domain.Abstracts
{
    public class Crust : APizzaComponent
    {
        public bool CheeseStuffed { get; protected set; }
        public Crust(string type, decimal p) : base(type, p)
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

        protected void ChangeStuffedCrust()
        {
            if(CheeseStuffed)
                CheeseStuffed = false;
            else
                CheeseStuffed = true;
        }
    }
}