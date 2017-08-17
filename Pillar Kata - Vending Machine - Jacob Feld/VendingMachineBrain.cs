using System;

namespace VendingMachine
{

    public class VendingMachineBrain
    {
        private double balance = 0;

        public double Balance { get => balance; set => balance = value; }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public string CheckDisplay()
        {
            if (Balance > 0)
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
            {
                return false; //don't recognize it. Toss it.
            }
        }
    }
}
