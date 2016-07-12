using System;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Menu.Values;

namespace UBActivator
{
    class Utility
    {
        public static int[] Level = { 0, 0, 0, 0 };
        public static void OnTick()
        {
            if (ObjectManager.Player.SkinId != Config.Utility["skin"].Cast<Slider>().CurrentValue)
            {
                if (Config.Utility["eskin"].Cast<CheckBox>().CurrentValue)
                {
                    Player.SetSkinId(Config.Utility["skin"].Cast<Slider>().CurrentValue);
                }
            }
        }
        public static void Game_OnTick()
        {
            var QLevel = Player.GetSpell(SpellSlot.Q).Level + Extensions.QOff;
            var WLevel = Player.GetSpell(SpellSlot.W).Level + Extensions.WOff;
            var ELevel = Player.GetSpell(SpellSlot.E).Level + Extensions.EOff;
            var RLevel = Player.GetSpell(SpellSlot.R).Level + Extensions.ROff;

            Level = new[] { 0, 0, 0, 0 };

            for (var i = 1; i <= ObjectManager.Player.Level; i++)
            {
                switch (Config.SkillOrder[i - 1])
                {
                    case 0:
                        break;
                    case 1:
                        Level[0] += 1;
                        break;
                    case 2:
                        Level[1] += 1;
                        break;
                    case 3:
                        Level[2] += 1;
                        break;
                    case 4:
                        Level[3] += 1;
                        break;
                }
            }

            if (QLevel < Level[0])
            {
                LevelUp(SpellSlot.Q);
            }

            if (WLevel < Level[1])
            {
                LevelUp(SpellSlot.W);
            }

            if (ELevel < Level[2])
            {
                LevelUp(SpellSlot.E);
            }

            if (RLevel < Level[3])
            {
                LevelUp(SpellSlot.R);
            }
        }
        public static void LevelUp(SpellSlot slot)
        {
            var Time = Config.Utility["lvldelay"].Cast<Slider>().CurrentValue;
            var Delay = Config.Utility["lvlrandom"].Cast<CheckBox>().CurrentValue ?
                new Random().Next(0, Time) :
                Time;
            if (Player.Instance.Spellbook.CanSpellBeUpgraded(slot))
            Core.DelayAction(() => Player.LevelSpell(slot), Delay);
        }
    }
}
