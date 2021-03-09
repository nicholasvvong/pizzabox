namespace PizzaBox.Domain.Abstracts
{
    public abstract class APizzaComponent
    {
        public string Name { get; set; }
        public decimal Price { get; set; }

        protected APizzaComponent()
        {

        }

        public APizzaComponent(string type, decimal p)
        {
            FactoryMethod(type, p);
        }

        private void FactoryMethod(string type, decimal p)
        {
            AddName(type);
            AddPrice(p);
        }

        protected abstract void AddName(string type);
        protected abstract void AddPrice(decimal p);

    }
}