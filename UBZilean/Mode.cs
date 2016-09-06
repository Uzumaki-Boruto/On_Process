using System;
using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Enumerations;
using EloBuddy.SDK.Events;
using SharpDX;
using Modes = EloBuddy.SDK.Orbwalker.ActiveModes;

namespace UBZilean
{
    class Mode
    {
        #region Boolean
        public static void W_And_Cast(Obj_AI_Base target)
        {
            if (target != null && Spells.W.IsReady())
            {
                if (Spells.W.Cast())
                {
                    var pred = Spells.Q.GetPrediction(target);
                    Spells.Q.Cast(pred.CastPosition);
                }
            }
        }
        public static void W_And_Cast(Vector3 Vector)
        {
            if (Spells.W.Cast())
            {
                Spells.Q.Cast(Vector);
            }
        }
        #endregion

        #region Combo
        public static void Combo()
        {
            var Target = TargetSelector.GetTarget(Spells.Q.Range, DamageType.Magical);
            if (Config.ComboMenu.GetValue("Q", false) > 0 && Spells.Q.IsReady())
            {
                if (Config.ComboMenu.GetValue("Q", false) == 2)
                {
                    if (Extension.Superman != null)
                    {
                        var Count = Extension.Superman.First().CountEnemiesInRange(300);
                        if (Count > 1)
                        {
                            var pred = Spells.Q.GetPrediction(Extension.Superman.First());
                            Spells.Q.Cast(pred.CastPosition);
                        }
                    }
                    else if (Extension.Batman != null)
                    {
                        var pred = Spells.Q.GetPrediction(Extension.Batman.First());
                        Spells.Q.Cast(pred.CastPosition);
                    }
                    else
                    {
                        if (Target != null)
                        {
                            var pred = Spells.Q.GetPrediction(Target);
                            Spells.Q.Cast(pred.CastPosition);
                        }
                    }
                }
                if (Config.ComboMenu.GetValue("Q", false) == 1)
                {
                    if (Target != null)
                    {
                        var pred = Spells.Q.GetPrediction(Target);
                        Spells.Q.Cast(pred.CastPosition);
                    }
                }
            }
            if (Config.ComboMenu.Checked("W") && Spells.W.IsReady() && !Spells.Q.IsReady() && Extension.League_Of_Bomber != null)
            {
                W_And_Cast(Target);
            }
            if (Config.ESettings.GetValue("E", false) > 0 && Spells.E.IsReady())
            {
            }
        }
        #endregion

        #region AutoR
        public static void AutoR(EventArgs args)
        {
            if (Config.ComboMenu.Checked("R") && Spells.R.IsReady())
            {
                var Allies = EntityManager.Heroes.Allies.Where(x => !x.IsDead && x.IsValid && x.HealthPercent <= Config.ComboMenu.GetValue("HP" + x.ChampionName) && Spells.R.IsInRange(x)).OrderBy(x => x.Health);
                foreach (var Ally in Allies)
                {                  
                    if (Config.ComboMenu.Checked("R" + Ally.ChampionName))
                    {
                        Spells.R.Cast(Ally);
                    }
                }
                if (Config.ComboMenu.Checked("R" + Player.Instance.ChampionName))
                {
                    var prediction = Prediction.Health.GetPrediction(Player.Instance, 2000);
                    if (prediction <= 0)
                    {
                        Spells.R.Cast(Player.Instance);
                    }
                    if (Player.Instance.HealthPercent < Config.ComboMenu.GetValue("HP" + Player.Instance.ChampionName))
                    {
                        Spells.R.Cast(Player.Instance);
                    }
                }
            }
        }
        #endregion

        #region Harass
        public static void Harass()
        {
            if (Config.HarassMenu.GetValue("hr") > Player.Instance.ManaPercent) return;
            var Target = TargetSelector.GetTarget(Spells.Q.Range, DamageType.Magical);
            if (Config.HarassMenu.GetValue("Q", false) > 0 && Spells.Q.IsReady())
            {
                if (Config.HarassMenu.GetValue("Q", false) == 2)
                {
                    if (Extension.Superman != null)
                    {
                        var Count = Extension.Superman.First().CountEnemiesInRange(300);
                        if (Count > 1)
                        {
                            var pred = Spells.Q.GetPrediction(Extension.Superman.First());
                            Spells.Q.Cast(pred.CastPosition);
                        }
                    }
                    else if (Extension.Batman != null)
                    {
                        var pred = Spells.Q.GetPrediction(Extension.Batman.First());
                        Spells.Q.Cast(pred.CastPosition);
                    }
                    else
                    {
                        if (Target != null)
                        {
                            var pred = Spells.Q.GetPrediction(Target);
                            Spells.Q.Cast(pred.CastPosition);
                        }
                    }
                }
                if (Config.HarassMenu.GetValue("Q", false) == 1)
                {
                    if (Target != null)
                    {
                        var pred = Spells.Q.GetPrediction(Target);
                        Spells.Q.Cast(pred.CastPosition);
                    }
                }
            }
            if (Config.HarassMenu.Checked("W") && Spells.W.IsReady() && !Spells.Q.IsReady() && Extension.Batman != null)
            {
                Spells.W.Cast();
            }
        }
        #endregion

        #region LaneClear
        public static void LaneClear()
        {
            if (Config.LaneClear.GetValue("lc") > Player.Instance.ManaPercent) return;
            var WorstPos = EntityManager.MinionsAndMonsters.GetCircularFarmLocation(EntityManager.MinionsAndMonsters.GetLaneMinions(), 300, (int)Spells.Q.Range);
            if (WorstPos.HitNumber >= Config.LaneClear.GetValue("Qhit"))
            {
                if (Config.LaneClear.Checked("Q") && Spells.Q.IsReady())
                {
                    Spells.Q.Cast(WorstPos.CastPosition);
                }
                if (Config.LaneClear.Checked("W") && Spells.W.IsReady() && !Spells.Q.IsReady())
                {
                    Spells.W.Cast();
                }
            }
        }
        #endregion

        #region JungleClear
        public static void JungleClear()
        {
            if (Config.JungleClear.GetValue("jc") > Player.Instance.ManaPercent) return;
            var monster = ObjectManager.Get<Obj_AI_Minion>().Where(x => x.IsMonster && x.IsValidTarget(Spells.Q.Range)).OrderBy(x => x.MaxHealth).LastOrDefault();
            if (monster == null || !monster.IsValid) return;
            if (Config.JungleClear.Checked("Q") && Spells.Q.IsReady())
            {
                if (Orbwalker.IsAutoAttacking) return;
                Orbwalker.ForcedTarget = null;
                Spells.Q.Cast(monster);
            }
            if (Config.JungleClear.Checked("W") && Spells.W.IsReady() && !Spells.Q.IsReady())
            {
                if (monster != null)
                {
                    Spells.W.Cast();
                }
            }
        }
        #endregion

        #region Killsteal
        public static void Killsteal(EventArgs args)
        {
            var target = TargetSelector.GetTarget(EntityManager.Heroes.Enemies.Where(t => t != null
                && t.IsValidTarget()
                && Spells.Q.IsInRange(t)
                && t.Health <= Damages.QDamage(t)), DamageType.Physical);

            if (target != null && !target.Unkillable())
            {
                if (Spells.Q.IsReady() && Config.MiscMenu.Checked("Qks"))
                {
                    var pred = Spells.Q.GetPrediction(target);
                    Spells.Q.Cast(pred.CastPosition);
                }
                if (Spells.W.IsReady() && !Spells.Q.IsReady() && Config.MiscMenu.Checked("Wks"))
                {
                    Spells.W.Cast();
                }

            }
        }
    
        #endregion

        #region AutoHarass
        public static void AutoHarass(EventArgs args)
        {
            if (Player.Instance.ManaPercent < Config.HarassMenu.GetValue("autohrmng")) return;
            if (!Config.HarassMenu.Checked("keyharass", false)) return;
            if (Player.Instance.IsUnderEnemyturret()) return;
            if (Modes.Combo.IsActive() || Modes.Harass.IsActive() || Modes.Flee.IsActive()) return;
            var Target = TargetSelector.GetTarget(Spells.Q.Range, DamageType.Magical);
            if (Config.HarassMenu.GetValue("Q", false) > 0 && Spells.Q.IsReady())
            {
                var QBuffTar = EntityManager.Heroes.Enemies.Where(x => Spells.Q.IsInRange(x) && x.HasQBuff()).FirstOrDefault();
                if (QBuffTar != null)
                {
                    var pred = Spells.Q.GetPrediction(QBuffTar);
                    Spells.Q.Cast(pred.CastPosition);
                }
                else
                {
                    if (Target != null)
                    {
                        var pred = Spells.Q.GetPrediction(Target);
                        Spells.Q.Cast(pred.CastPosition);
                    }
                }
            }
            if (Config.HarassMenu.Checked("W") && Spells.W.IsReady() && !Spells.Q.IsReady() && Extension.Batman != null)
            {
                Spells.W.Cast();
            }
        }
        #endregion

        #region Interrupter
        public static void Interrupter_OnInterruptableSpell(Obj_AI_Base sender, Interrupter.InterruptableSpellEventArgs e)
        {
            var Value = Config.MiscMenu.GetValue("value", false);
            var Danger = Value == 0 ? DangerLevel.High : Value == 1 ? DangerLevel.Medium : Value == 2 ? DangerLevel.Low : DangerLevel.High;
            if (sender.IsEnemy
                && Config.MiscMenu.Checked("inter")
                && sender.IsValidTarget(Spells.Q.Range)
                && e.DangerLevel == Danger)
            {
                if (Spells.Q.IsReady())
                {
                    Spells.Q.Cast(sender.Position);
                }
                else
                {
                    if (Spells.W.IsReady() && !Spells.Q.IsReady())
                    {
                        Spells.W.Cast();
                    }
                }
            }
        }
        #endregion

        #region Gapcloser
        public static void Gapcloser_OnGapcloser(AIHeroClient sender, Gapcloser.GapcloserEventArgs args)
        {
            switch (sender.IsEnemy)
            {
                case true:
                    {
                        switch (args.Type)
                        {
                            case Gapcloser.GapcloserType.Skillshot:
                                {
                                    var Ally = EntityManager.Heroes.Allies.Where(x => !x.IsDead && Spells.Q.IsInRange(x)).OrderBy(x => x.Distance(args.End)).First();
                                    if (sender.IsAttackingPlayer || Ally.Distance(args.End) < 175 || args.End.IsInRange(Player.Instance, Spells.Q.Range))
                                    //if (args.Sender.Spellbook.CastEndTime
                                    //(sender.IsAttackingPlayer || Player.Instance.Distance(args.End) < 100 || args.End.IsInRange(Player.Instance, Spells.R.Range))
                                    {
                                        Spells.Q.Cast(args.End);
                                        W_And_Cast(args.End);
                                    }

                                }
                                break;
                            case Gapcloser.GapcloserType.Targeted:
                                {
                                    var target = args.Target as AIHeroClient;
                                    if (target != null && Spells.Q.IsInRange(target) && Config.GapCloser.Checked("anti" + target.ChampionName))
                                    {
                                        if (Spells.Q.IsReady())
                                        {
                                            Spells.Q.Cast(target);
                                            W_And_Cast(target);
                                        }
                                        if (Spells.E.IsReady())
                                        {
                                            switch (Config.GapCloser.GetValue("E", false))
                                            {
                                                case 1:
                                                    {
                                                        var Ally = EntityManager.Heroes.Allies.Where(x => !x.IsDead && Spells.E.IsInRange(x)).OrderBy(x => x.Distance(args.End)).First();
                                                        if (sender.IsAttackingPlayer || Ally.Distance(args.End) < 175 || args.End.IsInRange(Player.Instance, Spells.E.Range))
                                                        {
                                                            if (sender.IsValid && Spells.E.IsInRange(sender))
                                                            {
                                                                Spells.E.Cast(sender);
                                                            }
                                                        }
                                                    }
                                                    break;
                                                case 2:
                                                    {
                                                        var Ally = EntityManager.Heroes.Allies.Where(x => !x.IsDead && Spells.E.IsInRange(x)).OrderBy(x => x.Distance(args.End)).First();
                                                        if (sender.IsAttackingPlayer || Ally.Distance(args.End) < 175 || args.End.IsInRange(Player.Instance, Spells.E.Range))
                                                        {
                                                            if (Ally.IsValid && Spells.E.IsInRange(Ally))
                                                            {
                                                                Spells.E.Cast(Ally);
                                                            }
                                                        }

                                                    }
                                                    break;
                                                case 3:
                                                    {
                                                        var Ally = EntityManager.Heroes.Allies.Where(x => !x.IsDead && Spells.E.IsInRange(x)).OrderBy(x => x.Distance(args.End)).First();
                                                        if (Ally.CountAlliesInRange(1000) > sender.CountEnemiesInRange(1000))
                                                        {
                                                            if (sender.IsValid())
                                                            {
                                                                Spells.E.Cast(sender);
                                                            }
                                                        }
                                                        else
                                                        {
                                                            if (sender.IsValid())
                                                            {
                                                                Spells.E.Cast(Ally);
                                                            }
                                                        }
                                                    }
                                                    break;
                                            }
                                        }
                                    }
                                }
                                break;
                        }
                    }
                    break;
                case false:
                    {
                        if (args.Type == Gapcloser.GapcloserType.Targeted)
                        {
                            var target = args.Target as AIHeroClient;
                            if (target != null && Spells.Q.IsInRange(args.End) && Config.GapCloser.Checked("gap" + args.Sender.ChampionName + args.Slot))
                            {
                                if (Spells.Q.IsReady() && Config.ComboMenu.GetValue("Q", false) == 2)
                                {
                                    Spells.Q.Cast(target);
                                    W_And_Cast(target);
                                }
                                if (Spells.E.IsReady() && Config.GapCloser.Checked("gapE"))
                                {

                                    var Ally = EntityManager.Heroes.Allies.Where(x => !x.IsDead && Spells.E.IsInRange(x)).OrderBy(x => x.Distance(args.End)).First();
                                    if (sender.IsAttackingPlayer || Ally.Distance(args.End) < 175 || args.End.IsInRange(Player.Instance, Spells.E.Range))
                                    {
                                        if (Ally.IsValid && Spells.E.IsInRange(Ally))
                                        {
                                            Spells.E.Cast(Ally);
                                        }
                                    }
                                }
                            }
                        }
                    }
                    break;
            }
        }
        #endregion

    }
}
