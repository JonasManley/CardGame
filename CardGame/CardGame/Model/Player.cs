using Model.CardGame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame.Model
{
    public class Player
    {
        private string _name;
        private List<Card> _assignedCards = new List<Card>();

        public Player(string name)
        {
            _name = name;
        }

        /// <summary>
        /// Propperties
        /// </summary>
        public string name
        {
            get { return _name; }
            set { _name = value; }
        }
        public List<Card> assignedCards
        {
            get { return _assignedCards; }
        }
        public int cardAmount
        {
            get { return _assignedCards.Count; }
        }

        /// <summary>
        /// Methods 
        /// </summary>
        public void RemoveCard(Card card)
        {
            _assignedCards.Remove(card);
        }

        public void Add(Card card)
        {
            _assignedCards.Add(card);
        }

        public Card NextCard(int i)
        {
            return _assignedCards[i];
        }
    }
}
