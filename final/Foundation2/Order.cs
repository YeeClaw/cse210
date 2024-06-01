using System.Text;

public class Order
{
    public List<Product> Products { get; set; }
    public Customer Customer { get; set; }
    
    public Order(List<Product> products, Customer customer)
    {
        Products = products;
        Customer = customer;
    }

    public float CalculateFinalPrice()
    {
        var price = 0f;
        
        foreach (var product in Products)
        {
            price += product.CalculateTotalCost();
        }

        if (Customer.IsResidentUsa())
        {
            price += 5;
        }
        else
        {
            price += 35;
        }
        
        return price;
    }

    public string GetPackingLabel()
    {
        var packingLabel = new StringBuilder();
        foreach (var product in Products)
        {
            packingLabel.AppendLine($"{product.Name} ({product.ProductId})");
        }
        return packingLabel.ToString();
    }
    
    public string GetShippingLabel()
    {
        return $"{Customer.GetFullName()}\n{Customer.ShippingAddress}";
    }
}