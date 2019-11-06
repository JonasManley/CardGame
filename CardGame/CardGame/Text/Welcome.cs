using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CardGame.Text
{
    class Welcome
    {
        public Welcome()
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
    }
}
