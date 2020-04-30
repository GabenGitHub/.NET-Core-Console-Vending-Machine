using System;
using VendingMachine_CSharp.Products;

namespace VendingMachine_CSharp
{
    public class VendingMachine
    {
        private IProduct _fanta;
        private IProduct _cocaCola;
        public IProduct SelectedProduct { get; private set; }
        public float InsertedCoinsTotal { get; private set; }
        public bool ProductValidation { get; private set; }

        public VendingMachine()
        {
            InsertedCoinsTotal = 0;
            _cocaCola = new CocaCola();
            _fanta = new Fanta();
        }

        public void SelectProduct(string product)
        {
            var outOfStock = "Product is out of stock";
            switch (product)
            {
                case ("a"):
                    if (_cocaCola.Amount > 0)
                    {
                        SelectedProduct = _cocaCola;
                        ProductValidation = true;
                    }
                    else
                    {
                        DisplayErrorMessage(outOfStock);
                        ProductValidation = false;
                    }
                    break;
                case ("b"):
                    if (_fanta.Amount > 0)
                    {
                        SelectedProduct = _fanta;
                        ProductValidation = true;
                    }
                    else
                    {
                        DisplayErrorMessage(outOfStock);
                        ProductValidation = false;
                    }
                    break;
                default:
                    DisplayErrorMessage("Invalid product selection!");
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
                    InsertedCoinsTotal += 0.05f;
                    break;
                case ("b"):
                    InsertedCoinsTotal += 0.10f;
                    break;
                case ("c"):
                    InsertedCoinsTotal += 0.25f;
                    break;
                case ("d"):
                    InsertedCoinsTotal += 0.50f;
                    break;
                default:
                    DisplayErrorMessage("Invalid coin selection!");
                    break;
            }
        }

        public bool CheckInsertedCoins(IProduct product)
        {
            if (product.Price - InsertedCoinsTotal > 0)
                return true;
            else
                return false;
        }

        public void DecreaseProductAmount(IProduct product)
        {
            product.Amount--;
        }

        public void ResetMachine()
        {
            ProductValidation = false;
            InsertedCoinsTotal = 0;
            Console.Clear();
        }

        public string CheckStock(IProduct product)
        {
            return product.Amount > 0 ? Convert.ToString(product.Amount) : "Out of stock";
        }

        public void DisplayMainMenu()
        {
            DisplayProducts();

            SelectProduct(Console.ReadLine());
            Console.Clear();
        }

        public void DisplayProductMenu()
        {
            DisplaySelectedProduct(SelectedProduct);
            DisplayCurrentAmount();
            DisplayRemainingOrChange(SelectedProduct);
            DisplayInsertCoin();

            InsertCoin(Console.ReadLine());
            Console.Clear();
        }

        public void DisplayProducts()
        {
            Console.WriteLine();
            Console.WriteLine("Please choose a product:");
            Console.WriteLine();
            Console.WriteLine($"Press 'a' to select Coca-Cola - Price: ${(_cocaCola.Price).ToString("F")} - Stock: {CheckStock(_cocaCola)}");
            Console.WriteLine($"Press 'b' to select Fanta - Price: ${(_fanta.Price).ToString("F")} - Stock: {CheckStock(_fanta)}");
            Console.WriteLine();
            Console.Write("Select: ");
        }

        public void DisplaySelectedProduct(IProduct product)
        {
            var text = $"Selected product: {product.Name} - Stock: {product.Amount} - Price: ${(product.Price).ToString("F")}";

            Console.WriteLine();
            StarWrapper(text);
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
            var text = $"Total inserted amount: ${(InsertedCoinsTotal).ToString("F")}";

            Console.WriteLine();
            StarWrapper(text);
        }

        public string StarDrawer(string text)
        {
            var stars = "";

            for (int i = 0; i < text.Length; i++)
            {
                stars += "*";
            }

            return stars;
        }

        public void StarWrapper(string text)
        {
            Console.WriteLine(StarDrawer(text));
            Console.WriteLine(text);
            Console.WriteLine(StarDrawer(text));
        }

        public void DisplayRemainingOrChange(IProduct product)
        {
            var remaining = $"Remaining: ${(product.Price - InsertedCoinsTotal).ToString("F")}";
            var change = $"Change: ${(InsertedCoinsTotal - product.Price).ToString("F")}";

            if (product.Price - InsertedCoinsTotal > 0)
                StarWrapper(remaining);
            else
                StarWrapper(change);
        }

        public void DisplayErrorMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
        }

        public void DisplayEndOfPurchasing()
        {
            var text = $"Enjoy your {SelectedProduct.Name}!";
            Console.WriteLine();
            StarWrapper(text);
            Console.WriteLine();
            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
        }
    }
}