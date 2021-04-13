using System;
using System.Collections.Generic;
using PizzaBox.Client.Controller;
using PizzaBox.Storing.Entities;
using Xunit;

namespace PizzaBox.Testing.Tests
{
    public class OrderPizzaTests
    {

        [Fact]
        public void TestGetOrderPizzasByOrderID()
        {
            var sut = OrderPizzaController.GetOrderPizzasByOrderID(1);

            bool isNull = sut == null;

            Assert.False(isNull);
        }
    }
}