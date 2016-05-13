using System;
using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Menu.Values;
using EloBuddy.SDK.Events;
using SharpDX;


namespace UBAzir
{
    class Mode
    {
        #region Combo
        public static void Combo()
        {
            if (ObjManager.CountAzirSoldier < Config.ComboMenu["Wunitcb"].Cast<Slider>().CurrentValue
                && Config.ComboMenu["Wcb"].Cast<CheckBox>().CurrentValue
                && Spells.W.IsReady())
            {
                var target = TargetSelector.GetTarget(Spells.Q.Range, DamageType.Magical);
                var Force = Orbwalker.ForcedTarget != null ? true : false;
                if (target != null && target.IsValidTarget())
                {
                    SpecialVector.WhereCastW(target, Force);
                }
            }
            if (ObjManager.CountAzirSoldier != 0 && Config.ComboMenu["Qcb"].Cast<CheckBox>().CurrentValue && Spells.Q.IsReady())
            {
                var target = TargetSelector.GetTarget(Spells.Q.Range, DamageType.Magical);
                var Force = Orbwalker.ForcedTarget != null ? true : false;
                if (target != null && target.IsValidTarget() && !target.IsInRange(ObjManager.Soldier_Nearest_Enemy, Spells.WFocus.Range))
                {
                    SpecialVector.WhereCastQ(target, Force);
                }
            }
            if (Config.ComboMenu["Ecb"].Cast<CheckBox>().CurrentValue && Spells.E.IsReady())
            {
                var target = TargetSelector.GetTarget(Spells.E.Range, DamageType.Magical);
                var priority = TargetSelector.GetPriority(target);
                if (target != null && Config.ComboMenu[target.ChampionName].Cast<CheckBox>().CurrentValue)
                {
                    if (priority >= 4
                    && target.IsValidTarget()
                    && !Event.Unkillable(target)
                    && !Event.HasSpellShield(target))
                    {
                        if (target.CountEnemiesInRange(1300) == 1
                            && Player.Instance.HealthPercent >= 75)
                        {
                            Spells.E.Cast(target.Position);
                        }
                        if (target.CountEnemiesInRange(1300) <= Config.ComboMenu["Edanger"].Cast<Slider>().CurrentValue + 1)
                        {
                            if (target.Health <= (Damages.Damagefromspell
                            (target,
                            Spells.Q.IsReady(),
                            Spells.W.IsReady() || target.Distance(ObjManager.Soldier_Nearest_Enemy) > 375,
                            Spells.E.IsReady(),
                            Spells.R.IsReady()))
                            + Damages.WDamage(target) * 4)
                            {
                                foreach (var soldier in Orbwalker.AzirSoldiers.Where(s => s.Distance(Player.Instance) <= Spells.E.Range))
                                {
                                    if (SpecialVector.IsBetween(target))
                                    {
                                        Spells.E.Cast(soldier);
                                    }
                                }
                            }
                        }
                    }
                    if (priority < 3
                    && target.IsValidTarget()
                    && !Event.Unkillable(target)
                    && !Event.HasSpellShield(target))
                    {
                        if (target.CountEnemiesInRange(1300) <= Config.ComboMenu["Edanger"].Cast<Slider>().CurrentValue + 1)
                        {
                            if (target.Health <= (Damages.Damagefromspell
                             (target,
                             Spells.Q.IsReady(),
                             Spells.W.IsReady() || target.Distance(ObjManager.Soldier_Nearest_Enemy) > 375,
                             Spells.E.IsReady(),
                             Spells.R.IsReady()))
                             + Damages.WDamage(target) * 2)
                            {
                                foreach (var soldier in Orbwalker.AzirSoldiers.Where(s => s.Distance(Player.Instance) <= Spells.E.Range))
                                {
                                    if (SpecialVector.IsBetween(target))
                                    {
                                        Spells.E.Cast(soldier);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            if (Config.ComboMenu["Rcb"].Cast<CheckBox>().CurrentValue && Spells.R.IsReady())
            {
                if (Config.ComboMenu["teamfight"].Cast<KeyBind>().CurrentValue)
                {
                    var target = TargetSelector.GetTarget(Spells.R.Range + 200, DamageType.Magical);
                    if (target != null)
                    {
                        if ((target.CountEnemiesInRange(1000) >= Config.ComboMenu["Rhitcb"].Cast<Slider>().CurrentValue
                            || Player.Instance.CountAlliesInRange(1000) >= Config.ComboMenu["Rhitcb"].Cast<Slider>().CurrentValue)
                            && Player.Instance.CountEnemiesInRange(Spells.R.Width) >= Config.ComboMenu["Rhitcb"].Cast<Slider>().CurrentValue)
                        {
                            Spells.R.Cast(target.Position);
                        }
                    }
                }
                if (!Config.ComboMenu["teamfight"].Cast<KeyBind>().CurrentValue)
                {
                    var target = TargetSelector.GetTarget(Spells.R.Range - 20, DamageType.Magical);
                    var Force = Orbwalker.ForcedTarget != null ? true : false;
                    if (target != null && target.IsValidTarget())
                    {
                        SpecialVector.WhereCastR(target, SpecialVector.I_want.All);
                    }
                }
            }
            if (ObjManager.Soldier_Nearest_Enemy != Vector3.Zero)
            {
                var Unit = TargetSelector.SelectedTarget != null &&
                                 TargetSelector.SelectedTarget.Distance(ObjManager.Soldier_Nearest_Enemy) < 500
                        ? TargetSelector.SelectedTarget
                        : TargetSelector.GetTarget(Spells.WLine.Range, DamageType.Magical, ObjManager.Soldier_Nearest_Enemy);
                if (Unit.IsValid())
                {
                    SpecialVector.AttackOtherObject();
                }
            }
        }
        #endregion

        #region Harass
        public static void Harass()
        {
            if (Player.Instance.ManaPercent >= Config.HarassMenu["HrManager"].Cast<Slider>().CurrentValue)
            {
                if (ObjManager.CountAzirSoldier < Config.ComboMenu["Wunitcb"].Cast<Slider>().CurrentValue
                    && Config.ComboMenu["Whr"].Cast<CheckBox>().CurrentValue
                    && Config.ComboMenu["Qhr"].Cast<CheckBox>().CurrentValue
                    && Spells.W.IsReady()
                    && Spells.Q.IsReady())
                {
                    var target = TargetSelector.GetTarget(Spells.Q.Range, DamageType.Magical);
                    if (target != null && target.IsValidTarget())
                    {
                        SpecialVector.WhereCastW(target);
                    }
                }
                if (ObjManager.CountAzirSoldier != 0 && Config.ComboMenu["Qhr"].Cast<CheckBox>().CurrentValue)
                {
                    var target = TargetSelector.GetTarget(Spells.Q.Range, DamageType.Magical);
                    var Force = Orbwalker.ForcedTarget != null ? true : false;
                    if (target != null && target.IsValidTarget() && !target.IsInRange(ObjManager.Soldier_Nearest_Enemy, Spells.WFocus.Range))
                    {
                        SpecialVector.WhereCastQ(target, Force);
                    }
                }
            }
            if (ObjManager.CountAzirSoldier > 0 && ObjManager.Soldier_Nearest_Enemy != Vector3.Zero)
            {
                var Unit = TargetSelector.SelectedTarget != null &&
                                TargetSelector.SelectedTarget.Distance(ObjManager.Soldier_Nearest_Enemy) < 500
                       ? TargetSelector.SelectedTarget
                       : TargetSelector.GetTarget(Spells.WLine.Range, DamageType.Magical, ObjManager.Soldier_Nearest_Enemy);
                if (Unit.IsValid())
                {
                    SpecialVector.AttackOtherObject();
                }
            }
            /*if (Player.Instance.Level <= 12 && ObjManager.CountAzirSoldier > 0 && ObjManager.Soldier_Nearest_Enemy != Vector3.Zero)
            {
                var minion = EntityManager.MinionsAndMonsters.Minions.Where(m => m.IsEnemy
                    && m.Distance(ObjManager.Soldier_Nearest_Enemy) <= 375
                    && m.Health <= Damages.WDamage(m) + 20).FirstOrDefault();
                if (minion != null)
                {
                    Orbwalker.DisableAttacking = true;
                    if (minion.Health <= Damages.WDamage(minion))
                    {
                        Player.IssueOrder(GameObjectOrder.AttackTo, minion);
                    }
                }
                else { Orbwalker.DisableAttacking = false; }
            }*/
        }
        #endregion

        #region LaneClear
        public static void LaneClear()
        {
            /*if (Player.Instance.Level <= 12 && ObjManager.CountAzirSoldier > 0)
            {
                if (ObjManager.Soldier_Nearest_Enemy != Vector3.Zero)
                {
                    var minion = EntityManager.MinionsAndMonsters.Minions.Where(m => m.IsEnemy
                        && m.Distance(ObjManager.Soldier_Nearest_Enemy) <= 380
                        && m.Health <= Damages.WDamage(m) + 20).FirstOrDefault();
                    if (minion != null)
                    {
                        Orbwalker.DisableAttacking = true;
                        if (minion.Health <= Damages.WDamage(minion))
                        {
                            Player.IssueOrder(GameObjectOrder.AttackTo, minion);
                        }
                    }
                    else { Orbwalker.DisableAttacking = false; }
                }
            }*/
            if (Player.Instance.ManaPercent >= Config.LaneClear["LcManager"].Cast<Slider>().CurrentValue)
            {
                if (Config.LaneClear["Qlc"].Cast<CheckBox>().CurrentValue)
                {
                    var Soldier = ObjManager.SoldierPos;
                    if (Soldier != Vector3.Zero)
                    {
                        //var minion = EntityManager.MinionsAndMonsters.Minions.Where(m => m.Distance(Player.Instance) <= Spells.Q.Range).OrderBy(m => m.Health).LastOrDefault();
                        var minion = EntityManager.MinionsAndMonsters.GetLineFarmLocation(
                            EntityManager.MinionsAndMonsters.GetLaneMinions(EntityManager.UnitTeam.Enemy),
                            (float)Spells.Q.Width,
                            (int)Spells.Q.Range,
                            (Vector2)Soldier);
                        Spells.Q.Cast(minion.CastPosition);
                    }
                }
                if (Config.LaneClear["Wlc"].Cast<CheckBox>().CurrentValue)
                {
                    var minion = EntityManager.MinionsAndMonsters.GetCircularFarmLocation(
                        EntityManager.MinionsAndMonsters.GetLaneMinions(EntityManager.UnitTeam.Enemy),
                        (float)Spells.W.Width,
                        (int)Spells.W.Range);
                    if (ObjManager.CountAzirSoldier < Config.LaneClear["Wunitlc"].Cast<Slider>().CurrentValue)
                    {
                        Spells.W.Cast(minion.CastPosition);
                    }
                }
            }
        }
        #endregion

        #region JungleClear
        public static void JungleClear()
        {
            var monster = EntityManager.MinionsAndMonsters.Monsters.OrderBy(m => m.Health).LastOrDefault();
            if (Player.Instance.ManaPercent >= Config.JungleClear["JcManager"].Cast<Slider>().CurrentValue && monster != null)
            {
                if (Config.LaneClear["Qjc"].Cast<CheckBox>().CurrentValue && Spells.Q.IsReady())
                {
                    var Soldier = ObjManager.SoldierPos;
                    if (Soldier != Vector3.Zero)
                    {
                        Spells.Q.Cast(monster);
                    }
                }
                if (Config.LaneClear["Wjc"].Cast<CheckBox>().CurrentValue && Spells.W.IsReady())
                {
                    if (ObjManager.CountAzirSoldier < Config.LaneClear["Wunitlc"].Cast<Slider>().CurrentValue)
                    {
                        Spells.W.Cast(monster);
                    }
                }
            }
        }
        #endregion

        #region Lasthit
        public static void Lasthit()
        {
            if (Player.Instance.ManaPercent >= Config.LasthitMenu["LhManager"].Cast<Slider>().CurrentValue)
            {
                if (Config.LaneClear["Wlh"].Cast<CheckBox>().CurrentValue)
                {
                    var minion = EntityManager.MinionsAndMonsters.GetCircularFarmLocation(
                        EntityManager.MinionsAndMonsters.GetLaneMinions(EntityManager.UnitTeam.Enemy,
                        Player.Instance.Position, Spells.W.Radius), Spells.W.Radius, (int)Spells.W.Range, Player.Instance.Position.To2D());
                    if (ObjManager.CountAzirSoldier < Config.LaneClear["Wunitlc"].Cast<Slider>().CurrentValue)
                    {
                        Spells.W.Cast(minion.CastPosition);
                    }
                }
                if (Config.LaneClear["Qlh"].Cast<CheckBox>().CurrentValue)
                {
                    var minion = EntityManager.MinionsAndMonsters.EnemyMinions.OrderBy(a => a.Health).FirstOrDefault
                    (m => m.IsEnemy
                    && m.Distance(Player.Instance.Position) <= Spells.Q.Range
                    && !m.IsDead
                    && !m.IsInvulnerable
                    && m.IsValidTarget(Spells.Q.Range)
                    && m.Health <= Damages.QDamage(m));
                    if (minion != null && Spells.Q.IsReady() && ObjManager.CountAzirSoldier > 0)
                    {
                        Spells.Q.Cast(minion);
                    }
                }
            }
        }
        #endregion

        #region Flee
        public static void Flee()
        {
            var WCast = Player.Instance.Position.Extend(Game.CursorPos, Spells.W.Range).To3D();
            var QCast = Player.Instance.Position.Extend(Game.CursorPos, Spells.Q.Range).To3D();
            var ECast = Player.Instance.Position.Extend(Game.CursorPos, Spells.E.Range).To3D();
            if (Config.Flee["flee"].Cast<ComboBox>().CurrentValue == 0)
            {
                if (Spells.W.IsReady() && Spells.E.IsReady())
                {
                    Spells.W.Cast(WCast);
                    Spells.E.Cast(ECast);
                }
            }

            if (Config.Flee["flee"].Cast<ComboBox>().CurrentValue == 1)
            {
                if (Spells.Q.IsReady() && Spells.E.IsReady())
                {
                    if (ObjManager.CountAzirSoldier == 0 && Spells.W.IsReady())
                    {
                        Spells.W.Cast(WCast);
                        Spells.Q.Cast(QCast);
                        Spells.E.Cast(ECast);
                    }
                    if (ObjManager.CountAzirSoldier > 0)
                    {
                        Spells.Q.Cast(QCast);
                        Spells.E.Cast(ECast);
                    }
                }
            }
            if (Config.Flee["flee"].Cast<ComboBox>().CurrentValue == 2 && ObjManager.All_Basic_Is_Ready)
            {
                if (ObjManager.CountAzirSoldier == 0)
                {
                    Spells.W.Cast(WCast);
                }
                if (ObjManager.CountAzirSoldier > 0)
                {
                    Spells.E.Cast(ECast);
                    if (Player.Instance.Distance(ObjManager.Soldier_Nearest_Azir) <= 100)
                    {
                        Spells.Q.Cast(QCast);
                    }
                }
            }
        }
        #endregion

        #region On_Unkillable_Minion
        public static void On_Unkillable_Minion(Obj_AI_Base unit, Orbwalker.UnkillableMinionArgs args)
        {
            if (Player.Instance.ManaPercent < Config.LasthitMenu["LhManager"].Cast<Slider>().CurrentValue
                && Config.LasthitMenu["QLh"].Cast<CheckBox>().CurrentValue
                && Spells.Q.IsReady()
                && ObjManager.CountAzirSoldier > 0)
            {
                if (Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.LaneClear) || Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Harass))
                    Spells.Q.Cast(unit);
            }
        }
        #endregion

        #region KillSteal
        public static void KillSteal(EventArgs args)
        {
            var useQ = Config.MiscMenu["Qks"].Cast<CheckBox>().CurrentValue;
            var useW = Config.MiscMenu["Wks"].Cast<CheckBox>().CurrentValue;
            var useE = Config.MiscMenu["Eks"].Cast<CheckBox>().CurrentValue;
            var useR = Config.MiscMenu["Rks"].Cast<CheckBox>().CurrentValue;
            if (Spells.Q.IsReady() && useQ)
            {
                var target = TargetSelector.GetTarget(EntityManager.Heroes.Enemies.Where(t => t != null
                    && t.IsValidTarget()
                    && Spells.Q.IsInRange(t)
                    && t.Health <= Damages.QDamage(t)), DamageType.Magical);

                if (target != null)
                {
                    var pred = Spells.Q.GetPrediction(target);
                    if (ObjManager.CountAzirSoldier == 0 && Spells.W.IsReady() && useW)
                    {
                        SpecialVector.WhereCastW(target);
                    }
                    if (ObjManager.CountAzirSoldier > 0)
                    {
                        Spells.Q.Cast(pred.UnitPosition);
                    }
                }
            }
            if (Spells.W.IsReady() && useW)
            {
                var target = TargetSelector.GetTarget(EntityManager.Heroes.Enemies.Where(t => t != null
                    && t.IsValidTarget()
                    && Spells.W.IsInRange(t)
                    && t.Health <= Damages.WDamage(t)), DamageType.Magical);

                if (target != null)
                {
                    SpecialVector.WhereCastW(target);
                    Player.IssueOrder(GameObjectOrder.AttackUnit, target);
                }
            }
            if (Spells.E.IsReady() && useE)
            {
                var target = TargetSelector.GetTarget(EntityManager.Heroes.Enemies.Where(t => t != null
                   && t.IsValidTarget()
                   && Spells.E.IsInRange(t)
                   && t.Health <= Damages.EDamage(t)), DamageType.Magical);

                if (target != null && ObjManager.CountAzirSoldier > 0)
                {
                    if (SpecialVector.IsBetween(target))
                    {
                        Spells.E.Cast(ObjManager.Soldier_Nearest_Enemy);
                    }
                }
            }
            if (Spells.R.IsReady() && useR)
            {
                var target = TargetSelector.GetTarget(EntityManager.Heroes.Enemies.Where(t => t != null
                    && t.IsValidTarget()
                    && Spells.W.IsInRange(t)
                    && t.Health <= Damages.RDamage(t)), DamageType.Magical);

                if (target != null)
                {
                    Spells.R.Cast(target);
                }
            }
        }
        #endregion

        #region Auto Harass
        public static void Auto_Harass(EventArgs args)
        {
            if (Config.HarassMenu["autokey"].Cast<KeyBind>().CurrentValue && Player.Instance.ManaPercent >= Config.HarassMenu["automng"].Cast<Slider>().CurrentValue)
            {
                if (ObjManager.CountAzirSoldier < 1
                    && Config.HarassMenu["Wauto"].Cast<ComboBox>().CurrentValue > 0
                    && Spells.W.IsReady())
                {
                    var target = TargetSelector.GetTarget(Spells.Q.Range, DamageType.Magical);
                    var Force = Orbwalker.ForcedTarget != null ? true : false;
                    if (target != null && target.IsValidTarget()
                        && Config.HarassMenu["Wauto"].Cast<ComboBox>().CurrentValue == 1)
                    {
                        SpecialVector.WhereCastW(target, true);
                    }
                    if (target != null && target.IsValidTarget()
                        && Config.HarassMenu["Wauto"].Cast<ComboBox>().CurrentValue == 2
                        && Spells.Q.IsReady())
                    {
                        SpecialVector.WhereCastW(target, Force);
                    }
                }
                if (ObjManager.CountAzirSoldier != 0 && Config.HarassMenu["Qauto"].Cast<CheckBox>().CurrentValue && Spells.Q.IsReady())
                {
                    var target = TargetSelector.GetTarget(Spells.Q.Range, DamageType.Magical);
                    var Force = Orbwalker.ForcedTarget != null ? true : false;
                    if (target != null && target.IsValidTarget() && !target.IsInRange(ObjManager.Soldier_Nearest_Enemy, Spells.WFocus.Range))
                    {
                        SpecialVector.WhereCastQ(target, Force);
                    }
                }
                if (ObjManager.CountAzirSoldier > 0 
                    && ObjManager.Soldier_Nearest_Enemy != Vector3.Zero
                    && Config.HarassMenu["aa.auto"].Cast<CheckBox>().CurrentValue)
                {
                    var Unit = TargetSelector.SelectedTarget != null &&
                                    TargetSelector.SelectedTarget.Distance(ObjManager.Soldier_Nearest_Enemy) < 500
                           ? TargetSelector.SelectedTarget
                           : TargetSelector.GetTarget(Spells.WLine.Range, DamageType.Magical, ObjManager.Soldier_Nearest_Enemy);
                    if (Unit.IsValid())
                    {
                        SpecialVector.AttackOtherObject();
                    }
                }
                if (ObjManager.CountAzirSoldier > 0 
                    && ObjManager.Soldier_Nearest_Enemy != Vector3.Zero
                    && Config.HarassMenu["a.auto"].Cast<CheckBox>().CurrentValue)
                {
                    var Unit = TargetSelector.SelectedTarget != null &&
                                    TargetSelector.SelectedTarget.Distance(ObjManager.Soldier_Nearest_Enemy) < 375
                           ? TargetSelector.SelectedTarget
                           : TargetSelector.GetTarget(Spells.WLine.Range, DamageType.Magical, ObjManager.Soldier_Nearest_Enemy);
                    var Minion = Orbwalker.PriorityLastHitWaitingMinion;
                    if (Unit.IsValid() && Minion == null && Unit.IsInRange(ObjManager.Soldier_Nearest_Enemy, Spells.WFocus.Range))
                    {
                        Player.IssueOrder(GameObjectOrder.AttackUnit, Unit);
                    }
                }
            }
        }
        #endregion
    }
}
