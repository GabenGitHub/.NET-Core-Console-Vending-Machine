using System.Net.Http.Headers;
using System;
using System.Collections.Generic;

namespace VendingMachine_CSharp
{
    public class VendingMachine
    {
        public double InsertedCoinsTotal { get; set; }
        public bool ProductValidation { get; set; }
        private IProducts fanta { get; }
        private IProducts cocaCola { get; }
        public IProducts SelectedProduct { get; private set; }

        public VendingMachine()
        {
            InsertedCoinsTotal = 0;
            cocaCola = new CocaCola();
            fanta = new Fanta();
        }

        public void SelectProduct(string product)
        {
            switch (product)
            {
                case ("a"):
                    if (cocaCola.Amount > 0)
                    {
                        SelectedProduct = cocaCola;
                        ProductValidation = true;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Product is out of stock");
                        Console.ResetColor();
                        ProductValidation = false;
                    }
                    break;
                case ("b"):
                    if (fanta.Amount > 0)
                    {
                        SelectedProduct = fanta;
                        ProductValidation = true;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Product is out of stock");
                        Console.ResetColor();
                        ProductValidation = false;
                    }
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid product selection!");
                    Console.ResetColor();
                    ProductValidation = false;
                    break;
            }
        }

        public void InsertCoin(string coin)
        {
            // The valid coins are: 0.05, 0.10, 0.25, 0.50
            switch (coin)
            {
                case ("a"):
                    InsertedCoinsTotal += 0.05;
                    break;
                case ("b"):
                    InsertedCoinsTotal += 0.10;
                    break;
                case ("c"):
                    InsertedCoinsTotal += 0.25;
                    break;
                case ("d"):
                    InsertedCoinsTotal += 0.50;
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid coin selection!");
                    Console.ResetColor();
                    break;
            }
        }

        public bool CheckInsertedCoins(IProducts product)
        {
            if (product.Price - InsertedCoinsTotal > 0)
                return true;
            else
            {
                product.Amount--;
                return false;
            }
        }

        public string CheckStock(IProducts product)
        {
            return product.Amount > 0 ? Convert.ToString(product.Amount) : "Out of stock";
        }

        public void DisplayProduct()
        {
            Console.WriteLine();
            Console.WriteLine("Please choose a product:");
            Console.WriteLine();
            Console.WriteLine($"Press 'a' to select Coca-Cola - Price: ${cocaCola.Price} - Stock: {CheckStock(cocaCola)}");
            Console.WriteLine($"Press 'b' to select Fanta - Price: ${fanta.Price} - Stock: {CheckStock(fanta)}");
            Console.WriteLine();
            Console.Write("Select: ");
        }

        public void DisplaySelectedProduct(IProducts product)
        {
            Console.WriteLine();
            Console.WriteLine("****************************************************************************");
            Console.WriteLine($"* Selected product: {product.Name} - Stock: {product.Amount} - Price: ${product.Price}");
            Console.WriteLine("****************************************************************************");
        }

        public void DisplayInsertCoin()
        {
            Console.WriteLine();
            Console.WriteLine("Please choose a coin to insert:");
            Console.WriteLine($"Press 'a' to insert $0.05");
            Console.WriteLine($"Press 'b' to insert $0.10");
            Console.WriteLine($"Press 'c' to insert $0.25");
            Console.WriteLine($"Press 'd' to insert $0.50");
            Console.WriteLine();
            Console.Write("Select: ");
        }

        public void DisplayCurrentAmount()
        {
            Console.WriteLine();
            Console.WriteLine("*****************************");
            Console.WriteLine($"Total inserted amount: ${Math.Round(InsertedCoinsTotal, 2)}");
            Console.WriteLine("*****************************");
        }

        public void DisplayRemaining(IProducts product)
        {
            if (product.Price - InsertedCoinsTotal > 0)
            {
                Console.WriteLine($"Remaining: ${Math.Round(product.Price - InsertedCoinsTotal, 2)}");
            }
            else
            {
                Console.WriteLine($"Change: ${Math.Round(InsertedCoinsTotal - product.Price, 2)}");
            }
        }

        public void DisplayEndOfPurchasing()
        {
            Console.WriteLine();
            Console.WriteLine($"Enjoy your {SelectedProduct.Name}!");
            Console.WriteLine();
        }
    }
}