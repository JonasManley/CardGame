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
    public class FileReaderTests
    {

        /// <ATTENTION>
        /// URL to the card -.txt need to be updated if you change computer.
        string urlTXTFile = "C:/Users/Jonas/Documents/GitHub/CardGame/Cards.txt";



        [TestMethod()]
        public void FileReaderTest()
        {
            //Arrange 
            FileReader filereader = new FileReader(urlTXTFile);
            CardDeck cardDeck = new CardDeck();
            var lenght = cardDeck.cardListLength;
            //Act 

            //Assert
            Assert.AreEqual(lenght, 52);
        }

        [TestMethod()]
        public void FileReaderGetCardOne()
        {
            //Arrange 
            FileReader filereader = new FileReader(urlTXTFile);
            var expectedString = "hearts2";
            var actuelString = filereader.getCardLine(0).Replace(" ", ""); ;
            //Act 

            //Assert
            Assert.AreEqual(expectedString, actuelString);
        }

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