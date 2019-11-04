using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
    public class FileReader
    {
        private string _fileURL;
        private string[] _readLines;
        private List<Card> _cardList;

        public FileReader(string fileurl)
        {
            _fileURL = fileurl;
            _cardList = new List<Card>();

            // Read each line of the file into a string array. Each element
            // of the array is one line of the file.
            _readLines = System.IO.File.ReadAllLines(_fileURL);
            read();
        }

        private void read()
        {
            if (_readLines.Length == 0)
            {
                throw new ArgumentException("txt file not found or invalid, please check sourse and try agian...");
            }
            foreach (var itemLine in _readLines)
            {
                string[] cardItems = itemLine.Split(' ');
                string cardColor = cardItems[0];
                string cardValue = cardItems[1];
                Card card = new Card(cardColor, cardValue);
                _cardList.Add(card);
            }
        }
        

        public int cardListLength
        {
            get { return _cardList.Count(); }
        }
        public string getCardLine(int indexNumber)
        {
            return _readLines[indexNumber];
        }


    }
}
