using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CardGame.Text
{
    class TextPresent
    {
        public TextPresent()
        {

        }

        public void WelcomeText()
        {
            Console.WriteLine("---------------------------------------------------------------------------");
            Console.WriteLine("***        II   II    II  IIII  II     III   III   IIÍ III  IIII        ***");
            Console.WriteLine("***         II II II II   II    II    I     I   I  II I II  II          ***");
            Console.WriteLine("***          II    II     IIII  IIII   III   III   II   II  IIII        ***");
            Console.WriteLine("---------------------------------------------------------------------------");

            Thread.Sleep(3000);
            Console.Clear();
        }

        public void EndText()
        {
            Console.WriteLine("---------------------------------------------------------------------------");
            Console.WriteLine("***                       IIII  IIÍ  II  ÍII                            ***");
            Console.WriteLine("***                       II    II I II  II  I                          ***");
            Console.WriteLine("***                       IIII  II  III  III                            ***");
            Console.WriteLine("---------------------------------------------------------------------------");

            Thread.Sleep(3000);
            Console.Clear();
        }

        public void WinnerText(string winner)
        {
            Console.WriteLine("---------------------------------------------------------------------------");
            Console.WriteLine("***                            WINNER IS:                               ***");
            Console.WriteLine("---------------------------------------------------------------------------");
            Console.WriteLine("***                                                                     ***");
            Console.WriteLine($"***                                   {winner}                                 ***");
            Console.WriteLine("***                                                                     ***");
            Console.WriteLine("---------------------------------------------------------------------------");
        }

        public void CardStatusBWin(int aCardAmout, int bCardAmout)
        {
            Console.WriteLine("---------------------------------------------------------------------------");
            Console.WriteLine("***                           CARD STATUS                               ***");
            Console.WriteLine($"***                  A has: {aCardAmout} and B: {bCardAmout}                  ***");
            Console.WriteLine("---------------------------------------------------------------------------");
        }

        public void NotEnoughCardsWar(String whoHasNoCards)
        {
            Console.WriteLine("---------------------------------------------------------------------------");
            Console.WriteLine($"***                  {whoHasNoCards}do not have enough cards to complete war.             ***");
            Console.WriteLine("---------------------------------------------------------------------------");
        }

        public void warStarted(string aCardValue, string bCardValue)
        {
            Console.WriteLine("---------------------------------------------------------------------------");
            Console.WriteLine("***                             WAR!!!!!!                               ***");
            Console.WriteLine($"***                  a has: {aCardValue} and b has: {bCardValue}                              ***");
            Console.WriteLine("---------------------------------------------------------------------------");
        }
    }
}
