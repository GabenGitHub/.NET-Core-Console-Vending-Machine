using System;

namespace VendingMachine_CSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            var vendingMachine = new VendingMachine();

            while (true)
            {
                Console.WriteLine("Welcome!");
                while (!vendingMachine.ProductValidation) {
                    vendingMachine.DisplayProducts();

                    vendingMachine.SelectProduct(Console.ReadLine());
                    Console.Clear();
                }

                while (vendingMachine.CheckInsertedCoins(vendingMachine.SelectedProduct))
                {
                    vendingMachine.DisplaySelectedProduct(vendingMachine.SelectedProduct);
                    vendingMachine.DisplayCurrentAmount();
                    vendingMachine.DisplayRemaining(vendingMachine.SelectedProduct);
                    vendingMachine.DisplayInsertCoin();

                    vendingMachine.InsertCoin(Console.ReadLine());
                    Console.Clear();
                }
                vendingMachine.DisplayRemaining(vendingMachine.SelectedProduct);
                vendingMachine.DecreaseProductAmount(vendingMachine.SelectedProduct);
                vendingMachine.DisplayEndOfPurchasing();
                
                vendingMachine.ResetMachine();
            }
        }
    }
}
