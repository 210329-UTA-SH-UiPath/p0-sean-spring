using System;
using System.Collections.Generic;
using PizzaBox.Client.Controller;
using PizzaBox.Storing.Entities;
using Xunit;

namespace PizzaBox.Testing.Tests
{
    public class OrderTests
    {
        [Fact]
        public void TestGetOrderByCustomerId()
        {
            var sut = OrderController.GetOrderByCustomerId(1);

            bool isNull = sut == null;

            Assert.False(isNull);
        }
    }
}