using System;
using System.Text;

namespace IkariamBot
{
    class MatchText
    {
        HttpRequest httpRequest = new HttpRequest();
        StringBuilder myStringBuilder = new StringBuilder("Akcja : ");
        Search search = new Search();
        
        public enum Wybor
        {
            Logowanie, Rejestracja, Rzpolecenia, WyslanieWiadomosci, UP_ratusz, wybuduj_port, UP_port, wybuduj_akademie,
            wybuduj_mury, wybuduj_koszary, wybuduj_magazyn, wydobycie_drewna, wydobycie_akademia, UP_akademia, BadanieZegluga, BadanieStolarka,
            BadanieNauka, BadaniaWojsko
        }
        public void Komunikat(Wybor br)
        {
            switch (br)
            {
                case Wybor.Logowanie:
                    Console.WriteLine(myStringBuilder.Append(" Logowanie ..."));
                    string logowanie = httpRequest.SearchPost(search.PostLogowanie(), search.PostLogowanieDane(), true);
                    search.Logowanie(logowanie);
                    break;
                case Wybor.WyslanieWiadomosci:
                    Console.WriteLine(myStringBuilder.AppendFormat(" Wysylanie wiadomosci ..."));
                    string wiadomosc = httpRequest.SearchPost(search.PostWysylanieWiadomosci(), search.PostWysylanieWiadomosciDane(), false);
                    Console.WriteLine(wiadomosc);
                    break;
                case Wybor.Rejestracja:
                    Console.WriteLine(myStringBuilder.Append(" Tworzenie konta"));
                    string konto = httpRequest.SearchPost(search.ZakladanieKonta(), search.ZakladanieKontaDane(), true);
                    break;
                case Wybor.UP_ratusz:
                    Console.WriteLine(myStringBuilder.Append(" Upgrade ratusza"));
                    string ratusz = httpRequest.SearchPost(search.UpRatusz(), search.UpratuszDane(), false);
                    break;
                case Wybor.UP_akademia:
                    Console.WriteLine(myStringBuilder.Append(" Upgrade ratusza"));
                    string akademia = httpRequest.SearchPost(search.UpAkademia(), search.UpAkademiaDane(), false);
                    break;
                case Wybor.wybuduj_port:
                    Console.WriteLine(myStringBuilder.Append(" Budowanie portu"));
                    string port = httpRequest.SearchPost(search.B_Port(), search.B_PortDane(), false);
                    break;
                case Wybor.wybuduj_akademie:
                    Console.WriteLine(myStringBuilder.Append(" Budowanie akademi"));
                    string akademiaup = httpRequest.SearchPost(search.B_Akademi(), search.B_AkademiDane(), false);
                    break;
                case Wybor.wybuduj_mury:
                    Console.WriteLine(myStringBuilder.Append(" Budowanie muru"));
                    string mur = httpRequest.SearchPost(search.B_Muru(), search.B_MuruDane(), false);
                    break;
                case Wybor.wybuduj_koszary:
                    Console.WriteLine(myStringBuilder.Append(" Budowanie koszar"));
                    string koszary = httpRequest.SearchPost(search.B_Koszary(), search.B_KoszaryDane(), false);
                    break;
                case Wybor.wybuduj_magazyn:
                    Console.WriteLine(myStringBuilder.Append(" Budowanie koszar"));
                    string magazyn = httpRequest.SearchPost(search.B_Magazynu(), search.B_MagazynuDane(), false);
                    break;
                case Wybor.wydobycie_drewna:
                    Console.WriteLine(myStringBuilder.Append(" Zwiekszanie wydobywania drewna..."));
                    string w_drewna = httpRequest.SearchPost(search.Zwieksz_wydobycie_drewna(), search.Zwieksz_wydobycie_drewnaDane(), false);
                    break;
                case Wybor.wydobycie_akademia:
                    Console.WriteLine(myStringBuilder.Append(" Zwiekszanie wydobywania akademia..."));
                    string w_akademia = httpRequest.SearchPost(search.Zwieksz_wydobycie_akademia(), search.Zwieksz_wydobycie_akademiaDane(), false);
                    break;
                case Wybor.BadanieZegluga:
                    Console.WriteLine(myStringBuilder.Append(" Badanie zegluga(1)"));
                    string B_zegluga = httpRequest.SearchPost(search.BadaniaZegluga(), search.BadaniaZegluga_dane(), false);
                    break;
                case Wybor.BadanieStolarka:
                    Console.WriteLine(myStringBuilder.Append(" Badanie stolarka(2)"));
                    string B_stolarka = httpRequest.SearchPost(search.BadaniaStolarka(), search.BadaniaStolarka_dane(), false);
                    break;
                case Wybor.BadanieNauka:
                    Console.WriteLine(myStringBuilder.Append(" Badanie nauka(3)"));
                    string B_suchy = httpRequest.SearchPost(search.BadaniaNauka(), search.BadaniaNauka_dane(), false);
                    break;
                case Wybor.BadaniaWojsko:
                    Console.WriteLine(myStringBuilder.Append(" Badanie wojsko(4)"));
                    string B_wojsko = httpRequest.SearchPost(search.BadaniaWojsko(), search.BadaniaWojsko_dane(), false);
                    break;

                default:
                    Console.WriteLine("Nieznany blad");
                    break;
            }
        }
    }
}

