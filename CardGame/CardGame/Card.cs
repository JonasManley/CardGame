using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
    public class Card
    {
        private string _cardValue;
        private string _cardColor;

        public Card(string cardvalue, string color)
        {
            _cardValue = cardvalue;
            _cardColor = color;
        }

        public string cardValue
        {
            get { return _cardValue; }
            set { _cardValue = value; }
        }

        public string cardColor
        {
            get { return _cardColor; }
            set { _cardColor = value; }
        }
    }
}
