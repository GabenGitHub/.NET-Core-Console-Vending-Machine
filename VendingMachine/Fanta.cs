namespace VendingMachine_CSharp
{
    public class Fanta : IProduct
    {
            public string Name { get; } = "Fanta";
            public double Price { get; } = 1.70;
            public int Amount { get; set; } = 1;
    }
}