using System;
using System.Collections.Generic;

namespace VendingMachine
{

    public class VendingMachineBrain
    {
        private Product cola = new Product(ProductType.Cola, 1.0, 10);
        private Product chips = new Product(ProductType.Chips, 0.5, 10);
        private Product candy = new Product(ProductType.Candy, 0.65, 10);
        private InternalCoin quarter = new InternalCoin(0.955, 0.25, 10);
        private InternalCoin nickel = new InternalCoin(0.835, 0.05, 10);
        private InternalCoin dime = new InternalCoin(0.705, 0.1, 10);
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
                if (Quarter.Stock == 0 || Dime.Stock <= 2|| Nickel.Stock <= 2)
                    return ("EXACT CHANGE ONLY");
                return ("INSERT COIN");
            }

        }

        public bool AcceptCoin(Coin coin)
        {
            if (coin.Width == Quarter.Width)
            { // it's a quarter
                Balance += Quarter.Value;
                Quarter.Stock++;
                return true;
            }
            else if (coin.Width == Nickel.Width)
            { //it's a nickel
                Balance += Nickel.Value;
                Nickel.Stock++;
                return true;
            }
            else if (coin.Width == Dime.Width)
            { //it's a dime
                Balance += Dime.Value;
                Dime.Stock++;
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
                if (Balance >= Quarter.Value && Quarter.Stock > 0)
                {
                    coin = new Coin(Quarter.Width);
                    Balance -= Quarter.Value;
                    Quarter.Stock--;
                } else if (Balance >= Dime.Value && Dime.Stock > 0)
                {
                    coin = new Coin(Dime.Width);
                    Balance -= Dime.Value;
                    Dime.Stock--;
                } else if (Nickel.Stock > 0)
                {
                    coin = new Coin(Nickel.Width);
                    Balance -= Nickel.Value;
                    Nickel.Stock--;
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
        public InternalCoin Quarter { get => quarter; set => quarter = value; }
        public InternalCoin Nickel { get => nickel; set => nickel = value; }
        public InternalCoin Dime { get => dime; set => dime = value; }
        #endregion
    }
}
