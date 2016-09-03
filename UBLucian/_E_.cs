using System;
using System.Collections.Generic;
using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Enumerations;
using EloBuddy.SDK.Menu.Values;
using SharpDX;
using Modes = EloBuddy.SDK.Orbwalker.ActiveModes;

namespace UBLucian
{
    class _E_
    {
        public static Vector3[] BestEPos
        {
            get
            {
                var AARange = Player.Instance.GetAutoAttackRange(Nearest);
                var TargetPosition = new Vector2();
                if (Nearest != null)
                    TargetPosition = Config.EPath.CurrentValue ? Prediction.Position.PredictUnitPosition(Nearest, 500) : Nearest.Position.To2D();
                var Path = Intersection_Of_2Circle(Player.Instance.Position.To2D(), Spells.E.Range, TargetPosition, AARange);
                if (Path.Count() > 0)
                {
                    return new Vector3[] { Path.First().To3D(), Path.Last().To3D() };
                }
                else
                {
                    return new Vector3[] { };
                }
            }
        }
        public static int Get_Style_Of_E
        {
            get
            {
                if (Modes.Flee.IsActive())
                {
                    return 4;
                }
                else
                {
                    return Config.ESettings.GetValue("E", false);
                }
            }
        }
        public static AIHeroClient Nearest
        {
            get
            {
                return EntityManager.Heroes.Enemies.Where(x => x.IsValid && !x.IsDead).OrderBy(x => x.Distance(Player.Instance)).FirstOrDefault();
            }
        }
        public static Vector3 GetPos()
        {
            var AARange = Player.Instance.GetAutoAttackRange(Nearest);
            var TargetPosition = new Vector2();
            if (Nearest != null)
                TargetPosition = Config.EPath.CurrentValue ? Prediction.Position.PredictUnitPosition(Nearest, 500) : Nearest.Position.To2D();
            var Location = new Vector3();
            switch (Get_Style_Of_E)
            {
                case 1:
                    {
                        var Range = Config.ERange.CurrentValue;
                        var Path = Intersection_Of_2Circle(Player.Instance.Position.To2D(), Spells.E.Range, TargetPosition, AARange - Range);
                        if (Path.Count() > 0)
                        {
                            if (Path.Count(x => IsNotDangerPosition(x)) == 2)
                            {
                                Location = Path.OrderByDescending(x => Get_Rate_Position(x)).OrderBy(x => x.Distance(Game.CursorPos)).FirstOrDefault().To3D();
                            }
                            else if (Path.Count(x => IsNotDangerPosition(x)) == 0 && Config.ECorrect.CurrentValue)
                            {
                                var Loc = Path.OrderBy(x => x.Distance(Game.CursorPos)).FirstOrDefault().To3D();
                                Location = CorrectToBetter(Loc);
                            }
                            else
                            {
                                Location = Path.FirstOrDefault(x => IsNotDangerPosition(x)).To3D();
                            }
                        }
                        else
                        {
                            if (Player.Instance.Distance(TargetPosition) >= AARange + Spells.E.Range)
                            {
                                Location = Vector3.Zero;
                            }
                            if (Player.Instance.Distance(TargetPosition) <= AARange - Spells.E.Range && Config.EKite.CurrentValue)
                            {
                                Location = Nearest.Position.Extend(Player.Instance, Nearest.Distance(Player.Instance) + Spells.E.Range).To3D();
                            }
                        }
                    }
                    break;
                case 2:
                    {
                        if (Nearest.Distance(Player.Instance) <= AARange + Spells.E.Range)
                            Location = Player.Instance.ServerPosition.Extend(Game.CursorPos, Spells.E.Range).To3D();
                    }
                    break;
                case 3:
                    {
                        if (Nearest.Distance(Player.Instance) <= AARange + Spells.E.Range)
                        {
                            if (Nearest.Distance(Player.Instance) <= AARange - Spells.E.Range && Config.EKite.CurrentValue)
                            {
                                Location = Nearest.Position.Extend(Player.Instance, Nearest.Distance(Player.Instance) + Spells.E.Range).To3D();
                            }
                            else
                            {
                                var Pos = Player.Instance.ServerPosition.Extend(Game.CursorPos, Spells.E.Range).To3D();
                                var GrassObject = ObjectManager.Get<GameObject>().Where(x => Spells.E.IsInRange(x.Position) && x.Type.ToString() == "GrassObject").OrderBy(x => x.Distance(Nearest)).FirstOrDefault();
                                if (IsNotDangerPosition(Pos))
                                {
                                    Location = Pos;
                                }
                                else if (Config.ECorrect.CurrentValue)
                                {
                                    if (GrassObject != null && Config.EGrass.CurrentValue)
                                    {
                                        Location = GrassObject.Position;
                                    }
                                    else
                                    {
                                        Location = CorrectToBetter(Pos);
                                    }
                                }
                            }
                        }
                    }
                    break;
                case 4:
                    {
                        Location = Player.Instance.ServerPosition.Extend(Game.CursorPos, Spells.E.Range).To3D();
                    }
                    break;
            }
            return Location;
        }
        public static Vector3 CorrectToBetter(Vector3 Pos)
        {
            var pos = Pos.To2D();
            var Corrected = new Vector3();
            var ERange = Spells.E.Range;
            var PlayerPos = Player.Instance.ServerPosition.To2D();
            var Path = Intersection_Of_2Circle(PlayerPos, ERange, pos, ERange);
            if (Path.Count() > 0)
            {
                if (Path.Count(x => IsNotDangerPosition(x)) == 2)
                {
                    Corrected = Path.FirstOrDefault(x => x.IsInRange(Nearest, Player.Instance.GetAutoAttackRange(Nearest))).To3D();
                }
                else
                {
                    Corrected = Path.FirstOrDefault(x => (IsNotDangerPosition(x))).To3D();
                }
            }
            else
            {
                Corrected = Vector3.Zero;
            }
            return Corrected;
        }
        public static Vector2[] Intersection_Of_2Circle(Vector2 center1, float radius1, Vector2 center2, float radius2)
        {
            var Distance = center1.Distance(center2);
            if (Distance > radius1 + radius2 || (Distance <= Math.Abs(radius1 - radius2)))
            {
                return new Vector2[] { };
            }

            var A = (radius1 * radius1 - radius2 * radius2 + Distance * Distance) / (2 * Distance);
            var H = (float)Math.Sqrt(radius1 * radius1 - A * A);
            var Direction = (center2 - center1).Normalized();
            var PA = center1 + A * Direction;
            var Loc1 = PA + H * Direction.Perpendicular();
            var Loc2 = PA - H * Direction.Perpendicular();
            return new[] { Loc1, Loc2 };
        }
        public static bool IsNotDangerPosition(Vector3 Pos)
        {
            if (Config.ESafe.CurrentValue)
            {
                if (Config.EWall.CurrentValue)
                {
                    var Fragment = Spells.E.Range / 9;
                    for (var i = 1; i <= 9; i++)
                    {
                        if (Player.Instance.Position.Extend(Pos, i * Fragment).IsWall())
                            return false;
                    }
                }
                if (Pos.IsUnderEnemyTurret())
                {
                    return false;
                }
                else if (Nearest != null && Nearest.CountEnemiesInRange(1000) > Nearest.CountAlliesInRange(1000))
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return true;
            }
        }
        public static bool IsNotDangerPosition(Vector2 Pos)
        {
            return IsNotDangerPosition(Pos.To3D());
        }
        public static int Get_Rate_Position(Vector2 Pos)
        {
            var Rate = 0;
            if (NavMesh.IsWallOfGrass(Pos.To3D(), Player.Instance.BoundingRadius))
            {
                Rate += 3;
            }
            if (Pos.CountAlliesInRange(1000) > Pos.CountEnemiesInRange(1000))
            {
                Rate += Pos.CountAlliesInRange(1000) - Pos.CountEnemiesInRange(1000);
            }
            return Rate;
        }
    }
}
