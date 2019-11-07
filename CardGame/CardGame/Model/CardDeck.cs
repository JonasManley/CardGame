using CardGame.Model;
using Model.CardGame;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
    public class CardDeck : Shuffle
    {
        private FileReader _fileReader;
        private List<Card> _cardList;
        private Shuffle _Shuffle = new Shuffle();

        public CardDeck()
        {
            _fileReader = new FileReader("C:/Users/Jonas/Documents/GitHub/CardGame/Cards.txt");
            _cardList = new List<Card>();

            CreateDeck();
        }
        public List<Card> cardList
        {
            get { return _cardList; }
        }
        public List<Card> shuffledCardList
        {
            get { return _shuffledList; }
        }

        public int cardListLength
        {
            get { return _cardList.Count(); }
        }
        public int shuffledCardListLength
        {
            get { return _shuffledList.Count(); }     //_shuffledList if form the base class Shuffle, therefor its public 
        }

        private void CreateDeck()
        {
            if (_fileReader.getReadLines.Length == 0)
            {
                throw new ArgumentException("txt file not found or invalid, please check sourse and try agian...");
            }
            foreach (var itemLine in _fileReader.getReadLines)
            {
                string[] cardItems = itemLine.Split(' ');
                string cardColor = cardItems[0];
                string cardValue = cardItems[1];
                Card card = new Card(cardColor, cardValue);
                _cardList.Add(card);
            }
        }
        
        private void Shuffle()
        {
            _Shuffle.ShuffleCards(_cardList);
        }


    }
}
