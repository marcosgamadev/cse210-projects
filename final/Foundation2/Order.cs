using System;
using System.Collections.Generic;

class Order
{
    private List<Product> Products { get; set; }
    private Customer Customer { get; set; }

    public Order(Customer customer)
    {
        Products = new List<Product>();
        Customer = customer;
    }

    public void AddProduct(Product product)
    {
        Products.Add(product);
    }

    public double GetTotalCost()
    {
        double total = 0;
        foreach (var product in Products)
        {
            total += product.GetTotalCost();
        }

        double shippingCost = Customer.IsInUSA() ? 5 : 35;
        total += shippingCost;

        return total;
    }

    public string GetPackingLabel()
    {
        string label = "Packing Label:\n";
        foreach (var product in Products)
        {
            label += $"{product.GetName()} (ID: {product.GetProductId()})\n";
        }
        return label;
    }

    public string GetShippingLabel()
    {
        string label = $"Shipping Label:\n{Customer.GetName()}\n{Customer.GetAddress().GetFullAddress()}";
        return label;
    }
}
