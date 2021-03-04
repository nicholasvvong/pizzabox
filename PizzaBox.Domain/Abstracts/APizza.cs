using System.Collections.Generic;

namespace PizzaBox.Domain.Abstracts
{
    public abstract class APizza
    {
        public string Name{ get;  set; } //Property
        public List<string> toppings { get; set; }
        public string crust { get; set; }
    }
}