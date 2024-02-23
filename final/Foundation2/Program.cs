using System;

class Program
{
    static void Main(string[] args)
    {
        {
        // Create products
        Product product1 = new Product("Iphone XR", "001", 50.00, 1);
        Product product2 = new Product("Pandora earring", "002", 15.00, 3);
        Product product3 = new Product("Air force one", "003", 10.00, 1);



        Address address1 = new Address("123 Main St", "Anytown", "NY", "USA");
        Customer customer1 = new Customer("Alice", address1);

        Address address2 = new Address("456 Elm St", "Another Town", "CA", "Canada");
        Customer customer2 = new Customer("Bob", address2);


        // Create orders
        Order order1 = new Order(customer1);
        order1.AddProduct(product1);

        Order order2 = new Order(customer2);
        order2.AddProduct(product2);
        order2.AddProduct(product3);

        // Display packing labels, shipping labels, and total prices
        Console.WriteLine("Order 1:");
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order1.GetTotalPrice()}");

        Console.WriteLine();

        Console.WriteLine("Order 2:");
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order2.GetTotalPrice()}");
        }
    }
}