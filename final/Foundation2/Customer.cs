public class Customer
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public Address ShippingAddress { get; set; }
    
    public Customer(string firstName, string lastName, Address shippingAddress)
    {
        FirstName = firstName;
        LastName = lastName;
        ShippingAddress = shippingAddress;
    }

    public bool IsResidentUsa()
    {
        return ShippingAddress.IsUsa();
    }

    public string GetFullName()
    {
        return $"{FirstName} {LastName}";
    }
}