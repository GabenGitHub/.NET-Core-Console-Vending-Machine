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
                    vendingMachine.DisplayProduct();

                    vendingMachine.SelectProduct(Console.ReadLine());
                }

                while (vendingMachine.CheckInsertedCoins(vendingMachine.SelectedProduct))
                {
                    vendingMachine.DisplaySelectedProduct(vendingMachine.SelectedProduct);
                    vendingMachine.DisplayRemaining(vendingMachine.SelectedProduct);
                    vendingMachine.DisplayInsertCoin();

                    vendingMachine.InsertCoin(Console.ReadLine());

                    vendingMachine.DisplayCurrentAmount();
                }
                vendingMachine.DisplayRemaining(vendingMachine.SelectedProduct);
                vendingMachine.DisplayEndOfPurchasing();
                
                vendingMachine.ProductValidation = false;
                vendingMachine.InsertedCoinsTotal = 0;
            }
        }
    }
}
