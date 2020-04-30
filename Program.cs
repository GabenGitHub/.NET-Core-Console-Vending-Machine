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
                    vendingMachine.DisplayMainMenu();
                }

                while (vendingMachine.CheckInsertedCoins(vendingMachine.SelectedProduct))
                {
                    vendingMachine.DisplayProductMenu();
                }
                vendingMachine.DisplayRemainingOrChange(vendingMachine.SelectedProduct);
                vendingMachine.DecreaseProductAmount(vendingMachine.SelectedProduct);
                vendingMachine.DisplayEndOfPurchasing();
                
                vendingMachine.ResetMachine();
            }
        }
    }
}
