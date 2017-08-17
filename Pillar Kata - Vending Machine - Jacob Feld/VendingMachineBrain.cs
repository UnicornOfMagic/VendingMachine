using System;
using System.Collections.Generic;

namespace VendingMachine
{

    public class VendingMachineBrain
    {
        Product cola = new Product(ProductType.Cola, 1.0, 10);
        Product chips = new Product(ProductType.Chips, 0.5, 10);
        Product candy = new Product(ProductType.Candy, 0.65, 10);
        const double QUARTERWIDTH = 0.955;
        const double QUARTERVALUE = 0.25;
        const double NICKELWIDTH = 0.835;
        const double NICKELVALUE = 0.05;
        const double DIMEWIDTH = 0.705;
        const double DIMEVALUE = 0.1;
        private int quarterCount = 10;
        private int dimeCount = 10;
        private int nickelCount = 10;
        private double balance = 0;
        private List<Coin> coinReturn = new List<Coin>();
        private string message = "";
        private List<Product> dispenser = new List<Product>();

        public string CheckDisplay()
        {
            if (!Message.Equals(""))
            {
                string messageIntake = Message;
                Message = "";
                return (messageIntake);
            }
            else if (Balance > 0)
            {
                return (Balance.ToString());
            } else
            {
                if (quarterCount == 0 || dimeCount <= 2|| nickelCount <= 2)
                    return ("EXACT CHANGE ONLY");
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
            { //don't recognize it. Return it
                ReturnCoin(coin);
                return false;
            }
        }

        public void SelectProduct(ProductType type)
        {
            Product product = ConvertProductTypeIntoProduct(type);
            

            if (product.Stock == 0)
            {
                Message = "SOLD OUT";
            }else if (Balance < product.Price)
                Message = product.Price.ToString();
            else
            {
                Balance -= product.Price;
                product.Stock--;
                Dispense(product);
            }

            MakeChange();
        }

        private Product ConvertProductTypeIntoProduct(ProductType type)
        {
            switch (type)
            {
                case ProductType.Cola:
                    return Cola;
                case ProductType.Chips:
                    return Chips;
                case ProductType.Candy:
                    return Candy;
                default:
                    return null; //Should never happen...
            }
        }

        public void ReturnCoins()
        {
            MakeChange();
        }

        private void MakeChange()
        {
            while (Balance > 0)
            {
                Coin coin = null;
                if (Balance >= 0.25)
                {
                    coin = new Coin(QUARTERWIDTH);
                    Balance -= QUARTERVALUE;
                } else if (Balance >= 0.1)
                {
                    coin = new Coin(DIMEWIDTH);
                    Balance -= DIMEVALUE;
                } else
                {
                    coin = new Coin(NICKELWIDTH);
                    Balance -= NICKELVALUE;
                }
                Balance = Math.Round(Balance, 2);
                ReturnCoin(coin);
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

        #region getters&setters
        public double Balance { get => balance; set => balance = value; }
        public List<Coin> CoinReturn { get => coinReturn; set => coinReturn = value; }
        public string Message { get => message; set => message = value; }
        public List<Product> Dispenser { get => dispenser; set => dispenser = value; }
        public Product Cola { get => cola; set => cola = value; }
        public Product Chips { get => chips; set => chips = value; }
        public Product Candy { get => candy; set => candy = value; }
        public int QuarterCount { get => quarterCount; set => quarterCount = value; }
        public int DimeCount { get => dimeCount; set => dimeCount = value; }
        public int NickelCount { get => nickelCount; set => nickelCount = value; }
        #endregion
    }
}
