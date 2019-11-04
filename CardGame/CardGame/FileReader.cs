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

        public FileReader(string fileurl)
        {
            _fileURL = fileurl;

            // Read each line of the file into a string array. Each element
            // of the array is one line of the file.
            _readLines = System.IO.File.ReadAllLines(_fileURL);
        }

        public string[] getReadLines
        {
            get { return _readLines; }
        }
        public string getCardLine(int indexNumber)
        {
            return _readLines[indexNumber];
        }
    }
}
