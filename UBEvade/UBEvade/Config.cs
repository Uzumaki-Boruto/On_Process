using System;
using System.Drawing;
using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;

namespace UBEvade
{
    class Config
    {
        public static Menu Menu, EnemySpells, EvadeSpells, Drawing, Misc;

        public static void Dattenosa()
        {
            Menu = MainMenu.AddMenu("UBEvade", "UBEvade");
            Menu.Add("Enabled", new KeyBind("Enabled", true, KeyBind.BindTypes.PressToggle));
            Menu.Add("ToggleOnlyDangerous", new KeyBind("Dodge Only dangerous <Toggle>", false, KeyBind.BindTypes.PressToggle));
            Menu.Add("OnlyDangerous", new KeyBind("Dodge only dangerous", false, KeyBind.BindTypes.HoldActive));
            Menu.Add("FOW", new CheckBox("Fog of war Dodge"));
            Menu.AddSeparator();
            if (Player.Instance.ChampionName == "Olaf")
            {
                Menu.Add("DisableEvadeForOlafR", new CheckBox("Disable Evade when Olaf's ulti is active!"));
            }
            if (EntityManager.Heroes.Allies.Any(x => x.ChampionName == "Morgana"))
            {
                Menu.Add("DisableEvadeForMorganaE", new CheckBox("Disable Evade when has Morgana E buff"));
            }
            Menu.Add("DisableEvadeForSpellShield", new CheckBox("Disable Evade when has spell shield"));

            if (Menu == null)
            {
                Chat.Print("UBEVADE LOAD FAILED", Color.Red);
                Console.WriteLine("UBEvade LOAD FAILED");
                throw new NullReferenceException("Menu NullReferenceException");
            }

            EnemySpells = Menu.AddSubMenu("Enemyspells");
            {

            }
        }
    }
}
