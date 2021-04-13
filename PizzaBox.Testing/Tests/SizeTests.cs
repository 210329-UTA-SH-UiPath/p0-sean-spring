using System;
using System.Collections.Generic;
using PizzaBox.Client.Controller;
using PizzaBox.Storing.Entities;
using Xunit;

namespace PizzaBox.Testing.Tests
{
    public class SizeTests
    {
        [Fact]
        public void TestGetSizes()
        {
            var sut = SizeController.GetSizes();

            bool isNull = sut == null;

            Assert.False(isNull);
        }

        [Fact]
        public void TestGetSizesById()
        {
            var sut = SizeController.GetSizeById(1);

            bool isNull = sut == null;

            Assert.False(isNull);
        }
    }
}