using System;
using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
//using EloBuddy.SDK.Notifications;
using EloBuddy.SDK.Menu.Values;
using SharpDX;


namespace UBAzir
{
    class Insec
    {
        private static AIHeroClient target;
        private static Obj_AI_Turret Turret = EntityManager.Turrets.Allies.FirstOrDefault(t => t.IsValidTarget(1250));
        private static AIHeroClient Ally = EntityManager.Heroes.Allies.OrderByDescending(a => a.CountEnemiesInRange(Spells.R.Range)).FirstOrDefault();
        public static void Do_Normal_Insec()
        {
            var normal = Config.Insec["normal.1"].Cast<ComboBox>().CurrentValue;
            var Force = Orbwalker.ForcedTarget != null ? true : false;
            //var incapability = new SimpleNotification("UBAzir Normal Insec", "It isn't qualified to perform");
            target = TargetSelector.GetTarget(Spells.R.Range - 20, DamageType.Magical, ObjManager.Soldier_Nearest_Enemy);
            if (target != null)
            {
                if (Spells.Flash.IsInRange(target) && Spells.Flash.IsReady() && Config.Insec["allowfl"].Cast<CheckBox>().CurrentValue)
                {
                    var PosAndHits = SpecialVector.GetBestRPos(target.ServerPosition.To2D());
                    if (PosAndHits.First().Value >= Config.Insec["flvalue"].Cast<Slider>().CurrentValue)
                    {
                        Spells.Flash.Cast(PosAndHits.First().Key.To3D());
                        switch (normal)
                        {
                            case 0:
                                {
                                    SpecialVector.WhereCastR(target, SpecialVector.I_want.Cursor);
                                }
                                break;
                            case 1:
                                {
                                    SpecialVector.WhereCastR(target, SpecialVector.I_want.Turret);
                                }
                                break;
                            case 2:
                                {
                                    SpecialVector.WhereCastR(target, SpecialVector.I_want.Ally);
                                }
                                break;
                            case 3:
                                {
                                    SpecialVector.WhereCastR(target, SpecialVector.I_want.LastPostion);
                                }
                                break;
                        }
                    }
                }
                if (target.IsValidTarget(300) && Spells.R.IsReady())
                {
                    if (normal == 0)
                    {
                        SpecialVector.WhereCastR(target, SpecialVector.I_want.Cursor);
                    }
                    else if (Turret != null && normal == 1)
                    {
                        SpecialVector.WhereCastR(target, SpecialVector.I_want.Turret);
                    }
                    else if (Ally != null && normal == 2)
                    {
                        SpecialVector.WhereCastR(target, SpecialVector.I_want.Ally);
                    }
                    else
                    {
                        SpecialVector.WhereCastR(target, SpecialVector.I_want.LastPostion);
                    }
                }
                else
                {
                    Player.IssueOrder(GameObjectOrder.MoveTo, Game.CursorPos);
                }
                if (target.IsValidTarget(1100))
                {
                    if (Spells.Q.IsReady())
                    {
                        if (Spells.R.IsReady())
                        {
                            var insecLoc = Vector3.Zero;
                            var direction = (TargetSelector.SelectedTarget.ServerPosition - ObjectManager.Player.ServerPosition).To2D().Normalized();
                            var insecPos = TargetSelector.SelectedTarget.ServerPosition.To2D() + (direction * 200f);
                            var soldposition = Vector3.Zero;
                            if (Orbwalker.AzirSoldiers.OrderBy(s => s.Distance(insecPos)).FirstOrDefault() != null)
                            {
                                soldposition = Orbwalker.AzirSoldiers.OrderBy(s => s.Distance(insecPos)).FirstOrDefault().ServerPosition;
                            }
                            insecLoc = Player.Instance.ServerPosition;

                            if (Orbwalker.ValidAzirSoldiers.Any(it => it.Distance(Player.Instance.Position) <= 900))
                            {
                                var ESoldier = Orbwalker.ValidAzirSoldiers.FirstOrDefault(it => it.Distance(target) <= 200);

                                if (ESoldier != null) Spells.E.Cast(Player.Instance.Position.Extend(ESoldier.Position, Spells.E.Range).To3D());

                                else if (Spells.Q.IsReady())
                                {
                                    SpecialVector.WhereCastQ(target, Force);
                                }
                            }

                            else if (Spells.W.IsReady())
                            {
                                SpecialVector.WhereCastW(target, Force);
                                return;
                            };
                        }
                        else
                        {
                            Player.IssueOrder(GameObjectOrder.MoveTo, Game.CursorPos);
                        }
                    }
                    else
                    {
                        Player.IssueOrder(GameObjectOrder.MoveTo, Game.CursorPos); 
                    }
                }
                else
                {
                    Player.IssueOrder(GameObjectOrder.MoveTo, Game.CursorPos);
                }
            }
            else
            {
                Player.IssueOrder(GameObjectOrder.MoveTo, Game.CursorPos);
            }
        }

        public static void Do_God_Insec()
        {
            var god1 = Config.Insec["god.1"].Cast<ComboBox>().CurrentValue;
            var god2 = Config.Insec["god.2"].Cast<ComboBox>().CurrentValue;
            var CastRTo = SpecialVector.I_want.Cursor;
            var CastQTo = Vector3.Zero;
            var SoldierPos = Vector3.Zero;
            //var incapability = new SimpleNotification("UBAzir God Insec", "It isn't qualified to perform");
            target = TargetSelector.GetTarget(300, DamageType.Magical, ObjManager.Soldier_Nearest_Enemy);
            if (target != null)
            {
                if (target.IsValidTarget())
                {
                    if (Spells.Q.IsReady())
                    {
                        if (Spells.R.IsReady())
                        {                                                      
                            switch (god1)
                            {
                                case 0:
                                    {
                                        CastRTo = SpecialVector.I_want.Cursor;
                                        SpecialVector.WhereCastR(target, CastRTo);
                                    }
                                    break;

                                case 1:
                                    {
                                        CastRTo = SpecialVector.I_want.Ally;
                                        SpecialVector.WhereCastR(target, CastRTo);
                                    }
                                    break;

                                case 2:
                                    {
                                        CastRTo = SpecialVector.I_want.Turret;
                                        SpecialVector.WhereCastR(target, CastRTo);
                                    }
                                    break;

                                case 3:
                                    {
                                        CastRTo = SpecialVector.I_want.LastPostion;
                                        SpecialVector.WhereCastR(target, CastRTo);
                                    }
                                    break;
                            }
                            switch (god2)
                            {
                                case 0:
                                    {
                                        CastQTo = Game.CursorPos;
                                    }
                                    break;

                                case 1:
                                    {
                                        var Ally = EntityManager.Heroes.Allies.OrderByDescending(a => a.CountEnemiesInRange(Spells.R.Range)).FirstOrDefault();
                                        CastQTo = Ally != null ? Ally.ServerPosition : Game.CursorPos;
                                    }
                                    break;
                                case 2:
                                    {
                                        var Turret = EntityManager.Turrets.Allies.FirstOrDefault(t => t.IsValidTarget(1250));
                                        CastQTo = Turret != null ? Turret.ServerPosition : Game.CursorPos;
                                    }
                                    break;
                            }
                            if (ObjManager.CountAzirSoldier < 1 && ObjManager.All_Basic_Is_Ready && Player.Instance.Mana > 370)
                            {
                                SpecialVector.WhereCastW(target);
                            }

                            if (ObjManager.CountAzirSoldier > 0 && target.Distance(Player.Instance) > 200)
                            {
                                if (ObjManager.Soldier_Nearest_Enemy != Vector3.Zero)
                                {
                                    SoldierPos = ObjManager.Soldier_Nearest_Enemy;
                                }

                                if (target.Position.IsInRange(SoldierPos, Spells.R.Width))
                                {
                                    var time = (Player.Instance.ServerPosition.Distance(ObjManager.Soldier_Nearest_Azir) / Spells.E.Speed) * (500 + Game.Ping);
                                    Spells.E.Cast(Player.Instance.Position.Extend(target, Spells.E.Range).To3D());
                                    Core.DelayAction(() => Spells.Q.Cast(Player.Instance.Position.Extend(CastQTo, Spells.Q.Range).To3D()), (int)time);
                                }
                                else
                                {
                                    Player.IssueOrder(GameObjectOrder.MoveTo, Game.CursorPos);
                                }
                            }
                            else
                            {
                                Player.IssueOrder(GameObjectOrder.MoveTo, Game.CursorPos);
                            } 
                        }
                        else
                        {
                            Player.IssueOrder(GameObjectOrder.MoveTo, Game.CursorPos);
                        }
                    }
                    else
                    {
                        Player.IssueOrder(GameObjectOrder.MoveTo, Game.CursorPos);
                    }
                }
                else
                {
                    Player.IssueOrder(GameObjectOrder.MoveTo, Game.CursorPos);
                }
            }
            else
            {
                Player.IssueOrder(GameObjectOrder.MoveTo, Game.CursorPos);
            }
        }
    }
}
