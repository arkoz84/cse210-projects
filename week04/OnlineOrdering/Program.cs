using System;

class Program
{
    static void Main(string[] args)
    {
        Address usAddress = new Address("50 North Temple", "Salt Lake City", "Utah", "USA");
        Customer usCustomer = new Customer("Luis Perez", usAddress);
        Order usOrder = new Order(usCustomer);

        usOrder.AddProduct(new Product("Microsoft Surface Pro", "196388550562", 835.00m, 2));
        usOrder.AddProduct(new Product("Surface Slim Pen 2", "889842779134", 100.00m, 5));

        Address peruAddress = new Address("Bajada Agua Dulce 155", "Chorrillos", "Lima", "Peru");
        Customer peruCustomer = new Customer("Felipe Leon", peruAddress);
        Order peruOrder = new Order(peruCustomer);

        peruOrder.AddProduct(new Product("STANLEY IceFlow Flip Straw 2.0", "041604393761", 35.00m, 5));
        peruOrder.AddProduct(new Product("Lenovo Legion Gaming Laptop Backpack", "Gb800", 99.99m, 3));

        DisplayOrder(1, usOrder);
        Console.WriteLine();
        DisplayOrder(2, peruOrder);
    }
        static void DisplayOrder(int orderNumber, Order order)
    {
        Console.WriteLine($"Order {orderNumber}");
        Console.WriteLine("Packing label");
        Console.WriteLine(order.GetPackingLabel());
        Console.WriteLine();

        Console.WriteLine("Shipping label");
        Console.WriteLine(order.GetShippingLabel());
        Console.WriteLine();

        Console.WriteLine($"Order total: ${order.GetTotalCost():F2}");
    }
}