namespace VendingMachine_CSharp
{
    public class CocaCola : IProduct
    {
        public string Name { get; } = "Coca-Cola";
        public double Price { get; } = 1.50;
        public int Amount { get; set; } = 5;
    }
}