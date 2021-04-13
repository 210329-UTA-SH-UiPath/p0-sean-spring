using System;
using PizzaBox.Client.Controller;
using PizzaBox.Storing.Entities;
using Xunit;


namespace PizzaBox.Testing.Tests
{

    public class PizzaTests
    {

        [Fact]
        public void TestName()
        {
            //Given
            var sut = new Pizza();

            sut.Name = "Test";
            //When
            var actual = sut.Name;
            //Then

            Assert.True(actual == "Test");
        }

        [Fact]
        public void TestGetPizzas()
        {
            var sut = PizzaController.GetPizzas();

            bool isNull = sut == null;

            Assert.False(isNull);
        }

        [Fact]
        public void TestGetCrustsById()
        {
            var sut = PizzaController.GetPizzaById(1);

            bool isNull = sut == null;

            Assert.False(isNull);
        }
    }
}