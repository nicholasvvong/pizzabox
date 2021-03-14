using System;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;
using Xunit;

namespace PizzaBox.Testing.Tests
{
    public class CustomerTests
    {
        [Fact]
        public void Test_CustomerCreateName()
        {
            Customer sut = new Customer("Bill");
            var expected = "Bill";

            var actual = sut.Name;

            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Test_CustomerPassword()
        {
            Customer sut = new Customer("Bill");
            var expected = "Bill";

            var actual = sut.password;

            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Test_CustomerStartOrderCheckStoreFail()
        {
            Customer sut = new Customer("Bill");
            sut.LastStore = new CaliforniaStore();
            sut.LastTimeOrdered = DateTime.UtcNow;

            var expected = false;


            Assert.Equal(expected, sut.StartOrderCheck(new ChicagoStore()));
        }
        [Fact]
        public void Test_CustomerStartOrderCheckTrue()
        {
            Customer sut = new Customer("Bill");
            sut.LastStore = new CaliforniaStore();
            sut.LastTimeOrdered = DateTime.MinValue;

            var expected = true;


            Assert.Equal(expected, sut.StartOrderCheck(new CaliforniaStore()));
        }
    }
}