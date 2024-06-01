public class Product
{
    public string Name { get; set; }
    public string ProductId { get; set; }
    public float PricePerUnit { get; set; }
    public int Quantity { get; set; }
    
    public Product(string name, string productId, float pricePerUnit)
    {
        Name = name;
        ProductId = productId;
        PricePerUnit = pricePerUnit;
        Quantity = 1;
    }
    
    public Product(string name, string productId, float pricePerUnit, int quantity)
    {
        Name = name;
        ProductId = productId;
        PricePerUnit = pricePerUnit;
        Quantity = quantity;
    }

    public float CalculateTotalCost()
    {
        return Quantity * PricePerUnit;
    }
    
    public override string ToString()
    {
        return $"{Name} ({ProductId}) - ${PricePerUnit} x {Quantity}";
    }
}