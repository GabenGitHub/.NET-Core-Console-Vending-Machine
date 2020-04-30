namespace VendingMachine_CSharp
{
    public interface IProduct
    {
        string Name { get; }
        double Price { get; }
        int Amount { get; set; }
    }
}