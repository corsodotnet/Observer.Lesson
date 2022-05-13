using System;

namespace Observer.Pattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IBM ibm = new IBM("IBM", 120.00);
            ibm.Attach(new Investor("Sorros"));
            ibm.Attach(new Investor("Berkshire"));
            ibm.investors[0].Investment = 1000;
            ibm.Price = 120.10;
           
            ibm.investors[1].Investment = -300;
            ibm.Price = 70;

            //// Fluctuating prices will notify investors

            // Wait for user
            Console.ReadKey();
        }
    }
}

