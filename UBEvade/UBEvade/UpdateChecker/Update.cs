using EloBuddy;
using System;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace UBEvade
{
    class Update
    {
        public static System.Version CurrentVersion = new System.Version("0.0.0.0");
        public static void CheckForUpdates()
        {
            Task.Factory.StartNew(() =>
            {
                try
                {
                    using (var webClient = new WebClient())
                    {
                        var OnlineVersion = webClient.DownloadString("https://raw.githubusercontent.com/Uzumaki-Boruto/On_Process/master/UBEvade/UBEvade/Properties/AssemblyInfo.cs");
                        var match = new Regex(@"\[assembly\: AssemblyVersion\(""(\d{1,})\.(\d{1,})\.(\d{1,})\.(\d{1,})""\)\]").Match(OnlineVersion);

                        if (match.Success)
                        {
                            CurrentVersion = new System.Version(string.Format("{0}.{1}.{2}.{3}", match.Groups[1], match.Groups[2], match.Groups[3], match.Groups[4]));
                            Chat.Print("UBEvade: Please report on my thread if its have any bugs", System.Drawing.Color.HotPink);
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            });
        }
    }
}
