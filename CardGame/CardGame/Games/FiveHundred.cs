using CardGame.Model;
using Model.CardGame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame.Games
{
    class FiveHundred
    {
        private Player _a;
        private Player _b;
        private List<Card> _aCards;
        private List<Card> _bCards;
        private CardDeck _LoadedCardDeck;
        private List<Card> _cardList;
        private List<Card> _cardListShuffled;

        public FiveHundred(Player A, Player B)
        {
            _LoadedCardDeck = new CardDeck();
            _cardList = _LoadedCardDeck.cardList;
            _cardListShuffled = _LoadedCardDeck.shuffledCardList;
            _a = A;
            _b = B;
        }

        private void GameLogic()
        {
            while(_aCards.Count > 0 || _bCards.Count > 0)
            {
                if (_aCards.IndexOf[0] > _bCards.IndexOf[0])
                {

                }
                {

                }
               
            }

        }

        public void play()
        {
            Setup();

        }

        private void Setup()
        {
            Console.WriteLine("loading card set...");
            Console.WriteLine(_LoadedCardDeck.cardListLength + " Loaded cards");
            Console.WriteLine("Shuffling cards...");
            _LoadedCardDeck.Shuffel(new Random(), _LoadedCardDeck.cardList);
            Console.WriteLine("Card deck have been shuffled");
            Console.WriteLine($"Gives cards to {_a.name} and {_b.name}");
            giveCards();
            Console.WriteLine($"A's amount of cards dealt: {_a.cardAmount} ");
            Console.WriteLine($"B's amount of cards dealt: {_b.cardAmount} ");
            Console.WriteLine("------------------Ready to Play------------------");
            Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Gaming is Started...");
        }
        /// <summary>
        /// Logic for dealing cards
        /// </summary>
        private void giveCards()
        {
            foreach (var card in _cardListShuffled)
            {
                if (_a.cardAmount == _b.cardAmount)
                {
                    _a.Add(card);
                }
                else
                {
                    _b.Add(card);
                }
            }
        }
    }
}
