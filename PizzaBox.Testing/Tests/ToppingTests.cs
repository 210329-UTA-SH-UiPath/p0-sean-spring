using System;
using System.Collections.Generic;
using PizzaBox.Client.Controller;
using PizzaBox.Storing.Entities;
using Xunit;

namespace PizzaBox.Testing.Tests
{
    public class ToppingTests
    {
        [Fact]
        public void TestGetToppings()
        {
            var sut = ToppingController.GetToppings();

            bool isNull = sut == null;

            Assert.False(isNull);
        }

        [Fact]
        public void TestGetToppingsById()
        {
            var sut = ToppingController.GetToppingById(1);

            bool isNull = sut == null;

            Assert.False(isNull);
        }
    }
}