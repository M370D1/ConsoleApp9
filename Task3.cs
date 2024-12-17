namespace ConsoleApp9
{
    class Task3
    {
        public abstract class Product
        {
            public string Name { get; set; }
            public decimal Price { get; set; }

            public void DisplayInfo()
            {
                Console.WriteLine($"Product: {Name}, Price: {Price:C}");
            }

            public abstract decimal GetDiscountedPrice();
        }

        public class Electronics : Product
        {
            public override decimal GetDiscountedPrice()
            {
                return Price * 0.90M;
            }
        }

        public class Clothing : Product
        {
            public override decimal GetDiscountedPrice()
            {
                return Price * 0.80M;
            }
        }

        public static void Execute()
        {
            var laptop = new Electronics { Name = "Laptop", Price = 1500M };
            var tshirt = new Clothing { Name = "T-Shirt", Price = 50M };

            List<Product> products = new List<Product> { laptop, tshirt };

            foreach (var product in products)
            {
                product.DisplayInfo();
                Console.WriteLine($"Discounted Price: {product.GetDiscountedPrice():C}\n");
            }
        }

    }
}
