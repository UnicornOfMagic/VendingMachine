using System;
using System.Collections.Generic;

namespace VendingMachine
{

    public class VendingMachineBrain
    {
        const double COLAPRICE = 1.0;
        const double CHIPSPRICE = 0.5;
        const double CANDYPRICE = 0.65;
        const double QUARTERWIDTH = 0.955;
        const double NICKELWIDTH = 0.835;
        const double DIMEWIDTH = 0.705;
        const double QUARTERVALUE = 0.25;
        const double NICKELVALUE = 0.05;
        const double DIMEVALUE = 0.1;
        private double balance = 0;
        private List<Coin> coinReturn = new List<Coin>();
        private string message = "";
        private List<Product> dispenser = new List<Product>();

        public double Balance { get => balance; set => balance = value; }
        public List<Coin> CoinReturn { get => coinReturn; set => coinReturn = value; }
        public string Message { get => message; set => message = value; }
        public List<Product> Dispenser { get => dispenser; set => dispenser = value; }

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
            if (coin.Width == QUARTERWIDTH)
            { // it's a quarter
                Balance += QUARTERVALUE;
                return true;
            }
            else if (coin.Width == NICKELWIDTH)
            { //it's a nickel
                Balance += NICKELVALUE;
                return true;
            }
            else if (coin.Width == DIMEWIDTH)
            { //it's a dime
                Balance += DIMEVALUE;
                return true;
            }
            else
            { //don't recognize it. Toss it
                ReturnCoin(coin);
                return false;
            }
        }

        public void SelectProduct(Product product)
        {
            if (product == Product.Cola)
            {
                if (Balance < COLAPRICE)
                    Message = COLAPRICE.ToString();
                else
                {
                    Balance -= COLAPRICE;
                    Dispense(product);
                }
            } else if (product == Product.Chips)
            {
                if (Balance < CHIPSPRICE)
                    Message = CHIPSPRICE.ToString();
                else
                {
                    Balance -= CHIPSPRICE;
                    Dispense(product);
                }
            } else if (product == Product.Candy)
            {
                if (Balance < CANDYPRICE)
                    Message = CANDYPRICE.ToString();
                else
                {
                    Balance -= CANDYPRICE;
                    Dispense(product);
                }
            }
        }

        private void ReturnCoin(Coin coin)
        {
            CoinReturn.Add(coin);
        }

        private void Dispense(Product product)
        {
            Dispenser.Add(product);
        }
    }
}
