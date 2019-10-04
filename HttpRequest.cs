using System;
using System.IO;
using System.Net;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace IkariamBot
{
    class HttpRequest
    {
        Tor tor = new Tor();
        string user;
        CookieContainer cookieContainer = new CookieContainer();
        public string SearchPost(string link, string post, bool cookie)
        {
            user = tor.UserBrowser();
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(link);
            request.Proxy = new WebProxy("127.0.0.1:8118");
            request.UserAgent = user;
            request.Referer = "https://s19-pl.ikariam.gameforge.com/index.php";
            request.Method = "POST"; request.ContentType = "application/x-www-form-urlencoded"; request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8"; request.KeepAlive = true;
            if (cookie)
                request.CookieContainer = cookieContainer;
            else
                request.CookieContainer = ReadCookies();
            using (var stream = request.GetRequestStream())
            {
                byte[] data = Encoding.UTF8.GetBytes(post);
                stream.Write(data, 0, data.Length);
            }
            using (var response = request.GetResponse() as HttpWebResponse)
            {
                request.CookieContainer.Add(response.Cookies);
                SaveCookie();
                using (var sr = new StreamReader(response.GetResponseStream()))
                {
                    return sr.ReadToEnd();
                }
            }
        }
        public string SearchGet(string url)
        {
            HttpWebRequest myHttpWebRequest = (HttpWebRequest)HttpWebRequest.Create(url);
            myHttpWebRequest.Proxy = new WebProxy("127.0.0.1:8118");
            myHttpWebRequest.Method = "GET"; myHttpWebRequest.ContentType = "application/x-www-form-urlencoded"; myHttpWebRequest.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8"; myHttpWebRequest.KeepAlive = true;
            myHttpWebRequest.UserAgent = user;
            myHttpWebRequest.CookieContainer = ReadCookies();
            using (var responsex = myHttpWebRequest.GetResponse() as HttpWebResponse)
            {
                myHttpWebRequest.CookieContainer.Add(responsex.Cookies);
                SaveCookie();
                using (var sr = new StreamReader(responsex.GetResponseStream()))
                {
                    return sr.ReadToEnd();
                }
            }
        }
        public void SaveCookie()
        {
            using (Stream stream = File.Create(@"C:\Temp\cookie"))
            {
                Console.Out.WriteLine("Zapis na dysk pliku cookies...");
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, cookieContainer);
            }
        }
        public static CookieContainer ReadCookies()
        {
            using (Stream stream = File.Open(@"C:\Temp\cookie", FileMode.Open))
            {
                Console.Out.WriteLine("Wczytywanie pliku cookies...");
                BinaryFormatter formatter = new BinaryFormatter();
                return (CookieContainer)formatter.Deserialize(stream);
            }

        }
    }
}
