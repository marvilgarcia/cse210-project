class Order
{
    private Customer _customer;
    private List<Product> _products;
    private double _shippingCost;

    public Order(Customer customer)
    {
        _customer = customer;
        _products = new List<Product>();
        _shippingCost = _customer.IsInUSA() ? 5.00 : 35.00;
    }

    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    public double GetTotalPrice()
    {
        double totalPrice = 0;
        foreach (Product product in _products)
        {
            totalPrice += product.GetTotalCost();
        }
        return totalPrice + _shippingCost;
    }

    public string GetPackingLabel()
    {
        string label = "Packing Label:\n";
        foreach (Product product in _products)
        {
            label += $"Name: {product.GetName()}, ID: {product.GetProductId()}, Quantity: {product._quantity}, Price: {product._price}\n";
        }
        return label;
    }

    public string GetShippingLabel()
    {
        return $"Shipping Label:\nName: {_customer.GetName()}\nAddress: {_customer.GetAddress().GetFullAddress()}";
    }
}