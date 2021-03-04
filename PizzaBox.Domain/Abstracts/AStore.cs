namespace PizzaBox.Domain.Abstracts
{
    public abstract class AStore
    {
        public string Name{ get;  protected set; } //Property

        public override string ToString()
        {
            return Name;
        }
    }
}