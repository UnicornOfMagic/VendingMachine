﻿using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachine
{
    public class Coin
    {
        private double width = 0;

        public Coin(double width)
        {
            this.Width = width;
        }

        public double Width { get => width; set => width = value; }
        
        /*0.750 in. 19.05 mm -- Penny	
        0.835 in. 21.21 mm -- Nickel
        0.705 in. 17.91 mm -- Dime
        0.955 in. 24.26 mm -- Quarter
        */
    }
}
