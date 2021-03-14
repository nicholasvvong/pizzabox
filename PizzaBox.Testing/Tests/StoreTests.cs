using PizzaBox.Domain.Models;
using PizzaBox.Domain.Singletons;
using Xunit;

namespace PizzaBox.Testing.Tests
{
    public class StoreTests
    {
        [Fact]
        public void Test_ChicagoStore()
        {
            var sut = new ChicagoStore();
            var expected = "Chicago Pizza Store";

            var actual = sut.Name;

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("Chicago Pizza Store")] 
        public void Test_TChicagoStore(string expected)
        {
            var sut = new ChicagoStore();

            var actual = sut.Name;

            Assert.Equal(expected, actual);
        }
        
        [Fact]
        public void Test_CaliforniaStore()
        {
            var sut = new CaliforniaStore();
            var expected = "CPK";
            var actual = sut.Name;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Test_FreddyStore()
        {
            var sut = new FreddyStore();
            var expected = "Freddy's Pizza Store";
            var actual = sut.Name;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Test_NewYorkStore()
        {
            var sut = new NewYorkStore();
            var expected = "NewYork Pizza Store";
            var actual = sut.Name;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Test_CaliforniaStoreToppingsPrice()
        {
            var sut = StoreSingleton.Instance;
            decimal CaliforniaStoreToppingsExpected = 0.66m + 1.0m + 0.75m + 0.50m + 0.33m + 0.40m + 0.75m + 0.50m + 0.70m + 0.80m;
            decimal actual = 0.0m;

            for(int i = 0; i < sut.Stores.Count; i++)
            {
                var curStore = sut.Stores[i];
                if(curStore is CaliforniaStore)
                {
                    for(int j = 0; j < curStore.ToppingsList.Count; j++)
                    {
                        actual += curStore.ToppingsList[j].Price;
                    }

                    Assert.Equal(CaliforniaStoreToppingsExpected, actual);
                }
            }
        }

        [Fact]
        public void Test_ChicagoStoreToppingsPrices()
        {
            var sut = StoreSingleton.Instance;
            decimal ChicagoStoreToppingsExpected = 0.75m + 1.5m + 0.57m + 0.45m + 0.25m + 0.30m + 0.50m + 0.50m + 0.70m + 0.70m + 1.0m + 0.25m;
            decimal actual = 0.0m;

            for(int i = 0; i < sut.Stores.Count; i++)
            {
                var curStore = sut.Stores[i];
                if(curStore is ChicagoStore)
                {
                    for(int j = 0; j < curStore.ToppingsList.Count; j++)
                    {
                        actual += curStore.ToppingsList[j].Price;
                    }

                    Assert.Equal(ChicagoStoreToppingsExpected, actual);
                }
            }
        }
    }
}