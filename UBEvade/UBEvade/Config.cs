using System;
using System.Reflection;
using System.Drawing;
using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;
using UBEvade.Data.EvadeSkillsData;

namespace UBEvade
{
    class Config
    {
        public static bool DevelopedMode = true;
        public static Menu Menu, EnemySpells, EvadeSpells, Drawing, Misc;
        public static string CurrentGameVersion = "6.21";

        public static void Dattenosa()
        {
            var name = Assembly.GetCallingAssembly().GetName();
            Menu = MainMenu.AddMenu("UBEvade", "UBEvade");
            Menu.AddGroupLabel("UBEvade - version " + typeof(Program).Assembly.GetName().Version.ToString());
            Menu.AddGroupLabel("UBEvade - Upgrade to LoL version " + CurrentGameVersion);
            Menu.Add("Enabled", new KeyBind("Enabled", true, KeyBind.BindTypes.PressToggle, 77));
            Menu.Add("ToggleOnlyDangerous", new KeyBind("Dodge Only dangerous <Toggle>", false, KeyBind.BindTypes.PressToggle));
            Menu.Add("OnlyDangerous", new KeyBind("Dodge only dangerous", false, KeyBind.BindTypes.HoldActive, 32));
            Menu.Add("FOW", new CheckBox("Fog of war Dodge"));
            Menu.AddSeparator();
            if (Menu == null)
            {
                Chat.Print("UBEVADE LOAD FAILED", Color.Red);
                Console.WriteLine("UBEvade LOAD FAILED");
                throw new NullReferenceException("Menu NullReferenceException");
            }

            EnemySpells = Menu.AddSubMenu("EnemySpells");
            {
                foreach (var hero in EntityManager.Heroes.AllHeroes)
                {
                    if (hero.Team != Player.Instance.Team || DevelopedMode)
                    {
                        foreach (var spell in Data.SkillshotsData.SpellsDatabase.Spells)
                        {
                            if (spell.ChampionName == hero.ChampionName)
                            {
                                EnemySpells.AddGroupLabel(spell.MenuName);
                                EnemySpells.Add("Enabled" + spell.SpellName, new CheckBox("Enabled", !spell.DefaultDisable));
                                EnemySpells.Add("Draw" + spell.SpellName, new CheckBox("Draw"));
                                EnemySpells.Add("IsDangerous" + spell.SpellName, new CheckBox("Is Dangerous", spell.IsDangerous));
                                EnemySpells.Add("DangerValue" + spell.SpellName, new Slider("Danger Value", spell.DangerValue, 1, 5));
                            }
                        }
                    }
                }
            }

            EvadeSpells = Menu.AddSubMenu("EvadeSpells");
            {
                foreach (var spell in Data.EvadeSkillsData.EvadeSpellDatabase.Spells.OrderBy(x => x.DangerValue))
                {
                    EvadeSpells.AddGroupLabel(spell.Name);
                    EvadeSpells.Add("Enable" + spell.Name, new CheckBox("Enable", !spell.DefautDisable));
                    if (spell.Type == EvadeType.Shield && spell.CanCastAllies)
                    {
                        foreach (var ally in EntityManager.Heroes.Allies)
                        {
                            EvadeSpells.Add("Enable" + spell.Name + ally.ChampionName, new CheckBox("Shield" + ally.ChampionName));
                        }
                    }
                    EvadeSpells.Add("DangerValue" + spell.Name, new Slider("Danger Value", spell.DangerValue, 1, 5));
                }
            }

            Misc = Menu.AddSubMenu("Misc");
            {
                string[] champ = { "Sivir", "Nocturne" };
                Misc.AddGroupLabel("Misc Setting");
                Misc.Add("PreventCancelAA", new CheckBox("Prevent Cancel AA", false));
                Misc.Add("PreventEvadeRecall", new CheckBox("Prevent Evade while recalling"));

                Misc.Add("ExtraRange", new Slider("Extra Range", 10));
                Misc.Add("ExtraRadius", new Slider("Extra Radius/Width", 10));
                if (Player.Instance.ChampionName == "Olaf")
                {
                    Misc.Add("DisableEvadeForOlafR", new CheckBox("Disable Evade when Olaf's ulti is active!"));
                }
                if (EntityManager.Heroes.Allies.Any(x => x.ChampionName == "Morgana"))
                {
                    Misc.Add("DisableEvadeForMorganaE", new CheckBox("Disable Evade when has Morgana E buff"));
                }
                if (champ.Contains(Player.Instance.ChampionName))
                {
                    Misc.Add("DisableEvadeForSpellShield", new CheckBox("Disable Evade when has spell shield"));
                }
                Misc.AddGroupLabel("Block spells");
                foreach (var spell in SpellBlock.BlockList.SpellsBlock)
                {
                    
                }
            }
        }
    }
}
