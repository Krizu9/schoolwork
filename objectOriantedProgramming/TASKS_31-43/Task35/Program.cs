using System;
using System.Collections.Generic;

namespace ShoppingCart
{
    public class Product
    {
        public string Name { get; set; }
        public double Price { get; set; }

        public Product(string name, double price)
        {
            Name = name;
            Price = price;
        }

        public override string ToString()
        {
            return $"{Name} {Price} e";
        }
    }

    public class ShoppingCart
    {
        static void Main(string[] args)
        {
            List<Product> cart = new List<Product>();
            cart.Add(new Product("Milk", 1.4));
            cart.Add(new Product("Bread", 2.2));
            cart.Add(new Product("Butter", 3.2));
            cart.Add(new Product("Cheese", 4.2));

            Console.WriteLine("Your products in shopping cart:");
            foreach (Product product in cart)
            {
                Console.WriteLine($"- product: {product}");
            }
            Console.WriteLine($"There are {cart.Count} products in the shopping cart.");
            Console.ReadLine();
        }
    }
}