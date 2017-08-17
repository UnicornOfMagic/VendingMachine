using System;
using System.Collections.Generic;

namespace VendingMachine
{

    public class VendingMachineBrain
    {
        Product cola = new Product(ProductType.Cola, 1.0, 10);
        Product chips = new Product(ProductType.Chips, 0.5, 10);
        Product candy = new Product(ProductType.Candy, 0.65, 10);
        InternalCoin quarter = new InternalCoin(0.955, 0.25, 10);
        InternalCoin nickel = new InternalCoin(0.835, 0.05, 10);
        InternalCoin dime = new InternalCoin(0.705, 0.1, 10);
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
                if (quarter.Stock == 0 || dime.Stock <= 2|| nickel.Stock <= 2)
                    return ("EXACT CHANGE ONLY");
                return ("INSERT COIN");
            }

        }

        public bool AcceptCoin(Coin coin)
        {
            if (coin.Width == quarter.Width)
            { // it's a quarter
                Balance += quarter.Value;
                return true;
            }
            else if (coin.Width == nickel.Width)
            { //it's a nickel
                Balance += nickel.Value;
                return true;
            }
            else if (coin.Width == dime.Width)
            { //it's a dime
                Balance += dime.Value;
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
                if (Balance >= quarter.Value)
                {
                    coin = new Coin(quarter.Width);
                    Balance -= quarter.Value;
                } else if (Balance >= dime.Value)
                {
                    coin = new Coin(dime.Width);
                    Balance -= dime.Value;
                } else
                {
                    coin = new Coin(nickel.Width);
                    Balance -= nickel.Value;
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
        internal InternalCoin Quarter { get => quarter; set => quarter = value; }
        internal InternalCoin Nickel { get => nickel; set => nickel = value; }
        internal InternalCoin Dime { get => dime; set => dime = value; }
        #endregion
    }
}
