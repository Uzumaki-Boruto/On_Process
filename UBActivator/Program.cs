using System;
using EloBuddy;
using EloBuddy.SDK;
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
            Config.Dattenosa();
            Spells.InitSpells();
            Items.InitItems();

            Obj_AI_Base.OnBuffGain += Clean.OnBuffGain;

            Orbwalker.OnPostAttack += Offensive.OnPostAttack;
            Orbwalker.OnPreAttack += Offensive.OnPreAttack;

            Game.OnTick += Offensive.Ontick;
            Game.OnTick += Offensive.OnTick2;
            Game.OnTick += Offensive.OnTick3;
            Game.OnTick += Utility.Game_OnTick;
            Game.OnTick += Utility.OnTick;
            Game.OnTick += Potions.OnTick;
            Game.OnTick += Spells.JungSteal;
            Game.OnTick += Spells.KillSteal;
            Game.OnTick += Spells.UseHeal;


        }    
    }
}
