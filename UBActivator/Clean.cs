using System;
using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Events;
using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;
using System.Drawing;

namespace UBActivator
{
    class Clean
    {
        public static void OnBuffGain(Obj_AI_Base sender, Obj_AI_BaseBuffGainEventArgs args)
        {
            if (!sender.IsAlly) return;
            var Type = args.Buff.Type;
            var Duration = (args.Buff.EndTime - Game.Time) * 1000;
            var Noenemy = Config.Clean["EnemyManager"].Cast<CheckBox>().CurrentValue;
            var MinDurCC = Config.Clean["CCDelay"].Cast<Slider>().CurrentValue;
            //CC
            if ((Type == BuffType.Blind && Config.Clean["Blind"].Cast<CheckBox>().CurrentValue)
            || (Type == BuffType.Charm && Config.Clean["Charm"].Cast<CheckBox>().CurrentValue)
            || (Type == BuffType.Fear && Config.Clean["Fear"].Cast<CheckBox>().CurrentValue)
            || (Type == BuffType.NearSight && Config.Clean["Nearsight"].Cast<CheckBox>().CurrentValue)
            || (Type == BuffType.Polymorph && Config.Clean["Polymorph"].Cast<CheckBox>().CurrentValue)
            || (Type == BuffType.Taunt && Config.Clean["Taught"].Cast<CheckBox>().CurrentValue)
            || (Type == BuffType.Slow && Config.Clean["Slow"].Cast<CheckBox>().CurrentValue)
            || (Type == BuffType.Stun && Config.Clean["Stun"].Cast<CheckBox>().CurrentValue)
            || (Type == BuffType.Snare && Config.Clean["Snare"].Cast<CheckBox>().CurrentValue)
            || (Type == BuffType.Suppression && Config.Clean["Suppression"].Cast<CheckBox>().CurrentValue)
            || (Type == BuffType.Silence && Config.Clean["Silence"].Cast<CheckBox>().CurrentValue))
            {
                if (sender.IsMe)
                {
                    if (((Noenemy == false && ObjectManager.Player.CountEnemiesInRange(1500) > 0) || Noenemy == true) && Duration >= MinDurCC)
                    {
                        if (!Config.Clean["enableCleanse"].Cast<CheckBox>().CurrentValue) return;

                        if (Spells.Cleanse != null && Spells.Cleanse.IsReady())
                        {
                            Core.DelayAction(() => Spells.Cleanse.Cast(), Config.Clean["CCDelay"].Cast<Slider>().CurrentValue);
                        }
                        else if (!Config.Clean["enableQSS"].Cast<CheckBox>().CurrentValue) return;
                        else if (Items.Quicksilver_Sash.IsOwned() && Items.Quicksilver_Sash.IsReady())
                        {
                            Core.DelayAction(() => Items.Quicksilver_Sash.Cast(), Config.Clean["CCDelay"].Cast<Slider>().CurrentValue);
                        }

                        else if (Items.Mercurial_Scimitar.IsOwned() && Items.Mercurial_Scimitar.IsReady())
                        {
                            Core.DelayAction(() => Items.Mercurial_Scimitar.Cast(), Config.Clean["CCDelay"].Cast<Slider>().CurrentValue);
                        }
                        else return;
                    }
                }
                if (sender.IsAlly && !sender.IsMe)
                {
                    if (!Config.Clean["enableMikael"].Cast<CheckBox>().CurrentValue) return;
                    if (!Config.Clean["mikael" + sender.Name].Cast<CheckBox>().CurrentValue) return;
                    if (Items.Mikaels_Crucible.IsOwned() && Items.Mikaels_Crucible.IsReady())
                    {
                        Core.DelayAction(() => Items.Mikaels_Crucible.Cast(sender), Config.Clean["CCDelay"].Cast<Slider>().CurrentValue);
                    }
                }
            }
            else if (Type == BuffType.Knockup && Config.Clean["Airbone"].Cast<CheckBox>().CurrentValue)
            {
                if (((Noenemy == false && ObjectManager.Player.CountEnemiesInRange(1500) > 0) || Noenemy == true) && Duration >= MinDurCC)
                {
                    if (!Config.Clean["enableQSS"].Cast<CheckBox>().CurrentValue) return;

                    if (Items.Quicksilver_Sash.IsOwned() && Items.Quicksilver_Sash.IsReady())
                    {
                        Core.DelayAction(() => Items.Quicksilver_Sash.Cast(), Config.Clean["CCDelay"].Cast<Slider>().CurrentValue);
                    }

                    if (Items.Mercurial_Scimitar.IsOwned() && Items.Mercurial_Scimitar.IsReady())
                    {
                        Core.DelayAction(() => Items.Mercurial_Scimitar.Cast(), Config.Clean["CCDelay"].Cast<Slider>().CurrentValue);
                    }
                }
            }
        }
    }
}
