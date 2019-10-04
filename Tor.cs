using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading;
namespace IkariamBot
{
    class Tor
    {
        Process process;
        Random rnd = new Random();
        string[] lines = File.ReadAllLines(@"c:\Users\Root\Desktop\TorBrowser\BrowserName.txt", Encoding.UTF8);

        public void RunTor()
        {
            process = Process.Start(@"C:\Users\Root\Desktop\TorBrowser\Browser\TorBrowser\Tor\tor.exe");
        }
        public void ChangeIP()
        {
            process.Kill(); Thread.Sleep(250);
            RunTor();
        }
        public string UserBrowser()
        {
            var user = rnd.Next(0, lines.Length);
            return user.ToString();
        }
    }
}

