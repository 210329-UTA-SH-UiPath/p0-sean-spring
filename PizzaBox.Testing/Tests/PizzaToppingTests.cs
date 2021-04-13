using System;
using System.Collections.Generic;
using PizzaBox.Client.Controller;
using PizzaBox.Storing.Entities;
using Xunit;

namespace PizzaBox.Testing.Tests
{
    public class PizzaToppingTests
    {
        [Fact]
        public void TestGetPizzaToppingsByPizzaID()
        {
            var sut = PizzaToppingController.GetPizzaToppingsByPizzaID(1);

            bool isNull = sut == null;

            Assert.False(isNull);
        }
    }
}