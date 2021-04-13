using System;
using System.Collections.Generic;
using PizzaBox.Client.Controller;
using PizzaBox.Storing.Entities;
using Xunit;

namespace PizzaBox.Testing.Tests
{
    public class CrustTests
    {
        [Fact]
        public void TestGetCrusts()
        {
            var sut = CrustController.GetCrusts();

            bool isNull = sut == null;

            Assert.False(isNull);
        }

        [Fact]
        public void TestGetCrustsById()
        {
            var sut = CrustController.GetCrustById(1);

            bool isNull = sut == null;

            Assert.False(isNull);
        }
    }
}