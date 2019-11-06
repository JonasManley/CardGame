using CardGame.Games;
using CardGame.Model;
using CardGame.Text;
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
            //CardDeck cardDeck = new CardDeck();
            //Console.WriteLine("Reading from textfile...");
            //Thread.Sleep(2000);
            //var deck = cardDeck.cardList;
            //foreach (var card in deck)
            //{
            //    Console.WriteLine(card);
            //}
            //Thread.Sleep(2000);
            //Console.WriteLine("--------------------");
            //Console.Clear(); Console.WriteLine("Shuffling deck..."); Console.WriteLine();
            //Thread.Sleep(2000);

            //cardDeck.Shuffel(new Random(), cardDeck.cardList);
            //foreach (var item in cardDeck.shuffledCardList)
            //{
            //    Console.WriteLine(item);
            //}


           
            Player A = new Player("Jonas");
            Player B = new Player("Valde");
            WarGame fiveHundred = new WarGame(A, B);

            

            fiveHundred.play();

            


            Console.ReadLine();
        }
    }
}
