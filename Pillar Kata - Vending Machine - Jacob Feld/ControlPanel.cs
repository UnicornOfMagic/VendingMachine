using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachine
{
    class ControlPanel
    {
        static void Main(string[] args)
        {
            VendingMachineBrain brain = new VendingMachineBrain();
            Coin quarter = new Coin(0.955);
            Coin dime = new Coin(0.705);
            Coin nickel = new Coin(0.835);
            Coin penny = new Coin(0.750);
            bool exit = false;

            while (!exit)
            {
                MainMenu();
                string input = GetUserInput();
                switch (input)
                {
                    case "D1":
                    case "Numpad1":
                        Console.WriteLine("***\nDisplay: [ " + string.Format("{0:C2}", brain.CheckDisplay()) + " ]\n***");
                        break;
                    case "D2":
                    case "Numpad2":
                        InsertCoins(brain, quarter, dime, nickel, penny, input);
                        break;
                    case "D3":
                    case "Numpad3":
                        brain.ReturnCoins();
                        Console.WriteLine();
                        break;
                    case "D4":
                    case "Numpad4":
                        ProductMenu();
                        input = GetUserInput();
                        switch (input)
                        {
                            case "D1":
                            case "Numpad1":
                                brain.SelectProduct(ProductType.Cola);
                                break;
                            case "D2":
                            case "Numpad2":
                                brain.SelectProduct(ProductType.Chips);
                                break;
                            case "D3":
                            case "Numpad3":
                                brain.SelectProduct(ProductType.Candy);
                                break;
                            default:
                                Console.WriteLine("Invalid Entry");
                                break;
                        }
                        break;
                    case "D5":
                    case "Numpad5":
                        Console.WriteLine("The coin return contained: ");
                        PrintContents(brain.CoinReturn);
                        break;
                    case "D6":
                    case "Numpad6":
                        Console.WriteLine("The item dispenser contained: ");
                        PrintContents(brain.Dispenser);
                        break;
                    case "D7":
                    case "Numpad7":
                        StockReadout(brain);
                        break;
                    case "D8":
                    case "Numpad8":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid Choice ( " + input + " )");
                        break;
                }
            }
            Console.WriteLine("\nGoodbye");
        }

        private static void PrintContents<T>(List<T> list)
        {
            Console.Write("[");
            foreach (object x in list) {
                Console.Write(x.ToString() + " ");
            }
            Console.WriteLine("]");
            list.Clear();
        }

        private static void InsertCoins(VendingMachineBrain brain, Coin quarter, Coin dime, Coin nickel, Coin penny, string input)
        {
            bool coinExit = false;
            do
            {
                CoinMenu();
                input = GetUserInput();
                switch (input)
                {
                    case "D1":
                    case "Numpad1":
                        Console.WriteLine("Inserting a Quarter");
                        brain.AcceptCoin(quarter);
                        break;
                    case "D2":
                    case "Numpad2":
                        Console.WriteLine("Inserting a Nickel");
                        brain.AcceptCoin(nickel);
                        break;
                    case "D3":
                    case "Numpad3":
                        Console.WriteLine("Inserting a Dime");
                        brain.AcceptCoin(dime);
                        break;
                    case "D4":
                    case "Numpad4":
                        Console.WriteLine("Inserting a Penny");
                        brain.AcceptCoin(penny);
                        break;
                    case "D5":
                    case "Numpad5":
                        coinExit = true;
                        Console.WriteLine("Stopping...");
                        Console.WriteLine("\n");
                        break;
                    default:
                        Console.WriteLine("Invalid Entry");
                        break;
                }
            } while (!coinExit);
        }

        private static void StockReadout(VendingMachineBrain brain)
        {
            Console.WriteLine("\n**Current Stocks**");
            Console.WriteLine("Cola     - " + brain.Cola.Stock);
            Console.WriteLine("Chips    - " + brain.Chips.Stock);
            Console.WriteLine("Candy    - " + brain.Candy.Stock);
            Console.WriteLine("\n**Coin Reserves**");
            Console.WriteLine("Quarters - " + brain.Quarter.Stock);
            Console.WriteLine("Nickels  - " + brain.Nickel.Stock);
            Console.WriteLine("Dimes    - " + brain.Dime.Stock);
            Console.WriteLine();
        }

        private static void ProductMenu()
        {
            Console.WriteLine("Choose a Product:");
            Console.WriteLine("1) Cola  - $1.00");
            Console.WriteLine("2) Chips - $0.50");
            Console.WriteLine("3) Candy - $0.65");
        }

        private static void CoinMenu()
        {
            Console.WriteLine("Choose a Coin:");
            Console.WriteLine("1) Quarter");
            Console.WriteLine("2) Nickel");
            Console.WriteLine("3) Dime");
            Console.WriteLine("4) Penny");
            Console.WriteLine("5) Stop");
        }

        private static string GetUserInput()
        {
            Console.Write("\nChoice: ");
            string input = Console.ReadKey().Key.ToString();
            Console.WriteLine("\n\n");
            return input;
        }

        private static void MainMenu()
        {
            Console.WriteLine("**Main Menu**");
            Console.WriteLine("Please choose an option:");
            Console.WriteLine("1) Check Display");
            Console.WriteLine("2) Insert Coins");
            Console.WriteLine("3) Coin Return");
            Console.WriteLine("4) Select a Product");
            Console.WriteLine("5) Take Coins");
            Console.WriteLine("6) Take Product");
            Console.WriteLine("7) Check Stock");
            Console.WriteLine("8) Exit");
        }
    }
}
