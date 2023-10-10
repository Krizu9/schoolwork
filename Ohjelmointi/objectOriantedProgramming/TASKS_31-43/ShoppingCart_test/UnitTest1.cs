using System.Collections.Generic;
using NUnit.Framework;
using ShoppingCart;

namespace ShoppingCart.Tests
{
    [TestFixture]
    public class ShoppingCartTests
    {
        [Test]
        public void TestCartWithNoProducts()
        {
            List<Product> cart = new List<Product>();
            Assert.That(cart.Count, Is.EqualTo(0));

        }

        [Test]
        public void TestCartWithOneProduct()
        {
            List<Product> cart = new List<Product>();
            cart.Add(new Product("Milk", 1.4));
            Assert.That(cart.Count, Is.EqualTo(1));

        }

        [Test]
        public void TestCartWithTwoProducts()
        {
            List<Product> cart = new List<Product>();
            cart.Add(new Product("Milk", 1.4));
            cart.Add(new Product("Bread", 2.2));
            Assert.That(cart.Count, Is.EqualTo(2));

        }

        [Test]
        public void TestCartWithFiveProducts()
        {
            List<Product> cart = new List<Product>();
            cart.Add(new Product("Milk", 1.4));
            cart.Add(new Product("Bread", 2.2));
            cart.Add(new Product("Butter", 3.2));
            cart.Add(new Product("Cheese", 4.2));
            cart.Add(new Product("Eggs", 2.0));
            Assert.That(cart.Count, Is.EqualTo(5));

        }
    }
}
