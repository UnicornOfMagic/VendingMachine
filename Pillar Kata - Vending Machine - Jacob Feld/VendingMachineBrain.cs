using System;

namespace VendingMachine
{

    public class VendingMachineBrain
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public string CheckDisplay()
        {
            return ("INSERT COIN");
        }

        public bool AcceptCoin(Coin coin)
        {
            if (coin.Width == .955) // it's a quarter
                return true;
            else if (coin.Width == .835) //it's a nickel
                return true;
            else if (coin.Width == .705) //it's a dime
                return true;
            else
                return false; //don't recognize it. Toss it.
        }
    }
}
