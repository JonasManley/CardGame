using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CardGame
{
    class Program
    {
        static void Main(string[] args)
        {
            CardDeck cardDeck = new CardDeck();
            Console.WriteLine("Reading from textfile...");
            Thread.Sleep(2000);
            var deck = cardDeck.CardList;
            foreach (var card in deck)
            {
                Console.WriteLine(card);
            }
            Thread.Sleep(2000);
            Console.WriteLine("--------------------");
            Console.Clear(); Console.WriteLine("Shuffling deck..."); Console.WriteLine();
            Thread.Sleep(2000);

            var list = cardDeck.Shuffel(new Random(), cardDeck.CardList);
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }


            Console.ReadLine();
        }
    }
}
