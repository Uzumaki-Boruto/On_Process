using System;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Notifications;
using EloBuddy.SDK.Menu.Values;
using EloBuddy.SDK.Events;


namespace UBActivator
{
    class Program
    {
        static void Main(string[] args)
        {
            Loading.OnLoadingComplete += Loading_OnLoadingComplete;
        }

        static void Loading_OnLoadingComplete(EventArgs args)
        {
            if (Game.MapId != GameMapId.SummonersRift) return;
            var notStart = new SimpleNotification("UBActivator Load Status", "UBActivator sucessfully loaded.");
            Notifications.Show(notStart, 5000);

            Config.Dattenosa();
            Spells.InitSpells();
            Items.InitItems();
            InitEvent();
        }
        static void InitEvent()
        {
            Game.OnTick += _Game;

            Obj_AI_Base.OnBuffGain += Clean.OnBuffGain;

            Orbwalker.OnPostAttack += Offensive.OnPostAttack;
            Orbwalker.OnPreAttack += Offensive.OnPreAttack;

            Gapcloser.OnGapcloser += Offensive.Gapcloser_OnGapcloser;

            Obj_AI_Base.OnProcessSpellCast += Defense.OnProcessSpellCast;
            Obj_AI_Base.OnProcessSpellCast += Defensive.OnProcessSpellCast;
            Obj_AI_Base.OnProcessSpellCast += Ward.OnProcessSpellCast;
        }
       
        static void _Game(EventArgs args)
        {
            Offensive.Ontick();
            Offensive.OnTick2();
            Offensive.OnTick3();
            Offensive.OnTick4();
            Offensive.KillSteal();
            Utility.Game_OnTick();
            Utility.OnTick();
            Combat.OnTick();
            Potions.OnTick();
            Spells.JungSteal();
            Spells.KillSteal();
            Spells.UseHeal();
            Ward.OnTick();
        }
        
    }
}
