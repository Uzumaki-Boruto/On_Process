using System;
using System.Collections.Generic;
using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Enumerations;
using EloBuddy.SDK.Menu.Values;
using SharpDX;

namespace UBAzir
{
    class SpecialVector
    {
        public static AIHeroClient EnemyTarget;
        public enum I_want
        {
            Cursor, Ally, Turret, LastPostion, All
        }
        public static I_want Iwant;
        public static void WhereCastQ(Obj_AI_Base enemy, bool forcedEnemy = false)
        {
            var EnemyPos = enemy.ServerPosition;
            var MyPos = Player.Instance.Position;
            var Combo = Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Combo);
            var Harass = Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Harass);
            var QBonusCombo = Config.ComboMenu["Qcbbonus"].Cast<Slider>().CurrentValue;
            var QBonusHarrass = Config.HarassMenu["Qhrbonus"].Cast<Slider>().CurrentValue;
            var Bonus = Combo ? QBonusCombo : Harass ? QBonusHarrass : QBonusCombo;
            var Path = enemy.Path.LastOrDefault();
            var Soldier = Orbwalker.AzirSoldiers.LastOrDefault(s => s.IsAlly);
            if (Path != null)
            {
                if (MyPos.Distance(Path) >= MyPos.Distance(Soldier))
                {
                    if (enemy != null && enemy.IsValid && !enemy.IsInRange(ObjManager.Soldier_Nearest_Enemy, 375))
                    {
                        var Pos = MyPos.Extend(EnemyPos.Extend(Path, 100).To3D(), MyPos.Distance(EnemyPos) + (float)Bonus).To3D();
                        Spells.Q.Cast(Pos);
                        Orbwalker.ResetAutoAttack();
                    }
                    if (enemy != null && enemy.IsValid && !enemy.IsInRange(ObjManager.Soldier_Nearest_Enemy, 375) && !enemy.IsInRange(Player.Instance, Spells.Q.Range - Bonus))
                    {
                        var Pos = MyPos.Extend(EnemyPos.Extend(Path, 100).To3D() , Spells.Q.Range).To3D();
                        Spells.Q.Cast(Pos);
                        Orbwalker.ResetAutoAttack();
                    }
                }
                if (MyPos.Distance(Path) < MyPos.Distance(Soldier))
                {
                    if (enemy != null && enemy.IsValid && !enemy.IsInRange(ObjManager.Soldier_Nearest_Enemy, 375) && enemy.IsInRange(Player.Instance, Spells.Q.Range))
                    {
                        Spells.Q.Cast(enemy);
                        Orbwalker.ResetAutoAttack();
                    }
                }
            }
        }
        public static void WhereCastW(Obj_AI_Base enemy, bool forcedEnemy = false)
        {
            var prediction = Spells.Q.GetPrediction(enemy);

            if (forcedEnemy)
                if (Spells.W.Range + Spells.W.Radius <= Player.Instance.Distance(prediction.CastPosition))
                    return;

            var endPoint = Player.Instance.ServerPosition.To2D()
                .Extend(prediction.CastPosition.To2D(), Spells.Q.Range);

            if ((prediction.HitChance == HitChance.High || prediction.HitChance == HitChance.Collision || prediction.HitChance == HitChance.Medium) &&
                prediction.UnitPosition.To2D().Distance(Player.Instance.ServerPosition.To2D(), endPoint, false) <
                        Spells.Q.Width + enemy.BoundingRadius)
            {

                if (prediction.CastPosition.Distance(Player.Instance) <= Spells.W.Range)
                    Spells.W.Cast(prediction.CastPosition);
                else
                    Spells.W.Cast(Player.Instance.ServerPosition.To2D().Extend(prediction.CastPosition.To2D(), (float)(Spells.W.Range)).To3D());
            }
        }
        public static void WhereCastR(Obj_AI_Base enemy, I_want want)
        {
            var MyPos = Player.Instance.Position;
            var Turret = EntityManager.Turrets.Allies.Where(t => t.Distance(MyPos) <= 1000).FirstOrDefault();
            var Allies = EntityManager.Heroes.Allies.Where(a => a.Distance(MyPos) <= 1000).FirstOrDefault();
            var MyPosBefore = ObjManager.LastMyPos;
            if (enemy.IsInRange(Player.Instance, 300))
            {
                if (want == I_want.Cursor)
                {
                    var Pos = MyPos.Extend(Game.CursorPos, 400).To3D();
                    Spells.R.Cast(Pos);
                }
                if (want == I_want.Turret)
                {
                    if (Turret != null && !Turret.IsDead && Turret.IsValid)
                    {
                        var Pos = MyPos.Extend(Turret.Position, 400).To3D();
                        Spells.R.Cast(Pos);
                    }
                    if (Turret == null || Turret.IsDead || !Turret.IsValid)
                    {
                        var Pos = MyPos.Extend(Game.CursorPos, 400).To3D();
                        Spells.R.Cast(Pos);
                    }
                }
                if (want == I_want.Ally)
                {
                    if (Allies != null && !Allies.IsDead)
                    {
                        var Pos = MyPos.Extend(Allies.Position, 400).To3D();
                        Spells.R.Cast(Pos);
                    }
                    if (Allies == null || Allies.IsDead)
                    {
                        var Pos = MyPos.Extend(Game.CursorPos, 400).To3D();
                        Spells.R.Cast(Pos);
                    }
                }
                if (want == I_want.LastPostion)
                {
                    Spells.R.Cast(ObjManager.LastMyPos);
                }
                if (want == I_want.All)
                {
                    if (Turret != null && !Turret.IsDead && Turret.IsValid)
                    {
                        var Pos = MyPos.Extend(Turret.Position, 400).To3D();
                    }
                    if (Turret == null || Turret.IsDead || !Turret.IsValid)
                    {
                        if (Allies != null && !Allies.IsDead)
                        {
                            var Pos = MyPos.Extend(Allies.Position, 400).To3D();
                            Spells.R.Cast(Pos);
                        }
                        if (Allies == null || Allies.IsDead)
                        {
                            var Pos = MyPos.Extend(Game.CursorPos, 400).To3D();
                            Spells.R.Cast(Pos);
                        }
                    }
                }
            }
            if (!enemy.IsInRange(Player.Instance, 300) && enemy.IsInRange(Player.Instance, Spells.R.Range))
            {
                Spells.R.Cast(enemy);
            }
            return;
        }       
        public static void AttackOtherObject()
        {
            if (ObjManager.Soldier_Nearest_Enemy != Vector3.Zero)
            {
                var target = TargetSelector.SelectedTarget != null &&
                             TargetSelector.SelectedTarget.Distance(ObjManager.Soldier_Nearest_Enemy) < 450
                    ? TargetSelector.SelectedTarget
                    : TargetSelector.GetTarget(Spells.WLine.Range, DamageType.Magical, ObjManager.Soldier_Nearest_Enemy);

                if (!target.IsValidTarget())
                    return;

                var TargetPos = target.Position;
                var minions =
                    EntityManager.MinionsAndMonsters.EnemyMinions.Where(m => m.Distance(ObjManager.Soldier_Nearest_Enemy) <= Spells.WFocus.Range);
                var monsters =
                    EntityManager.MinionsAndMonsters.Monsters.Where(m => m.Distance(ObjManager.Soldier_Nearest_Enemy) <= Spells.WFocus.Range);
                var champs = EntityManager.Heroes.Enemies.Where(c => c.Distance(ObjManager.Soldier_Nearest_Enemy) <= Spells.WFocus.Range);
                {
                    foreach (var minion in from minion in minions
                                           let polygon = new Geometry.Polygon.Rectangle(
                                               (Vector2)ObjManager.Soldier_Nearest_Enemy,
                                               ObjManager.Soldier_Nearest_Enemy.Extend(minion.Position, Spells.WLine.Range), 50f)
                                           where polygon.IsInside(TargetPos)
                                           select minion)
                    {
                        Player.IssueOrder(GameObjectOrder.AttackUnit, minion);
                    }

                    foreach (var monster in from monster in monsters
                                            let polygon = new Geometry.Polygon.Rectangle(
                                                (Vector2)ObjManager.Soldier_Nearest_Enemy,
                                               ObjManager.Soldier_Nearest_Enemy.Extend(monster.Position, Spells.WLine.Range), 50f)
                                            where polygon.IsInside(TargetPos)
                                            select monster)
                    {
                        Player.IssueOrder(GameObjectOrder.AttackUnit, monster);
                    }

                    foreach (var champ in from champ in champs
                                          let polygon = new Geometry.Polygon.Rectangle(
                                              (Vector2)ObjManager.Soldier_Nearest_Enemy,
                                               ObjManager.Soldier_Nearest_Enemy.Extend(champ.Position, Spells.WLine.Range), 50f)
                                          where polygon.IsInside(TargetPos)
                                          select champ)
                    {
                        if (!Orbwalker.CanAutoAttack)
                        {
                            return;
                        }
                        else
                        {
                            Player.IssueOrder(GameObjectOrder.AttackUnit, champ);
                        }
                    }
                }
            }
        }
        public static bool Between(Vector3 checkPos, Vector3 source, Vector3 destination)
        {
            return Math.Abs(((source.X * checkPos.Y) + (source.Y * destination.X) + (checkPos.X * destination.Y)) - ((checkPos.Y * destination.X) + (source.X * destination.Y) + (source.Y * checkPos.X))) < 5;
        }

        #region Flash Logic

        public static int CountRHits(Vector2 CastPosition)
        {
            int Hits = new int();

            foreach (Vector3 EnemyPos in GetEnemiesPosition())
            {
                if (CastPosition.Distance(EnemyPos) <= 260) Hits += 1;
            }

            return Hits;
        }
        public static List<Vector3> GetEnemiesPosition()
        {
            List<Vector3> Positions = new List<Vector3>();

            foreach (AIHeroClient Hero in EntityManager.Heroes.Enemies.Where(hero => !hero.IsDead && Player.Instance.Distance(hero) <= Spells.R.Width))
            {
                Positions.Add(Prediction.Position.PredictUnitPosition(Hero, 500).To3D());
            }

            return Positions;
        }
        public static Dictionary<Vector2, int> GetBestRPos(Vector2 TargetPosition)
        {
            Dictionary<Vector2, int> PosAndHits = new Dictionary<Vector2, int>();

            List<Vector2> RPos = new List<Vector2>
            {
                new Vector2(TargetPosition.X - 250, TargetPosition.Y + 100),
                new Vector2(TargetPosition.X - 250, TargetPosition.Y),

                new Vector2(TargetPosition.X - 200, TargetPosition.Y + 300),
                new Vector2(TargetPosition.X - 200, TargetPosition.Y + 200),
                new Vector2(TargetPosition.X - 200, TargetPosition.Y + 100),
                new Vector2(TargetPosition.X - 200, TargetPosition.Y - 100),
                new Vector2(TargetPosition.X - 200, TargetPosition.Y),

                new Vector2(TargetPosition.X - 160, TargetPosition.Y - 160),

                new Vector2(TargetPosition.X - 100, TargetPosition.Y + 300),
                new Vector2(TargetPosition.X - 100, TargetPosition.Y + 200),
                new Vector2(TargetPosition.X - 100, TargetPosition.Y + 100),
                new Vector2(TargetPosition.X - 100, TargetPosition.Y + 250),
                new Vector2(TargetPosition.X - 100, TargetPosition.Y - 200),
                new Vector2(TargetPosition.X - 100, TargetPosition.Y - 100),
                new Vector2(TargetPosition.X - 100, TargetPosition.Y),

                new Vector2(TargetPosition.X, TargetPosition.Y + 300),
                new Vector2(TargetPosition.X, TargetPosition.Y + 270),
                new Vector2(TargetPosition.X, TargetPosition.Y + 200),
                new Vector2(TargetPosition.X, TargetPosition.Y + 100),

                new Vector2(TargetPosition.X, TargetPosition.Y),

                new Vector2(TargetPosition.X, TargetPosition.Y - 100),
                new Vector2(TargetPosition.X, TargetPosition.Y - 200),

                new Vector2(TargetPosition.X + 100, TargetPosition.Y),
                new Vector2(TargetPosition.X + 100, TargetPosition.Y - 100),
                new Vector2(TargetPosition.X + 100, TargetPosition.Y - 200),
                new Vector2(TargetPosition.X + 100, TargetPosition.Y + 100),
                new Vector2(TargetPosition.X + 100, TargetPosition.Y + 200),
                new Vector2(TargetPosition.X + 100, TargetPosition.Y + 250),
                new Vector2(TargetPosition.X + 100, TargetPosition.Y + 300),

                new Vector2(TargetPosition.X + 160, TargetPosition.Y - 160),

                new Vector2(TargetPosition.X + 200, TargetPosition.Y),
                new Vector2(TargetPosition.X + 200, TargetPosition.Y - 100),
                new Vector2(TargetPosition.X + 200, TargetPosition.Y + 100),
                new Vector2(TargetPosition.X + 200, TargetPosition.Y + 200),
                new Vector2(TargetPosition.X + 200, TargetPosition.Y + 300),

                new Vector2(TargetPosition.X + 250, TargetPosition.Y),
                new Vector2(TargetPosition.X + 250, TargetPosition.Y + 100),
            };

            foreach (Vector2 pos in RPos)
            {
                PosAndHits.Add(pos, CountRHits(pos));
            }

            Vector2 PosToGG = PosAndHits.First(pos => pos.Value == PosAndHits.Values.Max()).Key;
            int Hits = PosAndHits.First(pos => pos.Key == PosToGG).Value;

            return new Dictionary<Vector2, int>() { { PosToGG, Hits } };
        }

        #endregion
    }
}
