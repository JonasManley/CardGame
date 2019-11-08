using CardGame.Model;
using CardGame.Text;
using Model.CardGame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CardGame.Games
{
    class WarGame
    {
        private Player _a;
        private Player _b;
        private string winner = "";

        private CardDeck _LoadedCardDeck;
        private Shuffle _shuffle = new Shuffle();
        private Stats _stats = new Stats();

        private List<Card> _cardList;
        private List<Card> _cardListShuffled;

        private List<Card> _aCards;
        private List<Card> _bCards;
        private List<Card> _warPot = new List<Card>();
        private List<Card> _pot = new List<Card>();
        private List<Card> _nextCardPotA = new List<Card>();
        private List<Card> _nextCardPotB = new List<Card>();
        private TextPresent TextPresent = new TextPresent();
       

        public WarGame(Player A, Player B)
        {
            _LoadedCardDeck = new CardDeck();
            _cardList = _LoadedCardDeck.cardList;
            _cardListShuffled = _LoadedCardDeck.shuffledCardList;
            _a = A;
            _b = B;
            _aCards = _a.assignedCards;
            _bCards = _b.assignedCards;
        }

        public void play()
        {
            TextPresent.WelcomeText();
            Setup();
            GameLogic();
        }


        private void GameLogic()
        {
            while (_aCards.Count > 1 && _bCards.Count > 1 && warPossible == true)
            {
                //if(_stats.battlesDone == 26)
                //{
                //    Fix infinite scenario
                //}
                if (_aCards[0].cardValue != "J" && _aCards[0].cardValue != "D" && _aCards[0].cardValue != "K" && _aCards[0].cardValue != "A" &&
                      _bCards[0].cardValue != "J" && _bCards[0].cardValue != "D" && _bCards[0].cardValue != "K" && _bCards[0].cardValue != "A")
                {
                    HandlingNormalCard();
                }
                else
                {
                    HandlingFaceCards();
                }
            }
            if(_aCards.Count < 1)
            {
                Console.WriteLine("----------------------------------------------------");
                TextPresent.CardStatusBWin(Convert.ToInt32(_aCards.Count), Convert.ToInt32(_bCards.Count));
                Console.WriteLine("A have no more cards left. B");
                winner = "B";
                TextPresent.WinnerText(winner);
                GameIsFinished();
            }
            else
            {
                Console.WriteLine("----------------------------------------------------");
                TextPresent.CardStatusBWin(Convert.ToInt32(_aCards.Count), Convert.ToInt32(_bCards.Count));
                Console.WriteLine("B have no more cards left.");
                winner = "A";
                TextPresent.WinnerText(winner);
                GameIsFinished();
            }
            
        }


        private void GameIsFinished()
        {
            Console.WriteLine("Game is fisished, pres enter to see stats or X to quit ");
            var input = Console.ReadKey();
            Console.Clear();

            switch (input.Key) 
            {
                case ConsoleKey.Enter:
                    Console.WriteLine("---------------------------------------------------------------------");
                    Console.WriteLine($"Total Games Done:" + _stats.battlesDone);
                    Console.WriteLine($"wars done:" + _stats.warDones);
                    Console.WriteLine($"Games Won by Player A:" + _stats.PlayerARoundsWon);
                    Console.WriteLine($"Games Won by Player B:" + _stats.PlayerBRoundsWon);
                    Console.WriteLine($"Percentage For occurrence of wars:" + _stats.percentageForWar());
                    Console.WriteLine("---------------------------------------------------------------------");

                    Console.WriteLine("Want to Play agian? press P or X for exit");
                    var inputPlayagian = Console.ReadKey();
                    switch (inputPlayagian.Key)
                    {
                        case ConsoleKey.Enter:
                            Console.Clear();
                            ClearPreviousGame();
                            play();
                            break;
                        case ConsoleKey.X:
                            Console.Clear();
                            TextPresent.EndText();
                            break;
                    }
                    break;
                case ConsoleKey.X:
                    Console.Clear();
                    TextPresent.EndText();
                    break;
            }
        }

        private void ClearPreviousGame()
        { 
             winner = "";
            _LoadedCardDeck.cardList.Clear();
            _stats = new Stats();
            _cardList.Clear();
            _cardListShuffled.Clear();
            _aCards.Clear();
            _bCards.Clear();
            _warPot.Clear();
            _pot.Clear();
        }


        private void HandlingNormalCard()
        {

            if (Convert.ToInt32(_aCards[0].cardValue) > Convert.ToInt32(_bCards[0].cardValue))
            {
                if (_warPot.Count != 0)
                {
                    Console.WriteLine("A wins the war!");
                    foreach (var card in _warPot)
                    {
                        _aCards.Add(card);
                    }
                    _warPot.Clear();
                }
                Console.WriteLine($"A has: {_aCards[0].cardValue} and B: {_bCards[0].cardValue}");
                Console.WriteLine("A wins");
                _stats.PlayerARoundsWon += 1;
                _stats.battlesDone += 1;

                HandlingPot(_pot, _aCards, _bCards);
            }
            else if (Convert.ToInt32(_aCards[0].cardValue) < Convert.ToInt32(_bCards[0].cardValue))
            {
                if (_warPot.Count != 0)
                {
                    Console.WriteLine("B wins the war!");
                    foreach (var card in _warPot)
                    {
                        _bCards.Add(card);
                    }
                    _warPot.Clear();
                }
                Console.WriteLine($"A has: {_aCards[0].cardValue} and B: {_bCards[0].cardValue}");
                Console.WriteLine("B wins");
                _stats.PlayerBRoundsWon += 1;
                _stats.battlesDone += 1;

                HandlingPot(_pot, _bCards, _aCards);
            }
            else if (Convert.ToInt32(_aCards[0].cardValue) == Convert.ToInt32(_bCards[0].cardValue))
            {
                TextPresent.warStarted(_aCards[0].cardValue, _bCards[0].cardValue);
                TextPresent.CardStatusBWin(Convert.ToInt32(_aCards.Count), Convert.ToInt32(_bCards.Count));

                _stats.warDones += 1;
                WAR();
            }
        }
    

        private void HandlingFaceCards()
        {

            Dictionary<string, int> TableForFaceCards = new Dictionary<string, int>() { { "A", 14 }, { "K", 13 }, { "D", 12 }, { "J", 11 } };

            int equivalentValueA = 0;
            int equivalentValueB = 0;

            foreach (var item in TableForFaceCards)
            {
                if (_aCards[0].cardValue == item.Key)
                {
                    equivalentValueA = item.Value;
                }
                if (_bCards[0].cardValue == item.Key)
                {
                    equivalentValueB = item.Value;
                }
            }

            if (equivalentValueA > equivalentValueB)
            {
                if (_warPot.Count != 0)
                {
                    Console.WriteLine("A wins the war!");
                    foreach (var card in _warPot)
                    {
                        _aCards.Add(card);
                    }
                    _warPot.Clear();
                }
                Console.WriteLine($"A has: {_aCards[0].cardValue} and B: {_bCards[0].cardValue}");
                Console.WriteLine("A wins");
                _stats.PlayerARoundsWon += 1;
                _stats.battlesDone += 1;

                HandlingPot(_pot, _aCards, _bCards);
            }
            if (equivalentValueA < equivalentValueB)
            {
                if (_warPot.Count != 0)
                {
                    Console.WriteLine("B wins the war!");
                    foreach (var card in _warPot)
                    {
                        _bCards.Add(card);
                    }
                    _warPot.Clear();
                }
                Console.WriteLine($"A has: {_aCards[0].cardValue} and B: {_bCards[0].cardValue}");
                Console.WriteLine("B wins");
                _stats.PlayerBRoundsWon += 1;
                _stats.battlesDone += 1;

                HandlingPot(_pot, _bCards, _aCards);
            }
            else if (equivalentValueA == equivalentValueB)
            {
                TextPresent.warStarted(_aCards[0].cardValue, _bCards[0].cardValue);
                TextPresent.CardStatusBWin(Convert.ToInt32(_aCards.Count), Convert.ToInt32(_bCards.Count));
                Console.WriteLine();

                _stats.warDones += 1;
                WAR();
            }
        }

        
        bool warPossible = true;
        private void WAR()
        {

            if (_aCards.Count <= 4)
            {
                TextPresent.NotEnoughCardsWar("A");
                warPossible = false;
                winner = "B";
                TextPresent.WinnerText(winner);

                GameIsFinished();
            }
            else if (_bCards.Count <= 4)
            {
                TextPresent.NotEnoughCardsWar("B");
                warPossible = false;
                winner = "A";
                TextPresent.WinnerText(winner);

                GameIsFinished();
            }
            for (int i = 0; i < 3; i++)
            {
                if (_aCards.Count <= 3)
                {
                    GameIsFinished();
                    warPossible = false;
                }
                _warPot.Add(_aCards[i]);

            }
            for (int i = 0; i < 3; i++)
            {
                if (_bCards.Count <= 3)
                {
                    GameIsFinished();
                    warPossible = false;
                }
                _warPot.Add(_bCards[i]);

            }
            _aCards.RemoveRange(0, 3);
            _bCards.RemoveRange(0, 3);
        }


        private void HandlingPot(List<Card> pot, List<Card> WinnerCardList, List<Card> LooserCardList)
        {
            pot.Add(_aCards[0]);
            pot.Add(_bCards[0]);
            WinnerCardList.Remove(WinnerCardList[0]);
            LooserCardList.Remove(LooserCardList[0]);

            Random random = new Random();
            int index = random.Next(0, 1);
            if(index == 0)
            {
                WinnerCardList.Add(_pot[0]);
                WinnerCardList.Add(_pot[1]);
                pot.Clear();
            }
            else
            {
                WinnerCardList.Add(_pot[1]);
                WinnerCardList.Add(_pot[0]);
                pot.Clear();
            }

        }

        private void HandlingCardFromTopToBottom()
        {
            _nextCardPotA.Add(_aCards[0]);
            _nextCardPotB.Add(_bCards[0]);

            _aCards.Remove(_aCards[0]);
            _bCards.Remove(_bCards[0]);
            _aCards.Add(_nextCardPotA[0]);
            _bCards.Add(_nextCardPotB[0]);
        }

        private void Setup()
        {
            Console.WriteLine("loading card set...");
            Console.WriteLine(_LoadedCardDeck.cardListLength + " Loaded cards");
            Console.WriteLine("Shuffling cards...");
            _LoadedCardDeck.ShuffleCards(_LoadedCardDeck.cardList);
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
      

        private void giveCards()
        {
            foreach (var card in _cardListShuffled)
            {
                if (_a.cardAmount == _b.cardAmount)
                {
                    _a.assignedCards.Add(card);
                }
                else
                {
                    _b.assignedCards.Add(card);
                }
            }
            _cardListShuffled.Clear();
        }
    }
}
