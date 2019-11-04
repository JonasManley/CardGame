using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
    public class CardDeck
    {
        private FileReader _fileReader;
        private List<Card> _cardList;

        public CardDeck()
        {
            _fileReader = new FileReader("C:/Users/Jonas/source/repos/CardGame/Cards.txt");
            _cardList = new List<Card>();
            CreateDeck();
        }
        public List<Card> CardList
        {
            get { return _cardList; }
        }

        public int cardListLength
        {
            get { return _cardList.Count(); }
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


        //Fisher–Yates shuffle algorithm - https://en.wikipedia.org/wiki/Fisher%E2%80%93Yates_shuffle#The_.22inside-out.22_algorithm 
        public List<Card> Shuffel(Random randomgenerator, List<Card> source)
        {
            List<Card> shuffledList = new List<Card>();
            foreach (var item in source)
            {
                var i = randomgenerator.Next(shuffledList.Count + 1);
                if (i == shuffledList.Count)
                {
                    shuffledList.Add(item);
                }
                else
                {
                    var temp = shuffledList[i];
                    shuffledList[i] = item;
                    shuffledList.Add(temp);
                }
            }
            return shuffledList;
        }
    }
}
