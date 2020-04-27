namespace VendingMachine_CSharp
{
    public class CocaCola : IProducts
    {
        private double _price = 1.50;
        private int _amount = 5;

        public double Price { get => _price; }
        public int Amount { get => _amount; set => _amount = value; }
        public string Name { get => "Coca-Cola" ; }
    }
}