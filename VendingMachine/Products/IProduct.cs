namespace VendingMachine_CSharp.Products
{
    public interface IProduct
    {
        string Name { get; }
        double Price { get; }
        int Amount { get; set; }
    }
}