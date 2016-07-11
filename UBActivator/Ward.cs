using System;
using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Menu.Values;
using SharpDX;

namespace UBActivator
{
    class Ward
    {
        public static float LastWard;
        public static bool CanCastWard
        {
            get { return Game.Time - LastWard > 1.25f; }
        }
        public static void OnTick()
        {
            if (!Config.Ward["enableward"].Cast<CheckBox>().CurrentValue || !Config.Ward["enablebrush"].Cast<CheckBox>().CurrentValue) return;
            if (Items.Vision_Ward == null && Items.Ruby_Sightstone == null && Items.Sightstone == null && Items.Eye_of_the_Equinox == null
                && Items.Eye_of_the_Oasis == null && Items.Eye_of_the_Watchers == null && Items.Farsight_Alteration == null
                && Items.Warding_Totem == null && Items.Tracker_s_Knife == null && Items.Tracker_s_Knife_Enchantment_Devourer == null
                && Items.Tracker_s_Knife_Enchantment_Runic_Echoes == null && Items.Tracker_s_Knife_Enchantment_Sated_Devourer == null
                && Items.Tracker_s_Knife_Enchantment_Warrior == null && Items.Tracker_s_Knifee_Enchantment_Cinderhulk == null) return;
            foreach (var heros in EntityManager.Heroes.Enemies.Where(x => !x.IsDead && x.Distance(Player.Instance) < 1000))
            {
                var Path = heros.Path.LastOrDefault();
                var Time = Config.Ward["warddelay"].Cast<Slider>().CurrentValue;
                var Delay = Config.Ward["wardhuman"].Cast<CheckBox>().CurrentValue ?
                    new Random().Next(0, Time) :
                    Time;
                if (NavMesh.IsWallOfGrass(Path, 1))
                {
                    if (heros.Distance(Path) > 200) return;
                    if (NavMesh.IsWallOfGrass(Player.Instance.Position, 1) && Player.Instance.Distance(Path) < 200) return;

                    if (Player.Instance.Distance(Path) <= 600)
                    {
                        foreach (var obj in ObjectManager.Get<AIHeroClient>().Where(x => x.Name.ToLower().Contains("ward") && x.IsAlly && x.Distance(Path) < 300))
                        {
                            if (NavMesh.IsWallOfGrass(obj.Position, 1)) return;
                        }
                        #region Ward Cast
                        if (Items.Vision_Ward != null && Items.Vision_Ward.IsOwned() && Items.Vision_Ward.IsReady() && CanCastWard)
                        {
                            Core.DelayAction(() => Items.Vision_Ward.Cast(Path), Delay);
                            LastWard = Game.Time;
                        }
                        else if (Items.Ruby_Sightstone != null && Items.Ruby_Sightstone.IsOwned() && Items.Ruby_Sightstone.IsReady() && CanCastWard)
                        {
                            Core.DelayAction(() => Items.Ruby_Sightstone.Cast(Path), Delay);
                            LastWard = Game.Time;
                        }
                        else if (Items.Sightstone != null && Items.Sightstone.IsOwned() && Items.Sightstone.IsReady() && CanCastWard)
                        {
                            Core.DelayAction(() => Items.Sightstone.Cast(Path), Delay);
                            LastWard = Game.Time;
                        }
                        else if (Items.Eye_of_the_Equinox != null && Items.Eye_of_the_Equinox.IsOwned() && Items.Eye_of_the_Equinox.IsReady() && CanCastWard)
                        {
                            Core.DelayAction(() => Items.Eye_of_the_Equinox.Cast(Path), Delay);
                            LastWard = Game.Time;
                        }
                        else if (Items.Eye_of_the_Oasis != null && Items.Eye_of_the_Oasis.IsOwned() && Items.Eye_of_the_Oasis.IsReady() && CanCastWard)
                        {
                            Core.DelayAction(() => Items.Eye_of_the_Oasis.Cast(Path), Delay);
                            LastWard = Game.Time;
                        }
                        else if (Items.Eye_of_the_Watchers != null && Items.Eye_of_the_Watchers.IsOwned() && Items.Eye_of_the_Watchers.IsReady() && CanCastWard)
                        {
                            Core.DelayAction(() => Items.Eye_of_the_Watchers.Cast(Path), Delay);
                            LastWard = Game.Time;
                        }
                        else if (Items.Farsight_Alteration != null && Items.Farsight_Alteration.IsOwned() && Items.Farsight_Alteration.IsReady() && CanCastWard)
                        {
                            Core.DelayAction(() => Items.Vision_Ward.Cast(Path), Delay);
                            LastWard = Game.Time;
                        }
                        else if (Items.Warding_Totem != null && Items.Warding_Totem.IsOwned() && Items.Warding_Totem.IsReady() && CanCastWard)
                        {
                            Core.DelayAction(() => Items.Warding_Totem.Cast(Path), Delay);
                            LastWard = Game.Time;
                        }
                        else if (Items.Tracker_s_Knife != null && Items.Tracker_s_Knife.IsOwned() && Items.Tracker_s_Knife.IsReady() && CanCastWard)
                        {
                            Core.DelayAction(() => Items.Tracker_s_Knife.Cast(Path), Delay);
                            LastWard = Game.Time;
                        }
                        else if (Items.Tracker_s_Knife_Enchantment_Devourer != null && Items.Tracker_s_Knife_Enchantment_Devourer.IsOwned()
                            && Items.Tracker_s_Knife_Enchantment_Devourer.IsReady() && CanCastWard)
                        {
                            Core.DelayAction(() => Items.Tracker_s_Knife_Enchantment_Devourer.Cast(Path), Delay);
                            LastWard = Game.Time;
                        }
                        else if (Items.Tracker_s_Knife_Enchantment_Runic_Echoes != null && Items.Tracker_s_Knife_Enchantment_Runic_Echoes.IsOwned()
                            && Items.Tracker_s_Knife_Enchantment_Runic_Echoes.IsReady() && CanCastWard)
                        {
                            Core.DelayAction(() => Items.Tracker_s_Knife_Enchantment_Runic_Echoes.Cast(Path), Delay);
                            LastWard = Game.Time;
                        }
                        else if (Items.Tracker_s_Knife_Enchantment_Sated_Devourer != null && Items.Tracker_s_Knife_Enchantment_Sated_Devourer.IsOwned()
                            && Items.Tracker_s_Knife_Enchantment_Sated_Devourer.IsReady() && CanCastWard)
                        {
                            Core.DelayAction(() => Items.Tracker_s_Knife_Enchantment_Sated_Devourer.Cast(Path), Delay);
                            LastWard = Game.Time;
                        }
                        else if (Items.Tracker_s_Knife_Enchantment_Warrior != null && Items.Tracker_s_Knife_Enchantment_Warrior.IsOwned()
                            && Items.Tracker_s_Knife_Enchantment_Warrior.IsReady() && CanCastWard)
                        {
                            Core.DelayAction(() => Items.Tracker_s_Knife_Enchantment_Warrior.Cast(Path), Delay);
                            LastWard = Game.Time;
                        }
                        else if (Items.Tracker_s_Knifee_Enchantment_Cinderhulk != null && Items.Tracker_s_Knifee_Enchantment_Cinderhulk.IsOwned()
                            && Items.Tracker_s_Knifee_Enchantment_Cinderhulk.IsReady() && CanCastWard)
                        {
                            Core.DelayAction(() => Items.Tracker_s_Knifee_Enchantment_Cinderhulk.Cast(Path), Delay);
                            LastWard = Game.Time;
                        }
                        #endregion
                    }
                }
            }
        }
    }
}
