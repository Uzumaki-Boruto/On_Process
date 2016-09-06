﻿using System;
using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Events;
using EloBuddy.SDK.Enumerations;
using SharpDX;

namespace UBVeigar
{
    class Mode
    {
        #region Combo
        public static void Combo()
        {
            if (Config.ComboMenu.Checked("Qcb"))
            {
                var Target = TargetSelector.GetTarget(Spells.Q.Range, DamageType.Magical);
                if (Target != null)
                {
                    var pred = Spells.Q.GetPrediction(Target);
                    if (Spells.Q.IsReady())
                    {
                        Spells.Q.Cast(pred.CastPosition);
                    }
                }
            }
            if (Config.ComboMenu.Checked("Wcb"))
            {
                var Target = TargetSelector.GetTarget(Spells.W.Range, DamageType.Magical);
                if (Target != null && ((Config.ComboMenu.Checked("W.cc") && Target.Immobilize()) || !Config.ComboMenu.Checked("W.cc")))
                {
                    var pred = Spells.W.GetPrediction(Target);
                    if (Spells.W.IsReady())
                    {
                        Spells.W.Cast(pred.CastPosition);
                    }
                }
            }
            if (Config.ComboMenu.Checked("Ecb"))
            {
                var Target = TargetSelector.GetTarget(Spells.E.Range + Spells.E.Radius, DamageType.Mixed);
                var Enemies = EntityManager.Heroes.Enemies.Where(x => x.Distance(Player.Instance) <= 1600);
                if (Enemies.Count() == 1 && Target != null)
                {
                    Spells.ECast(Target);
                }
                else if (Enemies.Count() >= Config.ComboMenu.GetValue("Ebox"))
                {
                    Spells.E.CastIfItWillHit(Config.ComboMenu.GetValue("Ebox"));
                }
            }
        }
        #endregion

        #region Harass
        public static void Harass()
        {
            if (Player.Instance.ManaPercent <= Config.HarassMenu.GetValue("hr")) return;
            if (Config.HarassMenu.Checked("Qhr"))
            {
                var Target = TargetSelector.GetTarget(Spells.Q.Range, DamageType.Magical);
                if (Target != null)
                {
                    var pred = Spells.Q.GetPrediction(Target);
                    if (Spells.Q.IsReady())
                    {
                        Spells.Q.Cast(pred.CastPosition);
                    }
                }
            }
            if (Config.HarassMenu.Checked("Whr"))
            {
                var Target = TargetSelector.GetTarget(Spells.W.Range, DamageType.Magical);
                if (Target != null && ((Config.HarassMenu.Checked("Whr.cc") && Target.Immobilize()) || !Config.HarassMenu.Checked("Whr.cc")))
                {
                    var pred = Spells.W.GetPrediction(Target);
                    if (Spells.W.IsReady())
                    {
                        Spells.W.Cast(pred.CastPosition);
                    }
                }
            }
            if (Config.HarassMenu.Checked("Ehr"))
            {
                var Target = TargetSelector.GetTarget(Spells.E.Range + Spells.E.Radius, DamageType.Mixed);
                if (Target != null)
                {
                    Spells.ECast(Target);
                }
            }
        }
        #endregion

        #region Laneclear
        public static void LaneClear()
        {
            if (Config.LaneClear.Checked("Qlc"))
            {
                if (Spells.Q.IsReady())
                {
                    var minions = EntityManager.MinionsAndMonsters.EnemyMinions.Where(m => m.IsValidTarget(Spells.Q.Range) && m.Health <= Damage.QDamage(m)).ToArray();
                    var MinionLeastHP = EntityManager.MinionsAndMonsters.EnemyMinions.Where(m => m.IsValidTarget(Spells.Q.Range)).OrderBy(m => m.HealthPercent).FirstOrDefault();
                    var LCMinion = Orbwalker.LaneClearMinionsList.ToArray();
                    var allyminion = EntityManager.MinionsAndMonsters.GetLaneMinions(EntityManager.UnitTeam.Ally);
                    var value = Config.LaneClear.GetValue("Q.waittime") * Player.Instance.GetAutoAttackDamage(Orbwalker.LaneClearMinion);
                    if (minions.Any())
                    {
                        //if (Orbwalker.LaneClearMinion.Health <= Damage.QDamage(Orbwalker.LaneClearMinion) + value && Config.LaneClear.Checked("Q.wait"))
                        //{
                        //    Orbwalker.ForcedTarget = Orbwalker.LaneClearMinionsList.Where(m => m.IsValid
                        //        && m.Health >= Orbwalker.LaneClearMinion.Health && m != Orbwalker.LaneClearMinion).OrderBy(m => m.Distance(Orbwalker.LaneClearMinion)).FirstOrDefault();
                        //}
                        switch (minions.Count())
                        {
                            case 0:
                                {
                                    Orbwalker.ForcedTarget = LCMinion.Where(m => m.IsValid && m.HealthPercent >= MinionLeastHP.HealthPercent && m != MinionLeastHP).OrderBy(m => m.Distance(MinionLeastHP)).FirstOrDefault();
                                }
                                break;
                            case 1:
                                {
                                    if (allyminion != null)
                                    {
                                        if (!Extension.ShouldWait)
                                        {
                                            Spells.Q.Cast(minions.First());
                                        }
                                        else
                                        {
                                            if (Orbwalker.PriorityLastHitWaitingMinion != null)
                                            {
                                                Orbwalker.ForcedTarget = LCMinion.Where(m => m.IsValid && m.Health >= Orbwalker.PriorityLastHitWaitingMinion.Health && m != Orbwalker.LaneClearMinion).OrderBy(m => m.Distance(Orbwalker.PriorityLastHitWaitingMinion)).FirstOrDefault();
                                            }
                                            else
                                            {
                                                Orbwalker.ForcedTarget = LCMinion.Where(m => m.IsValid && m.Health >= minions.First().Health && m != minions.First()).OrderBy(m => m.Distance(minions.First())).FirstOrDefault();
                                            }
                                        }
                                    }
                                    else
                                    {
                                        Orbwalker.ForcedTarget = LCMinion.Where(m => m.IsValid && m.Health > Damage.QDamage(m) && m != minions.First()).OrderBy(m => m.Distance(minions.First())).FirstOrDefault();
                                    }
                                }
                                break;
                            default:
                                {
                                    var Result = minions.Where(x => x != minions[0]).OrderBy(x => x.Distance(minions[0])).FirstOrDefault();
                                    var Rectangle1 = new Geometry.Polygon.Rectangle(minions[0].Position, Result.Position, 10f);
                                    var Rectangle2 = new Geometry.Polygon.Rectangle(Player.Instance.Position, Rectangle1.CenterOfPolygon().To3D(), Spells.Q.Width);
                                    if (Rectangle2.IsInside(Result) && Rectangle2.IsInside(minions[0]))
                                    {
                                        Spells.Q.Cast(Rectangle2.End.To3D());
                                    }
                                    //if (!QMinions.Any()) return;

                                    //var predictionResult =
                                    //    (from minion in QMinions
                                    //     let pred = Spells.Q.GetPrediction(minion)
                                    //     let count = pred.GetCollisionObjects<Obj_AI_Minion>().Count(x =>
                                    //                    x.Health <= Damage.QDamage(x)
                                    //                    && x.IsValidTarget() && x.IsEnemy)
                                    //     where count >= 2
                                    //     select pred).FirstOrDefault();
                                    //if (Spells.Q.IsReady() && predictionResult != null)
                                    //{
                                    //    Spells.Q.Cast(predictionResult.CastPosition);
                                    //}
                                }
                                break;
                        }
                    }
                }
                else
                {
                    if (Orbwalker.PriorityLastHitWaitingMinion != null)
                    {
                        uint time = 0;
                        for (uint i = 0; i < 3000; i += 100)
                        {
                            var Pred = Prediction.Health.GetPrediction(Orbwalker.PriorityLastHitWaitingMinion, (int)i);
                            if (Pred <= 0)
                            {
                                time = i - 100;
                                break;
                            }
                        }
                        if (Spells.Q.IsReady(time))
                        {
                            Orbwalker.ForcedTarget = Orbwalker.LaneClearMinion;
                        }
                        else
                        {
                            Orbwalker.ForcedTarget = null;
                        }
                    }
                }
            }
            if (Config.LaneClear.Checked("Wlc") && Spells.W.IsReady() && Player.Instance.ManaPercent >= Config.LaneClear.GetValue("lc"))
            {
                var minion = EntityManager.MinionsAndMonsters.GetLaneMinions(EntityManager.UnitTeam.Enemy);
                var Farm = EntityManager.MinionsAndMonsters.GetCircularFarmLocation(minion, Spells.E.Width, (int)Spells.E.Range);
                {
                    if (Farm.HitNumber >= Config.LaneClear.GetValue("Whitlc"))
                    {
                        Spells.W.Cast(Farm.CastPosition);
                    }
                }
            }
        }
        public static void Get_AP(EventArgs args)
        {
            if (Spells.Q.IsReady() && Config.LaneClear.Checked("Q.farm"))
            {
                var Target = TargetSelector.GetTarget(Spells.Q.Range, DamageType.Magical);
                if (Target != null)
                {
                    var prediction = Spells.Q.GetPrediction(Target);
                    var coll = prediction.CollisionObjects;
                    if (coll.Count() == 1)
                    {
                        if (coll.Count(x => x.Health <= Damage.QDamage(x)) == 1)
                        {
                            Spells.Q.Cast(prediction.CastPosition);
                        }
                    }
                }
                var minions = EntityManager.MinionsAndMonsters.GetLaneMinions(EntityManager.UnitTeam.Enemy, Player.Instance.Position, Spells.Q.Range).ToArray();
                var QMinions = minions.Where(x => x.Health <= Damage.QDamage(x)).ToArray();
                if (!QMinions.Any()) return;

                var predictionResult =
                    (from minion in QMinions
                     let pred = Spells.Q.GetPrediction(minion)
                     let count = pred.GetCollisionObjects<Obj_AI_Minion>().Count(x =>
                                    x.Health <= Damage.QDamage(x)
                                    && x.IsValidTarget() && x.IsEnemy)
                     where count >= 2
                     select pred).FirstOrDefault();
                if (Spells.Q.IsReady() && predictionResult != null)
                {
                    Spells.Q.Cast(predictionResult.CastPosition);
                }
            }
        }
        #endregion

        #region Jungleclear
        public static void JungleClear()
        {
            if (Config.JungleClear.GetValue("jc") > Player.Instance.ManaPercent) return;
            if (Config.JungleClear.Checked("Qjc"))
            {
                var monster = ObjectManager.Get<Obj_AI_Minion>().Where(x => x.IsMonster && x.IsValidTarget(Spells.Q.Range)).OrderBy(x => x.MaxHealth).LastOrDefault(x => x.Health <= Damage.QDamage(x));
                if (monster != null)
                {
                    if (monster.Health > Damage.QDamage(monster) * 1.5f)
                    {
                        Spells.Q.Cast(monster);
                    }
                    else
                    {
                        if (monster.Health < Damage.QDamage(monster))
                        {
                            Spells.Q.Cast(monster);
                        }
                    }
                }
            }
            if (Config.JungleClear.Checked("Wjc"))
            {
                var monster = ObjectManager.Get<Obj_AI_Minion>().Where(x => x.IsMonster && x.IsValidTarget(Spells.W.Range)).OrderBy(x => x.MaxHealth).LastOrDefault(x => x.Health <= Damage.QDamage(x));
                if (monster != null)
                {
                    if (monster.Health > Damage.QDamage(monster) * 1.5f)
                    {
                        Spells.W.Cast(monster);
                    }
                }
            }
        }

        public static void JungSteal(EventArgs args)
        {
            if (Spells.Q.IsReady() && Config.JungleClear.Checked("Qjs"))
            {
                var monster = ObjectManager.Get<Obj_AI_Minion>().Where(x => x.IsMonster && x.IsValidTarget(Spells.Q.Range)).OrderBy(x => x.MaxHealth).LastOrDefault();
                if (monster != null && monster.Health <= Damage.QDamage(monster))
                {
                    Spells.Q.Cast(monster);
                }
            }
        }
        #endregion

        #region On_Unkillable_Minion
        public static void On_Unkillable_Minion(Obj_AI_Base unit, Orbwalker.UnkillableMinionArgs args)
        {
            if (unit == null
                || Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Combo)) return;
            if (args.RemainingHealth <= Damage.QDamage(unit) && Spells.Q.IsReady() && Config.LaneClear.Checked("Q.unkill"))
            {
                Spells.Q.Cast(unit);
            }           
        }
        #endregion

        #region AutoHarass
        public static void AutoHarass(EventArgs args)
        {
            if (Player.Instance.ManaPercent <= Config.HarassMenu.GetValue("autohrmng")) return;
            if (!Config.HarassMenu.Checked("keyharass", false)) return;
            if (Config.HarassMenu.Checked("Qhr"))
            {
                var Target = TargetSelector.GetTarget(Spells.Q.Range, DamageType.Magical);
                if (Target != null)
                {
                    var pred = Spells.Q.GetPrediction(Target);
                    if (Spells.Q.IsReady())
                    {
                        Spells.Q.Cast(pred.CastPosition);
                    }
                }
            }
            if (Config.HarassMenu.Checked("Whr"))
            {
                var Target = TargetSelector.GetTarget(Spells.W.Range, DamageType.Magical);
                if (Target != null && ((Config.HarassMenu.Checked("Whr.cc") && Target.Immobilize()) || !Config.HarassMenu.Checked("Whr.cc")))
                {
                    var pred = Spells.W.GetPrediction(Target);
                    if (Spells.W.IsReady())
                    {
                        Spells.W.Cast(pred.CastPosition);
                    }
                }
            }
            if (Config.HarassMenu.Checked("Ehr"))
            {
                var Target = TargetSelector.GetTarget(Spells.E.Range + Spells.E.Radius, DamageType.Mixed);
                if (Target != null)
                {
                    Spells.ECast(Target);
                }
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
            if (Spells.W.IsReady() && Config.MiscMenu.Checked("Wks"))
            {
                var target = TargetSelector.GetTarget(EntityManager.Heroes.Enemies.Where(t => t != null
                    && t.IsValidTarget()
                    && Spells.W.IsInRange(t)
                    && t.Health <= Damage.QDamage(t)), DamageType.Magical);

                if (target != null && !target.Unkillable())
                {
                    var pred = Spells.W.GetPrediction(target);
                    {
                        Spells.W.Cast(pred.CastPosition);
                    }
                }
            }
            if (Spells.R.IsReady() && Config.MiscMenu.Checked("Rks"))
            {
                var target = TargetSelector.GetTarget(EntityManager.Heroes.Enemies.Where(t => t != null
                    && t.IsValidTarget()
                    && Spells.R.IsInRange(t)
                    && t.Health <= Damage.RDamage(t)
                    && !t.Unkillable()
                    && !t.HasSpellShield()), DamageType.Magical);

                if (target != null && Config.MiscMenu.Checked(target.ChampionName))
                {
                    Spells.R.Cast(target);
                }
            }
        }
        #endregion

        #region Gapcloser
        public static void Gapcloser_OnGapcloser(AIHeroClient sender, Gapcloser.GapcloserEventArgs args)
        {
            if (Spells.E.IsReady()
                && sender != null
                && sender.IsEnemy
                && sender.IsValid
                && (sender.IsAttackingPlayer || Player.Instance.Distance(args.End) < 200 || args.End.IsInRange(Player.Instance, Spells.E.Range))
                && (sender.Spellbook.CastEndTime - Game.Time) * 1000 <= Spells.E.CastDelay
                && Config.MiscMenu.Checked("gapcloser"))
            {
                Spells.ECast(args.End);
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
                && sender.IsValidTarget(Spells.E.Range + Spells.E.Radius - 20)
                && e.DangerLevel == Danger)
            {
                if (Player.Instance.Distance(sender) <= Spells.E.Range + Spells.E.Radius && Spells.E.IsReady())
                {
                    Spells.ECast(sender);
                }
            }
        }
        #endregion
    }
}
