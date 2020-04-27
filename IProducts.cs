namespace VendingMachine_CSharp
{
    public interface IProducts
    {
        string Name { get; }
        double Price { get; }
        int Amount { get; set; }
    }
}