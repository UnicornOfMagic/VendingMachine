using System;
using System.Collections.Generic;

namespace VendingMachine
{

    public class VendingMachineBrain
    {
        private double balance = 0;
        private List<Coin> coinReturn = new List<Coin>();
        private string message = "";

        public double Balance { get => balance; set => balance = value; }
        public List<Coin> CoinReturn { get => coinReturn; set => coinReturn = value; }
        public string Message { get => message; set => message = value; }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public string CheckDisplay()
        {
            if (!Message.Equals(""))
            {
                return (Message);
            }
            else if (Balance > 0)
            {
                return (Balance.ToString());
            } else
            {
                return ("INSERT COIN");
            }

        }

        public bool AcceptCoin(Coin coin)
        {
            if (coin.Width == .955)
            { // it's a quarter
                Balance += 0.25;
                return true;
            }
            else if (coin.Width == .835)
            { //it's a nickel
                Balance += 0.05;
                return true;
            }
            else if (coin.Width == .705)
            { //it's a dime
                Balance += 0.1;
                return true;
            }
            else
            { //don't recognize it. Toss it
                CoinReturn.Add(coin);
                return false;
            }
        }

        public void SelectProduct(Product product)
        {
            if (product == Product.Cola)
            {
                Message = "1.0";
            } else if (product == Product.Chips)
            {
                Message = "0.5";
            } else if (product == Product.Candy)
            {
                Message = "0.65";
            }
        }
    }
}
