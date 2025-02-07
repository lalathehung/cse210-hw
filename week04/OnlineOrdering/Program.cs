using System;
using OnlineOrdering;

class Program
{
    static void Main(string[] args)
    {
        Address address1 = new Address("123 Apple St.", "Orchardville", "California", "USA");
        Address address2 = new Address("456 Naranja St.", "San Cristóbal de las Casas", "Chiapas", "Mexico");

        Customer customer1 = new Customer("Lucy McDoodle", address1);
        Customer customer2 = new Customer("Zack Zackerson", address2);

        List<Product> cart1 = new List<Product>();
        List<Product> cart2 = new List<Product>();

        Order order1 = new Order(customer1, cart1);
        Order order2 = new Order(customer2, cart2);

        order1.AddProduct(new Product("Chocolate", "100", 6.05, 20));
        order1.AddProduct(new Product("Teddy Bear", "101", 20, 1));
        order1.AddProduct(new Product("Valentines", "102", 5.00, 2));

        order2.AddProduct(new Product("Swimsuit", "103", 35, 3));
        order2.AddProduct(new Product("Surfboard", "104", 300, 1));
        order2.AddProduct(new Product("Snorkle", "105", 25, 2));
        order2.AddProduct(new Product("Beach Towel", "106", 10, 6));

        Console.WriteLine("\nORDERS");

        double total1 = order1.OrderTotal();
        Console.WriteLine("\n-----Order One-----\n");
        Console.WriteLine($"Total: ${total1}");
        order1.PackingLabel();
        order1.ShippingLabel();

        double total2 = order2.OrderTotal();
        Console.WriteLine("\n-----Order Two-----\n");
        Console.WriteLine($"Total: ${total2}");
        order2.PackingLabel();
        order2.ShippingLabel();        
    }
}