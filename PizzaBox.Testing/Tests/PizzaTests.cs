using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;
using Xunit;

namespace PizzaBox.Testing.Tests
{
    public class PizzaTests
    {
        [Fact]
        public void Test_CreateCustomPizzaName()
        {
            var sut = new CustomPizza();
            var expected = "Custom Pizza";

            var actual = sut.Type;

            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Test_CreateCustomPizzaDefaultCrust()
        {
            var sut = new CustomPizza();
            var expected = new Crust("", 0m).Name;

            var actual = sut.Crust.Name;

            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Test_CreateCustomPizzaDefaultSize()
        {
            var sut = new CustomPizza();
            var expected = new Size("", 0m).Name;

            var actual = sut.Size.Name;

            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Test_CreateCustomPizzaDefaultToppings()
        {
            var sut = new CustomPizza();
            var expected = new Size("", 0m).Name;

            var actual = sut.Size.Name;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Test_CustomPizzaToString()
        {
            CustomPizza sut = new CustomPizza();
            sut.Type = "Meat Pizza";
            sut.AddCrust(new Crust("regular", 1.0m));
            sut.AddSize(new Size("medium", 4.0m));
            sut.AddTopping(new Topping("beef", 0.66m));
            sut.AddTopping(new Topping("chicken", 1.0m));
            sut.AddTopping(new Topping("ham", 0.75m));
            sut.AddTopping(new Topping("mushroom", 0.50m));
            sut.AddTopping(new Topping("olive", 0.33m));

            decimal TotalPrice = 1.0m + 4.0m + 0.66m + 1.0m + 0.75m + 0.50m + 0.33m;

            var expected = "Meat Pizza : medium : regular : beef chicken ham mushroom olive - " + TotalPrice;
            var actual = sut.ToString();

            Assert.Equal(expected, actual);
        }
    }
}