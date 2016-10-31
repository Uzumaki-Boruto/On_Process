using System;
using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Events;
using EloBuddy.SDK.Menu.Values;

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

            Shop.OnBuyItem += Shop_OnBuyItem;
            Shop.OnSellItem += Shop_OnSellItem;

            Update.CheckForUpdates();

            while (Update.CurrentVersion == System.Version.Parse("0.0.0.0"))
            { }
            Notification();

        }

        static void Shop_OnBuyItem(AIHeroClient sender, ShopActionEventArgs args)
        {
            if (!sender.IsMe) return;
            var JustBuyInList = Data.EvadeSkillsData.EvadeSpellDatabase.Items.Any(x => (int)x.ItemId == args.Id);
            if (JustBuyInList || Config.DevelopedMode)
            {
                var data = Data.EvadeSkillsData.EvadeSpellDatabase.Items.Where(x => (int)x.ItemId == args.Id || Config.DevelopedMode).FirstOrDefault();
                Config.EvadeSpells.Add(data.Name, new GroupLabel(data.Name));
                Config.EvadeSpells.Add("Enable" + data.Name, new CheckBox("Enable"));
                Config.EvadeSpells.Add("Combo" + data.Name, new CheckBox("Combo Only", false));
                Config.EvadeSpells.Add("Value" + data.Name, new Slider("Danger Value", data.DangerValue, 1, 5));
                Chat.Print("You have just bought " + args.Name + ". Check Evade Menu for settings", System.Drawing.Color.HotPink);
            }
        }

        static void Shop_OnSellItem(AIHeroClient sender, ShopActionEventArgs args)
        {
            if (!sender.IsMe) return;
            var JustBuyInList = Data.EvadeSkillsData.EvadeSpellDatabase.Items.Any(x => (int)x.ItemId == args.Id);
            if (JustBuyInList || Config.DevelopedMode)
            {
                var data = Data.EvadeSkillsData.EvadeSpellDatabase.Items.Where(x => (int)x.ItemId == args.Id || Config.DevelopedMode).FirstOrDefault();
                Config.EvadeSpells.Remove(data.Name);
                Config.EvadeSpells.Remove("Enable" + data.Name);
                Config.EvadeSpells.Remove("Combo" + data.Name);
                Config.EvadeSpells.Remove("Value" + data.Name);
                Chat.Print("You have just sold " + args.Name, System.Drawing.Color.HotPink);
            }
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
