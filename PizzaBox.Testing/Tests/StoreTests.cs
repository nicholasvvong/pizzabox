using PizzaBox.Domain.Models;
using Xunit;

namespace PizzaBox.Testing.Tests
{
    public class StoreTests
    {
        [Fact]
        public void Test_ChicagoStore()
        {
            var sut = new ChicagoStore();
            var expected = "Chicago Pizza";

            var actual = sut.Name;

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("Chicago Pizza")]
        [InlineData("Chicago Store")]
        public void Test_TChicagoStore(string expected)
        {
            var sut = new ChicagoStore();

            var actual = sut.Name;

            Assert.Equal(expected, actual);
        }
    }
}