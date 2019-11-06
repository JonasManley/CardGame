using Microsoft.VisualStudio.TestTools.UnitTesting;
using CardGame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame.Tests
{
    [TestClass()]
    public class CardDeckTests
    { 
      /// <ATTENTION>
      /// URL to the card -.txt need to be updated if you change computer.
        public static string urlTXTFile = "C:/Users/Jonas/Documents/GitHub/CardGame/Cards.txt";


        [TestMethod()]
        public void CardDeckCreateDeck()
        {
            //Arrange 
            FileReader filereader = new FileReader(urlTXTFile);
            CardDeck deck = new CardDeck();

            var expectedAmount = 52;
            var actuelAmount = deck.cardListLength;
            //Act 

            //Assert
            Assert.AreEqual(expectedAmount, actuelAmount);
        }

        [TestMethod()]
        public void CardDeckShuffleContains52Still()
        {
            //Arrange 
            FileReader filereader = new FileReader(urlTXTFile);
            CardDeck deck = new CardDeck();
            var createdCardDeck = deck.cardList;
            Random randomGen = new Random();
            deck.Shuffel(randomGen, createdCardDeck);

            var expectedAmount = 52;
            var actuelAmount = deck.cardListLength;
            //Act 

            //Assert
            Assert.AreEqual(expectedAmount, actuelAmount);
        }

        [TestMethod()]
        public void CardDeckShuffleAreEquelToNonShuffled()
        {
            //Arrange 
            FileReader filereader = new FileReader(urlTXTFile);
            CardDeck deck = new CardDeck();
            var createdCardDeck = deck.cardList;
            Random randomGen = new Random();
            deck.Shuffel(randomGen, createdCardDeck);

            var NonShuffledList = deck.cardList;
            var ShuffledList = deck.shuffledCardList;
            //Act 

            //Assert
            Assert.AreNotEqual(NonShuffledList, ShuffledList);
        }
    }
}