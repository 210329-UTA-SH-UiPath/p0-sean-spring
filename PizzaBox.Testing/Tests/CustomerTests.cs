using System;
using System.Collections.Generic;
using System.IO;
using PizzaBox.Client.Controller;
using PizzaBox.Storing.Entities;
using Xunit;

namespace PizzaBox.Testing.Tests
{
    public class CustomerTests
    {
        [Fact]
        public void TestGetCustomerByName()
        {
            using (var input = new StringReader("Sean"))
            {
                Console.SetIn(input);
                var sut = CustomerController.GetCustomerByName();

                bool isNull = sut == null;

                Assert.False(isNull);
            }

        }
    }
}