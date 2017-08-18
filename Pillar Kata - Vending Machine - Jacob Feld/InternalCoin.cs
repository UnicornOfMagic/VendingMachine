using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachine
{
    public class InternalCoin : Coin
    {
        private decimal value;
        private int stock;

        public InternalCoin(double width, decimal value, int stock) : base(width)
        {
            this.Width = width;
            this.Value = value;
            this.Stock = stock;
        }

        public decimal Value { get => value; set => this.value = value; }
        public int Stock { get => stock; set => stock = value; }
    }
}
