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

        public bool AcceptCoin(Coin quarter)
        {
            if (quarter.Width == .955)
                return true;
            else
                return false;
        }
    }
}
