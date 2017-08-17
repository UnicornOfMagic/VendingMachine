using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachine
{
    class InternalCoin : Coin
    {
        private double value;
        private int stock;

        public InternalCoin(double width, double value, int stock) : base(width)
        {
            this.Width = width;
            this.Value = value;
            this.Stock = stock;
        }

        public double Value { get => value; set => this.value = value; }
        public int Stock { get => stock; set => stock = value; }
    }
}
