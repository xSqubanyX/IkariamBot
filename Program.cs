using System;
using System.Threading;
namespace IkariamBot
{
    class Program
    {
        static void Main(string[] args)
        {
            Tor tor = new Tor(); tor.RunTor(); MatchText matchText = new MatchText(); Search search = new Search();
            
            matchText.Komunikat(MatchText.Wybor.Logowanie);
            Thread.Sleep(10000);
            if (search.Logowaniecheck == "udalo sie zalogowac")
            {
                Console.WriteLine("udalo sie zalogowac");
                //matchText.Komunikat(MatchText.Wybor.Rejestracja);
                //matchText.Komunikat(MatchText.Wybor.UP_ratusz);
                //matchText.Komunikat(MatchText.Wybor.wybuduj_akademie);
                // matchText.Komunikat(MatchText.Wybor.wydobycie_akademia);
                //matchText.Komunikat(MatchText.Wybor.UP_akademia);
                //matchText.Komunikat(MatchText.Wybor.BadanieSuchy);

            }
            else
            {
                Console.WriteLine("Nie udalo sie zalogowac");
            }

            Console.ReadKey();
        }
    }
}
