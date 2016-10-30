using System;
using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Events;

namespace UBEvade
{
    class Program
    {
        static void Main(string[] args)
        {
            Loading.OnLoadingComplete += Loading_OnLoadingComplete;
        }

        static void Loading_OnLoadingComplete(System.EventArgs args)
        {
            Config.Dattenosa();

            Update.CheckForUpdates();

            while (Update.CurrentVersion == System.Version.Parse("0.0.0.0"))
            { }
            Notification();

        }
        static void Notification()
        {
            if (Update.CurrentVersion == typeof(Program).Assembly.GetName().Version)
                Chat.Print("UBEvade - Your version is up to date, current version: " + Update.CurrentVersion +", enjoy. Thanks for using UBEvade", System.Drawing.Color.HotPink);
            else
                Chat.Print("UBEvade - Your version is outdate, current version: " + Update.CurrentVersion + ", pls update to newest version. Thanks for using UBEvade", System.Drawing.Color.HotPink);
        }
    }
}
