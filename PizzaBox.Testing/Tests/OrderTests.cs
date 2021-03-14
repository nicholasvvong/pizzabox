using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;
using Xunit;

namespace PizzaBox.Testing.Tests
{
    public class OrderTests
    {
        [Fact]
        public void Test_OrderCreateCustName()
        {
            var tempC = new Customer("Bob");
            var tempS = new CaliforniaStore();
            var sut = new Order(tempC, tempS);

            var expected = "Bob";
            var actual = sut.Name;

            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Test_OrderCreateStoreName()
        {
            var tempC = new Customer("Bob");
            var tempS = new CaliforniaStore();
            var sut = new Order(tempC, tempS);

            var expected = "CPK";
            var actual = sut.StoreName;

            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Test_OrderAddPizza()
        {
            CustomPizza tempP = new CustomPizza();
            tempP.Type = "Meat Pizza";
            tempP.AddCrust(new Crust("regular", 1.0m));
            tempP.AddSize(new Size("medium", 4.0m));
            tempP.AddTopping(new Topping("beef", 0.66m));
            tempP.AddTopping(new Topping("chicken", 1.0m));
            tempP.AddTopping(new Topping("ham", 0.75m));
            tempP.AddTopping(new Topping("mushroom", 0.50m));
            tempP.AddTopping(new Topping("olive", 0.33m));

            decimal TotalPrice = 1.0m + 4.0m + 0.66m + 1.0m + 0.75m + 0.50m + 0.33m;

            var expected = "Meat Pizza : medium : regular : beef chicken ham mushroom olive - " + TotalPrice;

            Order sut = new Order();
            sut.AddPizza(tempP);

            var actual = sut.Pizzas[0].ToString();

            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Test_OrderFinishPizza()
        {
            APizza tempP = new CustomPizza();
            Order sut = new Order();

            sut.CurrentPizza = tempP;
            sut.FinishPizza();
            
            APizza actual = sut.CurrentPizza;
            APizza expected = null;

            Assert.Equal(expected, actual);
        }
    }
}