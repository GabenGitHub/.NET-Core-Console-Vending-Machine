namespace VendingMachine_CSharp
{
    public class Fanta : IProducts
    {
            private double _price = 1.70;
            private int _amount = 1;

            public double Price { get => _price; }
            public int Amount { get => _amount; set => _amount = value; }
            public string Name { get => "Fanta" ; }
    }
}