using System;

class Program
{
    static void Main(string[] args)
    {
        var cannedBeans = new Product("Canned Beans", "CB001", 1.99f, 3);
        var cannedTomatoes = new Product("Canned Tomatoes", "CT001", 2.99f, 2);
        var cannedCorn = new Product("Canned Corn", "CC001", 1.49f, 4);
        var cannedPeas = new Product("Canned Peas", "CP001", 1.29f, 5);
        var cannedCarrots = new Product("Canned Carrots", "CC002", 1.49f, 4);

        var austin = new Customer(
            "Austin",
            "Colt",
            new Address("490 Pioneer Road", "Rexburg", "ID", "USA")
        );
        var enrique = new Customer(
            "Enrique",
            "Gonzalez",
            new Address("123 Main Street", "Mexico City", "CDMX", "Mexico")
        );

        var order1 = new Order(
            new List<Product>() { cannedBeans, cannedTomatoes },
            austin
        );
        var order2 = new Order(
            new List<Product>() { cannedCorn, cannedPeas, cannedCarrots },
            enrique
        );
        
        var orders = new List<Order>() { order1, order2 };

        foreach (var order in orders)
        {
            Console.WriteLine("Packing Label:");
            Console.WriteLine(order.GetPackingLabel());
            Console.WriteLine("Shipping Label:");
            Console.WriteLine(order.GetShippingLabel());
            Console.WriteLine($"Total: ${order.CalculateFinalPrice()}");
            Console.WriteLine();
        }
    }
}