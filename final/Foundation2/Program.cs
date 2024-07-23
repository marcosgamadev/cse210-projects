using System;

class Program
{
    static void Main()
    {

        Address address1 = new Address("Rua Espanha 286", "Contagem", "MG", "Brazil");
        Address address2 = new Address("Rua Bélgica 373", "Contagem", "MG", "Brazil");


        Customer customer1 = new Customer("Marcos Gama", address1);
        Customer customer2 = new Customer("Meily Gama", address2);


        Product product1 = new Product("Laptop", "P001", 1200.99, 1);
        Product product2 = new Product("Mouse", "P002", 25.50, 2);
        Product product3 = new Product("Keyboard", "P003", 45.75, 1);
        Product product4 = new Product("Monitor", "P004", 300.00, 1);


        Order order1 = new Order(customer1);
        order1.AddProduct(product1);
        order1.AddProduct(product2);
        order1.AddProduct(product3);

        Order order2 = new Order(customer2);
        order2.AddProduct(product1);
        order2.AddProduct(product4);


        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Total Price: R${order1.GetTotalCost():0.00}\n");

        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Total Price: R${order2.GetTotalCost():0.00}\n");
    }
}
