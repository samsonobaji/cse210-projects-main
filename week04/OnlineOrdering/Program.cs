using System;

namespace OnlineOrdering
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create first order (USA customer)
            Address address1 = new Address("123 Main St", "Rexburg", "ID", "USA");
            Customer customer1 = new Customer("John Smith", address1);
            Order order1 = new Order(customer1);

            Product product1 = new Product("Laptop", "LAP001", 999.99, 1);
            Product product2 = new Product("Mouse", "MOU001", 19.99, 2);
            Product product3 = new Product("Keyboard", "KEY001", 49.99, 1);

            order1.AddProduct(product1);
            order1.AddProduct(product2);
            order1.AddProduct(product3);

            // Create second order (International customer)
            Address address2 = new Address("456 High St", "London", "Greater London", "UK");
            Customer customer2 = new Customer("Emma Wilson", address2);
            Order order2 = new Order(customer2);

            Product product4 = new Product("Monitor", "MON001", 299.99, 2);
            Product product5 = new Product("Headphones", "HEA001", 79.99, 1);

            order2.AddProduct(product4);
            order2.AddProduct(product5);

            // Display first order
            Console.WriteLine("Order 1:");
            Console.WriteLine(order1.GetPackingLabel());
            Console.WriteLine(order1.GetShippingLabel());
            Console.WriteLine($"Total Cost: ${order1.GetTotalCost():F2}");
            Console.WriteLine("\n----------------------------------------\n");

            // Display second order
            Console.WriteLine("Order 2:");
            Console.WriteLine(order2.GetPackingLabel());
            Console.WriteLine(order2.GetShippingLabel());
            Console.WriteLine($"Total Cost: ${order2.GetTotalCost():F2}");
        }
    }
}