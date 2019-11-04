using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
    class Program
    {
        static void Main(string[] args)
        {
            CardDeck cardDeck = new CardDeck();

            //var deck = cardDeck.CardList;
            //foreach (var card in deck)
            //{
            //    Console.WriteLine(card);
            //}
            //Console.WriteLine("--------------------");

            var list = cardDeck.Shuffel(new Random(), cardDeck.CardList);
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }


            Console.ReadLine();
        }
    }
}
