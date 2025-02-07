using System;
using OnlineOrdering;

class Program
{
    static void Main(string[] args)
    {
        Address address1 = new Address("155 East 1230 North", "Provo", "Utah", "USA");
        Address address2 = new Address("3G Brugskensweg", "Geetbets", "Vlaams Brabant", "Belgium");

        Customer customer1 = new Customer("Reuben Domike", address1);
        Customer customer2 = new Customer("Lillian Putzeys", address2);

        List<Product> cart1 = new List<Product>();
        List<Product> cart2 = new List<Product>();

        Order order1 = new Order(customer1, cart1);
        Order order2 = new Order(customer2, cart2);

        order1.AddProduct(new Product("Rice Crackers", "100", 4, 30));
        order1.AddProduct(new Product("Lime Green Tie", "101", 30, 1));
        order1.AddProduct(new Product("Pineapple Notebook", "102", 5.00, 4));

        order2.AddProduct(new Product("Crochet Yarn", "103", 50, 3));
        order2.AddProduct(new Product("The Visitor Sculpture", "104", 100, 6));
        order2.AddProduct(new Product("Dwarf Sculpture", "105", 35, 2));
        order2.AddProduct(new Product("Dog Food", "106", 10, 5));

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