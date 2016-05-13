using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Enumerations;
using EloBuddy.SDK.Menu.Values;
using EloBuddy.SDK.Events;

namespace UBAzir
{
    class Event
    {
        public static bool Unkillable(AIHeroClient target)
        {
            if (target.Buffs.Any(b => b.IsValid() && b.DisplayName == "UndyingRage"))
            {
                return true;
            }
            if (target.Buffs.Any(b => b.IsValid() && b.DisplayName == "ChronoShift"))
            {
                return true;
            }
            if (target.Buffs.Any(b => b.IsValid() && b.DisplayName == "JudicatorIntervention"))
            {
                return true;
            }
            if (target.Buffs.Any(b => b.IsValid() && b.DisplayName == "kindredrnodeathbuff"))
            {
                return true;
            }
            if (target.HasBuffOfType(BuffType.Invulnerability))
            {
                return true;
            }
            return target.IsInvulnerable;
        }
        public static bool HasSpellShield(AIHeroClient target)
        {
            if (target.Buffs.Any(b => b.IsValid() && b.DisplayName == "bansheesveil"))
            {
                return true;
            }
            if (target.Buffs.Any(b => b.IsValid() && b.DisplayName == "SivirE"))
            {
                return true;
            }
            if (target.Buffs.Any(b => b.IsValid() && b.DisplayName == "NocturneW"))
            {
                return true;
            }
            return target.HasBuffOfType(BuffType.SpellShield) || target.HasBuffOfType(BuffType.SpellImmunity);
        }
        private static void Interrupter_OnInterruptableSpell(Obj_AI_Base sender, Interrupter.InterruptableSpellEventArgs e)
        {
            var Value = Config.MiscMenu["interrupt.value"].Cast<ComboBox>().CurrentValue;
            var Danger = Value == 0 ? DangerLevel.High : Value == 1 ? DangerLevel.Medium : Value == 2 ? DangerLevel.Low : DangerLevel.High;
            if (sender.IsEnemy 
                && Config.MiscMenu["interrupter"].Cast<CheckBox>().CurrentValue
                && sender.IsValidTarget(Spells.R.Range - 20) 
                && e.DangerLevel == Danger)
            {
                SpecialVector.WhereCastR(sender, SpecialVector.I_want.All);
            }
        }
        public void OnGapCloser(AIHeroClient sender, Gapcloser.GapcloserEventArgs e)
        {
            if (Spells.R.IsReady() 
                && !sender.IsMe
                && (sender.IsAttackingPlayer || Player.Instance.Distance(e.End) < 70) 
                && Config.MiscMenu["gap"].Cast<CheckBox>().CurrentValue
                && Config.MiscMenu["gap" + sender.ChampionName].Cast<CheckBox>().CurrentValue)
            {
                switch (Config.MiscMenu["gap.1"].Cast<ComboBox>().CurrentValue)
                {
                    case 0:
                        {
                            if (e.Type == Gapcloser.GapcloserType.Targeted)
                            {
                                SpecialVector.WhereCastR(sender, SpecialVector.I_want.All);
                            }
                            else return;
                        }
                        break;
                    case 1:
                        {
                            SpecialVector.WhereCastR(sender, SpecialVector.I_want.All);
                        }
                        break;
                }
            }
        }
    }
}
