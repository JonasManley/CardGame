using Model.CardGame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame.Model
{
    public class Shuffle
    {
        public List<Card> _shuffledList;
        private Random _random = new Random();

        //Fisher–Yates shuffle algorithm - https://en.wikipedia.org/wiki/Fisher%E2%80%93Yates_shuffle#The_.22inside-out.22_algorithm 
        public void ShuffleCards(List<Card> source)
        {
            foreach (var item in source)
            {
                var i = _random.Next(_shuffledList.Count + 1);
                if (i == _shuffledList.Count)
                {
                    _shuffledList.Add(item);
                }
                else
                {
                    var temp = _shuffledList[i];
                    _shuffledList[i] = item;
                    _shuffledList.Add(temp);
                }
            }
        }
    }
}
