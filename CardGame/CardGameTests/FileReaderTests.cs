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
            int cardListLength = filereader.cardListLength;
            //Act 
            //Assert
            Assert.AreEqual(cardListLength, 14);
        }

        [TestMethod()]
        public void FileReaderGetCardOne()
        {
            //Arrange 
            FileReader filereader = new FileReader("C:/Users/Jonas/source/repos/CardGame/Cards.txt");
            var expectedString = "hearts1";
            var actuelString = filereader.getCardLine(0).Replace(" ", ""); ;
            //Act 
            //Assert
            Assert.AreEqual(expectedString, actuelString);
        }
    }
}