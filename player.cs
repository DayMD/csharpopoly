using System;
using System.Collections.Generic;
using System.Text;

namespace monopoly
{
    class player
    {
        public string name { get; set; }
        public int money { get; set; }
        public string[] properties { get; set; }
        public bool isJail { get; set; }
        public bool hasFreeCard { get; set; }
        public int numOfHouses { get; set; }
        public int numOfHotels { get; set; }
        public int boardSize { get; set; }
        public int position { get; set; }

        public bool inPrison { get; set; }

        /// <summary>
        /// Class instantiation of player, if cash is 0 will default to 1500, other player variables assumed to be zero/blank by default.
        /// </summary>
        /// <param name="nameIn">Player name</param>
        /// <param name="moneyIn">Starting cash, leave at 0 for default 1500</param>
        public player(string nameIn, int moneyIn)
        {
            name = nameIn;
            money = moneyIn;
            if (money <= 0)
            {
                money = 1500;
            }
            isJail = false;
        }

        public override string ToString()
        {
            //return base.ToString();
            StringBuilder sb = new StringBuilder(name);
            sb.Append(" " + money + " " + position);
            return sb.ToString();
        }
    }
}
