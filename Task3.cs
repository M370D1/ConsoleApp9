using System;
using System.Collections.Generic;

namespace ConsoleApp9
{
    class Task3
    {
        public abstract class Product
        {
            private string _name;
            private decimal _price;

            public string Name
            {
                get { return _name; }
                set
                {
                    if (string.IsNullOrWhiteSpace(value))
                        throw new ArgumentException("Name cannot be null or empty.");
                    _name = value;
                }
            }

            public decimal Price
            {
                get { return _price; }
                set
                {
                    if (value < 0)
                        throw new ArgumentException("Price cannot be negative.");
                    _price = value;
                }
            }

            protected Product(string name, decimal price)
            {
                Name = name;
                Price = price;
            }

            public void DisplayInfo()
            {
                Console.WriteLine($"Product: {Name}, Price: {Price:C}");
            }

            public abstract decimal GetDiscountedPrice();
        }

        public class Electronics : Product
        {
            public Electronics(string name, decimal price) : base(name, price) { }

            public override decimal GetDiscountedPrice()
            {
                return Price * 0.90M; // 10% discount
            }
        }

        public class Clothing : Product
        {
            public Clothing(string name, decimal price) : base(name, price) { }

            public override decimal GetDiscountedPrice()
            {
                return Price * 0.80M; // 20% discount
            }
        }

        public static void Execute()
        {
            var laptop = new Electronics("Laptop", 1500M);
            var tshirt = new Clothing("T-Shirt", 50M);

            List<Product> products = new List<Product> { laptop, tshirt };

            foreach (var product in products)
            {
                product.DisplayInfo();
                Console.WriteLine($"Discounted Price: {product.GetDiscountedPrice():C}\n");
            }
        }
    }
}
