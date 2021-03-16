namespace PizzaBox.Domain.Abstracts
{
    public class Crust : APizzaComponent
    {
        public bool CheeseStuffed { get; set; }
        public decimal StuffedPrice { get; set; }
        protected Crust()
        {

        }
        public Crust(string type, decimal p) : base(type, p)
        {
            CheeseStuffed = false;
            StuffedPrice = 1.50m;
        }
        protected override void AddName(string type)
        {
            Name = type;
        }

        protected override void AddPrice(decimal p)
        {
            Price = p;
        }

        public void ChangeStuffedCrust()
        {
            if(CheeseStuffed)
                CheeseStuffed = false;
            else
                CheeseStuffed = true;
        }
    }
}