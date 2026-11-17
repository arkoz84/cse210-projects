using System;
using System.Collections.Generic;

public class Order
{
    private Customer _customer;
    private List<Product> _products = new List<Product>();

    public Order(Customer customer)
    {
        _customer = customer;
    }

    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    public decimal GetTotalCost()
    {
        decimal total = 0m;

        foreach (Product product in _products)
        {
            total += product.GetTotalCost();
        }

        if (_customer.IsInUSA())
        {
            total += 5m;
        }
        else
        {
            total += 35m;
        }

        return total;
    }

    public string GetPackingLabel()
    {
        List<string> lines = new List<string>();

        foreach (Product product in _products)
        {
            lines.Add(product.GetPackingLabelLine());
        }

        return string.Join(Environment.NewLine, lines);
    }

    public string GetShippingLabel()
    {
        return _customer.GetShippingLabel();
    }
}