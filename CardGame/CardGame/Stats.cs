using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
    class Stats
    {
        private int _battlesDone;
        private int _warDones;
        private int _playerARoundsWon;
        private int _playerBRoundsWon;

        public Stats()
        {

        }

        public int battlesDone
        {
            get { return _battlesDone; }
            set { _battlesDone = value; }
        }

        public int warDones
        {
            get { return _warDones; }
            set { _warDones = value; }
        }

        public int PlayerARoundsWon
        {
            get { return _playerARoundsWon; }
            set { _playerARoundsWon = value; }
        }

        public int PlayerBRoundsWon
        {
            get { return _playerBRoundsWon; }
            set { _playerBRoundsWon = value; }
        }

        public double percentageForWar()
        {
            return (_warDones / _battlesDone)*100;
        }
        
    }
}
