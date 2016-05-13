﻿using System;
using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Notifications;
using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;
using EloBuddy.SDK.Rendering;
using EloBuddy.SDK.Events;
using SharpDX;
using Colour = System.Drawing.Color;

namespace UBAzir
{
    class More
    {
        public static void Loading_OnLoadingComplete(EventArgs args)
        {
            if (Player.Instance.ChampionName != "Azir") return;

            var notStart = new SimpleNotification("UBAzir Load Status", "UBAzir sucessfully loaded.");
            Notifications.Show(notStart, 5000);

            Config.Dattenosa();
            Spells.InitSpells();
            InitEvents();
        }

        private static void InitEvents()
        {
            Game.OnTick += GameOnTick;
            Drawing.OnDraw += OnDraw;
            Game.OnTick += ObjManager.GetMyPosBefore;
            Game.OnUpdate += Mode.KillSteal;
            Game.OnUpdate += Mode.Auto_Harass;
            Orbwalker.OnUnkillableMinion += Mode.On_Unkillable_Minion;
        }
        private static void GameOnTick(EventArgs args)
        {
            Orbwalker.ForcedTarget = null;
            if (Player.Instance.IsDead) return;

            if (Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Combo))
            { Mode.Combo(); }
            if (Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Harass))
            { Mode.Harass(); }
            if (Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.LaneClear))
            { Mode.LaneClear(); }
            if (Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.LastHit))
            { Mode.Lasthit(); }
            if (Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.JungleClear))
            { Mode.JungleClear(); }
            if (Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Flee))
            { Mode.Flee(); }

            if (Config.Insec["normalInsec"].Cast<KeyBind>().CurrentValue)
            { Insec.Do_Normal_Insec(); }
            if (Config.Insec["godInsec"].Cast<KeyBind>().CurrentValue)
            { Insec.Do_God_Insec(); }

            if (ObjectManager.Player.SkinId != Config.MiscMenu["Modskinid"].Cast<Slider>().CurrentValue)
            {
                if (Config.MiscMenu["Modskin"].Cast<CheckBox>().CurrentValue)
                {
                    Player.SetSkinId(Config.MiscMenu["Modskinid"].Cast<Slider>().CurrentValue);
                }
            }
        }
        private static void OnDraw(EventArgs args)
        {
            if (Config.DrawMenu["Qdr"].Cast<CheckBox>().CurrentValue)  
            {
                Circle.Draw(Spells.Q.IsLearned ? Color.HotPink : Color.Zero, Spells.Q.Range, Player.Instance.Position);
            }
            
            if (Config.DrawMenu["Wcastdr"].Cast<CheckBox>().CurrentValue)    
            {
                Circle.Draw(Spells.W.IsLearned ? Color.Cyan : Color.Zero, Spells.W.Range, Player.Instance.Position);
            }

            if (Config.DrawMenu["Edr"].Cast<CheckBox>().CurrentValue)
            {
                Circle.Draw(Spells.E.IsLearned ? Color.Orange : Color.Zero, Spells.E.Range, Player.Instance.Position);
            }

            if (Config.DrawMenu["Rdr"].Cast<CheckBox>().CurrentValue)
            {
                Circle.Draw(Spells.R.IsLearned ? Color.Yellow : Color.Zero, Spells.R.Range, Player.Instance.Position);
            }
            
        }
    }
}