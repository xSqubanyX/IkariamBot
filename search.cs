using System;
using System.Text.RegularExpressions;
using System.IO;
namespace IkariamBot
{
    class Search
    {
        public string name = "something"; Random rd = new Random();
        public string Logowaniecheck { set; get; }

        public enum Budowanie
        {
            Magazyn = 5,
            Koszart = 6,
            Mur = 8,
            Akademia = 4,
            Port = 3
        }
        private string logowanie;
        public string PostLogowanie() { return "https://s19-pl.ikariam.gameforge.com/index.php?action=loginAvatar&function=login"; }
        public string PostLogowanieDane() { return "uni_url=s19-pl.ikariam.gameforge.com&name=Witanelo3123@wp.pl&password=Witanelo3123&pwat_uid=&pwat_checksum=&startPageShown=1&detectedDevice=1&kid=&autoLogin=on"; }
        
        public string PostWysylanieWiadomosci() { return "https://s19-pl.ikariam.gameforge.com/index.php"; }
        public string PostWysylanieWiadomosciDane() { return "action=Messages&function=send&receiverId=80814&closeView=1&msgType=50&content=JakasTesowaWiadomosc&isMission=1&allyId=0&backgroundView=island&currentIslandId=34&templateView=sendIKMessage&actionRequest=8a04a557b54cd54762c980eb6dd98235&ajax=1"; }

        public string UpRatusz() { return "https://s19-pl.ikariam.gameforge.com/index.php"; }
        public string UpratuszDane() { return "action=CityScreen&function=upgradeBuilding&actionRequest=" + actionRequest() + "&cityId=" + cityID() + "&position=0&level=1&backgroundView=city&currentCityId=" + cityID() + "&templateView=townHall"; }

        public string UpAkademia() { return "https://s19-pl.ikariam.gameforge.com/index.php"; }
        public string UpAkademiaDane() { return "action=CityScreen&function=upgradeBuilding&actionRequest=" + actionRequest() + "&cityId=" + cityID() + "&position=6&level=1&backgroundView=city&currentCityId=" + cityID() + "&templateView=academy"; }

        public string UpPort() { return "https://s19-pl.ikariam.gameforge.com/index.php"; }
        public string UpPortDane() { return "action=CityScreen&function=upgradeBuilding&actionRequest=" + actionRequest() + "&cityId=" + cityID() + "&position=0&level=1&backgroundView=city&currentCityId=" + cityID() + "&templateView=academy"; }

        public string B_Port() { return "https://s19-pl.ikariam.gameforge.com/index.php"; }
        public string B_PortDane() { return "action=CityScreen&function=build&cityId=" + cityID() + "&position=1&building=3&backgroundView=city&currentCityId=" + cityID() + "&templateView=buildingGround&actionRequest=" + actionRequest() + ""; }

        public string B_Akademi() { return "https://s19-pl.ikariam.gameforge.com/index.php"; }
        public string B_AkademiDane() { return "action=CityScreen&function=build&cityId=" + cityID() + "&position=6&building=4&backgroundView=city&currentCityId=" + cityID() + "&templateView=buildingGround&actionRequest=" + actionRequest() + ""; }

        public string B_Muru() { return "https://s19-pl.ikariam.gameforge.com/index.php"; }
        public string B_MuruDane() { return "action=CityScreen&function=build&cityId=" + cityID() + "&position=14&building=8&backgroundView=city&currentCityId=" + cityID() + "&templateView=buildingGround&actionRequest=" + actionRequest() + ""; }

        public string B_Koszary() { return "https://s19-pl.ikariam.gameforge.com/index.php"; }
        public string B_KoszaryDane() { return "action=CityScreen&function=build&cityId=" + cityID() + "&position=3&building=6&backgroundView=city&currentCityId=" + cityID() + "&templateView=buildingGround&actionRequest=" + actionRequest() + ""; }

        public string B_Magazynu() { return "https://s19-pl.ikariam.gameforge.com/index.php"; }
        public string B_MagazynuDane() { return "action=CityScreen&function=build&cityId=" + cityID() + "&position=12&building=5&backgroundView=city&currentCityId=" + cityID() + "&templateView=buildingGround&actionRequest=" + actionRequest() + ""; }

        public string Zwieksz_wydobycie_drewna() { return "https://s19-pl.ikariam.gameforge.com/index.php"; }
        public string Zwieksz_wydobycie_drewnaDane() { return "action=IslandScreen&function=workerPlan&type=resource&islandId=" + islandId() + "&cityId=" + cityID() + "&screen=resource&rw=50&backgroundView=island&currentIslandId=" + islandId() + "&templateView=resource&actionRequest=" + actionRequest() + "&ajax=1"; }

        public string Zwieksz_wydobycie_akademia() { return "https://s19-pl.ikariam.gameforge.com/index.php"; }
        public string Zwieksz_wydobycie_akademiaDane() { return "action=IslandScreen&function=workerPlan&screen=academy&position=6%2F&cityId=" + cityID() + "&s=1&backgroundView=city&currentCityId=" + cityID() + "&templateView=academy&actionRequest=" + actionRequest() + "&ajax=1"; }

        public string BadaniaZegluga() { return "https://s19-pl.ikariam.gameforge.com/index.php"; }
        public string BadaniaZegluga_dane() { return "action=Advisor&function=doResearch&actionRequest="+actionRequest()+"&type=seafaring&position=6&backgroundView=city&currentCityId=" + cityID()+"&templateView=researchAdvisor"; }

        public string BadaniaStolarka() { return "https://s19-pl.ikariam.gameforge.com/index.php"; }
        public string BadaniaStolarka_dane() { return "action=Advisor&function=doResearch&actionRequest="+actionRequest()+"&type=economy&position=6&backgroundView=city&currentCityId=" + cityID()+"&templateView=researchAdvisor"; }

        public string BadaniaNauka() { return "https://s19-pl.ikariam.gameforge.com/index.php"; }
        public string BadaniaNauka_dane() { return "action=Advisor&function=doResearch&actionRequest="+actionRequest()+"&type=knowledge&backgroundView=city&currentCityId=" + cityID()+"&templateView=researchAdvisor"; }

        public string BadaniaWojsko() { return "https://s19-pl.ikariam.gameforge.com/index.php"; }
        public string BadaniaWojsko_dane() { return "action=Advisor&function=doResearch&actionRequest=" + actionRequest() + "&type=military&backgroundView=city&currentCityId=" + cityID() + "&templateView=researchAdvisor"; }

        public string ZmianaNazwyGracza() { return "https://s19-pl.ikariam.gameforge.com/index.php"; }
        public string ZmianaNazwyGracza_dane() { return "action=CityScreen&function=rename&cityId="+cityID()+"&position=0&name="+name+"&backgroundView=city&currentCityId="+cityID()+"&templateView=townHall&actionRequest="+actionRequest()+"&ajax=1"; }

        public string ZakladanieKonta() { return "https://s19-pl.ikariam.gameforge.com/index.php"; }
        public string ZakladanieKontaDane() { return "action=newPlayer&function=createAvatar&friendId=100583&fh=736c8b064ad68752c6b46ecc5afa0287&list=0&kid=&email="+RandomLogin()+"%40wp.pl&password="+RandomHaslo()+"&agb=on"; }

        public string MasoweWysylanieWiadomosc() { return ""; }
        public string MasoweWysylanieWiadomoscDane() { return ""; }

        public string KodCaptchaDownolad() { return "https://s19-pl.ikariam.gameforge.com/index.php?action=Options&function=createCaptcha"; }
        public string KodCaptchaDownoladDane() { return ""; }

        public string SzkoleniePiratow() { return "https://s19-pl.ikariam.gameforge.com/index.php"; }
        public string SzkoleniePiratowDane() { return "action=PiracyScreen&function=capture&buildingLevel=1&view=pirateFortress&cityId="+cityID()+"&position=17&activeTab=tabBootyQuest&backgroundView=city&currentCityId="+cityID()+"&templateView=pirateFortress&actionRequest="+actionRequest()+""; }

        public string actionRequest()
        {
            string pattern = @"value=.[0-9a-f]{32}."; 
            var match = Regex.Match(logowanie, pattern); string x = match.ToString();string patternx = @"[0-9a-f]{32}";  var matchx = Regex.Match(x, patternx); string xx = matchx.ToString();return xx;
        }
        public string cityID()
        {
            string pattern = @"cityId=[0-9]{4,7}";
            var match = Regex.Match(logowanie, pattern); string x = match.ToString();string patternx = @"[0-9]{4,7}";var matchx = Regex.Match(x, patternx); string xx = matchx.ToString();return xx;
        }
        public string islandId()
        {
            string pattern = @"islandId=[0-9]{3,5}"; 
            var match = Regex.Match(logowanie, pattern); string x = match.ToString(); string patternx = @"[0-9]{3,5}"; var matchx = Regex.Match(x, patternx); string xx = matchx.ToString();return xx;
        }
        public string IloscDrewna() 
        {
            return "";
        }
        public string IloscWina()
        {
            return "";
        }
        public string IloscKamienia()
        {
            return "";
        }
        public string IloscKrysztalui()
        {
            return "";
        }
        public string IloscSiarki()
        {
            return "";
        }
        public string CheckCaptcha()
        {
            return "";
        }
        public string RandomLogin()
        {
                const string allowedChars = "ABCDEFGHJKLMNOPQRSTUVWXYZabcdefghijkmnopqrstuvwxyz0123456789";
                char[] chars = new char[12];
                for (int i = 0; i < 12; i++)
                {
                    chars[i] = allowedChars[rd.Next(0, allowedChars.Length)];
                }
                string path = @"c:\temp\Login.txt";
                File.WriteAllText(path, new string(chars));
            return new string(chars);
        }
        public string RandomHaslo()
        {
            const string allowedChars = "ABCDEFGHJKLMNOPQRSTUVWXYZabcdefghijkmnopqrstuvwxyz0123456789";
            char[] chars = new char[10];
            for (int i = 0; i < 10; i++)
            {
                chars[i] = allowedChars[rd.Next(0, allowedChars.Length)];
            }
            string path = @"c:\temp\Haslo.txt";
            File.WriteAllText(path, new string(chars));
            return new string(chars);
        }
        public void Logowanie(string logowanie)
        {
            this.logowanie = logowanie; actionRequest(); cityID(); islandId();
            var match = Regex.Match(logowanie, "Zły login lub złe hasło!", RegexOptions.IgnoreCase);
            if (!match.Success)
            { Logowaniecheck = "udalo sie zalogowac"; Console.WriteLine("udalo sie zalogowac");  }
            else { Logowaniecheck = "Nie udalo sie zalogowac";  Console.WriteLine("Nie udalo sie zalogowac"); }
        }
        public void wykonanie()
        {

        }
    }
}
