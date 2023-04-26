using System;
using System.Collections.Generic;
using System.Text;

namespace monopoly
{
    public class board
    {
        public string name { get; }
        public string sqType { get; set; }
        public int price { get; set; }
        public bool owned { get; set; }
        public string owner { get; set; }

        public board(string nameIn, string typeIn, int priceIn)
        {
            name = nameIn;
            sqType = typeIn;
            price = priceIn;
            owned = false;
            owner = null;
        }

        public override string ToString()
        {
            return name + ". Type:" + sqType + ". Cost:" + price;
        }
    }
}
