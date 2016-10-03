using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Enumerations;
using EloBuddy.SDK.Events;
using EloBuddy.SDK.Menu;
using System;
using System.Linq;

namespace UBBard
{
    class Mode
    {
        #region Combo
        public static void Combo()
        {
            if (Config.ComboMenu.Checked("Q") && Spells.Q.IsReady())
            {
                var Target = TargetSelector.GetTarget(Spells.Q.Range, DamageType.Magical);
                if (Target != null && Target.IsValid())
                {
                    var pred = Spells.Q.GetPrediction(Target);
                    if (!Config.ComboMenu.Checked("Qstun") || pred.WillStun())
                    {
                        Spells.Q.Cast(pred.CastPosition);
                    }
                }
            }
            if (Config.ComboMenu.Checked("R") && Spells.R.IsReady())
            {
                Spells.R.CastIfItWillHit(Config.ComboMenu.GetValue("Rhit"), Config.ComboMenu.GetValue("Rhitchance"));
            }
        }
        #endregion 

        #region Harass
        public static void Harass()
        {
            if (Config.HarassMenu.Checked("Q") && Spells.Q.IsReady())
            {
                var Target = TargetSelector.GetTarget(Spells.Q.Range, DamageType.Magical);
                if (Target != null && Target.IsValid())
                {
                    var pred = Spells.Q.GetPrediction(Target);
                    if (!Config.HarassMenu.Checked("Qstun") || pred.WillStun())
                    {
                        Spells.Q.Cast(pred.CastPosition);
                    }
                }
            }
        }
        #endregion 

        #region Clear
        public static void LaneClear()
        {
            if (Player.Instance.ManaPercent < Config.Clear.GetValue("lc")) return;
            if (Config.Clear.Checked("Q") && Spells.Q.IsReady())
            {
                var minion = EntityManager.MinionsAndMonsters.GetLaneMinions(EntityManager.UnitTeam.Enemy, Player.Instance.Position, Spells.Q.Range);
                if (minion != null)
                {
                    Spells.Q.Cast(minion.First());
                }
            }
        }
        public static void JungleClear()
        {
            if (Player.Instance.ManaPercent < Config.Clear.GetValue("jc")) return;
            if (Config.Clear.Checked("Qjc") && Spells.Q.IsReady())
            {
                var monster = EntityManager.MinionsAndMonsters.GetJungleMonsters(Player.Instance.Position, Spells.Q.Range).OrderByDescending(x => x.MaxHealth);
                if (monster != null)
                {
                    Spells.Q.Cast(monster.First());
                }
            }
        }
        #endregion 

        #region AutoW
        public static void AutoW(EventArgs args)
        {
            if (!Spells.W.IsReady() || Player.Instance.IsRecalling() || !Config.AutoHeal.Checked("W"))
            {
                return;
            }
            var Allies = EntityManager.Heroes.Allies.Where(x => x.IsValid && !x.IsDead && Spells.W.IsInRange(x) && x.HealthPercent <= Config.AutoHeal.GetValue("HP"));
            AIHeroClient OderedAlly = new AIHeroClient();
            switch (Config.AutoHeal.GetValue("Worder", false))
            {
                case 0:
                    {
                        OderedAlly = Allies.OrderByDescending(x => x.TotalMagicalDamage).First();
                    }
                    break;
                case 1:
                    {
                        OderedAlly = Allies.OrderByDescending(x => x.TotalAttackDamage).First();
                    }
                    break;
                case 2:
                    {
                        OderedAlly = Allies.OrderBy(x => x.Health).First();
                    }
                    break;
            }
            if (OderedAlly != null)
            {
                Spells.W.Cast(OderedAlly);
            }
        }
        #endregion 

        #region KillSteal
        public static void Killsteal(EventArgs args)
        {
            if (Spells.Q.IsReady() && Config.MiscMenu.Checked("Qks"))
            {
                var target = TargetSelector.GetTarget(EntityManager.Heroes.Enemies.Where(t => t != null
                    && t.IsValidTarget()
                    && Spells.Q.IsInRange(t)
                    && t.Health <= Damage.QDamage(t)), DamageType.Magical);

                if (target != null && !target.Unkillable())
                {
                    var pred = Spells.Q.GetPrediction(target);
                    {
                        Spells.Q.Cast(pred.CastPosition);
                    }
                }
            }
        }
        #endregion 

        #region AutoHarass
        public static void AutoHarass(EventArgs args)
        {
            if (Player.Instance.ManaPercent < Config.HarassMenu.GetValue("autohrmng")) return;
            if (!Config.HarassMenu.Checked("keyharass", false)) return;
            if (Config.HarassMenu.Checked("Q") && Spells.Q.IsReady())
            {
                var Target = TargetSelector.GetTarget(Spells.Q.Range, DamageType.Magical);
                if (Target != null && Target.IsValid())
                {
                    var pred = Spells.Q.GetPrediction(Target);
                    if (!Config.HarassMenu.Checked("Qstun") || pred.WillStun())
                    {
                        Spells.Q.Cast(pred.CastPosition);
                    }
                }
            }
        }
        #endregion 

        #region Interrupt
        public static void Interrupter_OnInterruptableSpell(Obj_AI_Base sender, Interrupter.InterruptableSpellEventArgs e)
        {
            var Value = Config.MiscMenu.GetValue("interrupt.level", false);
            var Danger = Value == 2 ? DangerLevel.High : Value == 1 ? DangerLevel.Medium : Value == 0 ? DangerLevel.Low : DangerLevel.High;
            if (sender != null
                && sender.IsEnemy
                && Config.MiscMenu.Checked("interrupt")
                && sender.IsValidTarget(Spells.Q.Range)
                && e.DangerLevel == Danger
                && Spells.Q.IsReady())
            {
                var pred = Spells.Q.GetPrediction(sender);
                if (pred.WillStun())
                {
                    Spells.Q.Cast(pred.CastPosition);
                }
            }
        }
        #endregion

        #region Gapcloser
        public static void Gapcloser_OnGapcloser(AIHeroClient sender, Gapcloser.GapcloserEventArgs args)
        {
            if (sender != null
                && sender.IsEnemy
                && sender.IsValid
                && (sender.IsAttackingPlayer || Player.Instance.Distance(args.End) < 225 || args.End.IsInRange(Player.Instance, Spells.Q.Range))
                && (sender.Spellbook.CastEndTime - Game.Time) * 1000 <= Spells.Q.CastDelay)
            {
                if (sender.WillStun() && Spells.Q.IsReady())
                {
                    if (Config.MiscMenu.Checked("Qgap"))
                        Spells.Q.Cast(args.End);
                }
                else
                {
                    var Ally = EntityManager.Heroes.Allies.Where(x => !x.IsDead && Spells.W.IsInRange(x)).OrderBy(x => x.Distance(args.End)).First();
                    if (Ally.Distance(args.End) < 225)
                        Spells.W.Cast(Ally);
                }
            }
        }
        #endregion

    }
}
