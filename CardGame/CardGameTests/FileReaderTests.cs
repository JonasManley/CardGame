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
        [TestMethod()]
        public void FileReaderTest()
        {
            //Arrange 
            FileReader filereader = new FileReader("C:/Users/Jonas/source/repos/CardGame/Cards.txt");
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
            FileReader filereader = new FileReader("C:/Users/Jonas/source/repos/CardGame/Cards.txt");
            var expectedString = "hearts2";
            var actuelString = filereader.getCardLine(0).Replace(" ", ""); ;
            //Act 
            //Assert
            Assert.AreEqual(expectedString, actuelString);
        }
    }
}