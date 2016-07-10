using System;
using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Menu.Values;
using EloBuddy.SDK.Enumerations;

namespace UBActivator
{
    class Offensive
    {
        public static void Ontick(EventArgs args)
        {
            if (Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.LaneClear))
            {
                var Count = EntityManager.MinionsAndMonsters.GetLaneMinions(EntityManager.UnitTeam.Enemy, Player.Instance.Position, 400).Count();
                if (Count >= Config.Offensive["TiamatLccount"].Cast<Slider>().CurrentValue)
                {
                    if (Items.Tiamat.IsOwned() && Items.Tiamat.IsReady()) Items.Tiamat.Cast();
                    else if (Items.Ravenous_Hydra.IsOwned() && Items.Ravenous_Hydra.IsReady()) Items.Ravenous_Hydra.Cast();
                    else if (Items.Titanic_Hydra.IsOwned() && Items.Titanic_Hydra.IsReady())
                    {
                        Items.Titanic_Hydra.Cast();
                        Orbwalker.ResetAutoAttack();
                    }
                }
            }
            else if (Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.JungleClear))
            {
                var Count = EntityManager.MinionsAndMonsters.GetJungleMonsters(Player.Instance.Position, 400).Count();
                var impMonster = ObjectManager.Get<Obj_AI_Minion>().Where(m => m.IsMonster && m.IsValidTarget(Spells.Smite.Range) && Extensions.IsImportant(m)).OrderBy(x => x.MaxHealth).LastOrDefault();

                if (Count >= Config.Offensive["TiamatLccount"].Cast<Slider>().CurrentValue)
                {
                    if (Items.Tiamat.IsOwned() && Items.Tiamat.IsReady()) Items.Tiamat.Cast();
                    else if (Items.Ravenous_Hydra.IsOwned() && Items.Ravenous_Hydra.IsReady()) Items.Ravenous_Hydra.Cast();
                    else if (Items.Titanic_Hydra.IsOwned() && Items.Titanic_Hydra.IsReady())
                    {
                        Items.Titanic_Hydra.Cast();
                        Orbwalker.ResetAutoAttack();
                    }
                }
                else if (Player.Instance.Distance(impMonster) <= 400)
                {
                    if (Items.Tiamat.IsOwned() && Items.Tiamat.IsReady()) Items.Tiamat.Cast();
                    else if (Items.Ravenous_Hydra.IsOwned() && Items.Ravenous_Hydra.IsReady()) Items.Ravenous_Hydra.Cast();
                    else if (Items.Titanic_Hydra.IsOwned() && Items.Titanic_Hydra.IsReady())
                    {
                        Items.Titanic_Hydra.Cast();
                        Orbwalker.ResetAutoAttack();
                    }
                }
            }
            else
            {
                var TiamatTarget = TargetSelector.GetTarget(400, DamageType.Physical);
                var CutlassTarget = TargetSelector.GetTarget(550, DamageType.Magical);
                var HextechTarget = TargetSelector.GetTarget(700, DamageType.Magical);
                var distance = Player.Instance.Distance(TiamatTarget);
                if (TiamatTarget != null
                    && Config.Offensive["Tiamat"].Cast<ComboBox>().CurrentValue > 0
                    && TiamatTarget.IsValidTarget() 
                    && distance >= 400 * Config.Offensive["TiamatSlider"].Cast<Slider>().CurrentValue / 100)
                {
                    switch (Config.Offensive["Tiamat"].Cast<ComboBox>().CurrentValue)
                    {
                        case 1:
                            {
                                if (Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Harass))
                                {
                                    if (Items.Tiamat.IsOwned() && Items.Tiamat.IsReady()) Items.Tiamat.Cast();
                                    else if (Items.Ravenous_Hydra.IsOwned() && Items.Ravenous_Hydra.IsReady()) Items.Ravenous_Hydra.Cast();
                                }
                            }
                            break;
                        case 2:
                            {
                                if (Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Combo))
                                {
                                    if (Items.Tiamat.IsOwned() && Items.Tiamat.IsReady()) Items.Tiamat.Cast();
                                    else if (Items.Ravenous_Hydra.IsOwned() && Items.Ravenous_Hydra.IsReady()) Items.Ravenous_Hydra.Cast();
                                }
                            }
                            break;
                        case 3:
                            {
                                if (Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Harass) || Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Combo))
                                {
                                    if (Items.Tiamat.IsOwned() && Items.Tiamat.IsReady()) Items.Tiamat.Cast();
                                    else if (Items.Ravenous_Hydra.IsOwned() && Items.Ravenous_Hydra.IsReady()) Items.Ravenous_Hydra.Cast();
                                }
                            }
                            break;
                        case 4:
                            {
                                if (Items.Tiamat.IsOwned() && Items.Tiamat.IsReady()) Items.Tiamat.Cast();
                                else if (Items.Ravenous_Hydra.IsOwned() && Items.Ravenous_Hydra.IsReady()) Items.Ravenous_Hydra.Cast();
                            }
                            break;
                    }
                }
                if (CutlassTarget != null && CutlassTarget.IsValidTarget())
                {
                    if ((Config.Offensive["cbitem"].Cast<CheckBox>().CurrentValue
                        && Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Combo))
                        || !Config.Offensive["cbitem"].Cast<CheckBox>().CurrentValue)
                    {
                        if (Player.Instance.HealthPercent <= Config.Offensive["MyHPT"].Cast<Slider>().CurrentValue
                            && CutlassTarget.HealthPercent <= Config.Offensive["TargetHPT"].Cast<Slider>().CurrentValue)
                        {
                            if (Items.Bilgewater_Cutlass.IsOwned() && Items.Bilgewater_Cutlass.IsReady()) Items.Bilgewater_Cutlass.Cast();
                            if (Items.Blade_Of_The_Ruined_King.IsOwned() && Items.Blade_Of_The_Ruined_King.IsReady()) Items.Blade_Of_The_Ruined_King.Cast();
                        }
                    }
                }
                if (HextechTarget != null && HextechTarget.IsValidTarget())
                {
                    if ((Config.Offensive["cbitem"].Cast<CheckBox>().CurrentValue
                       && Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Combo))
                       || !Config.Offensive["cbitem"].Cast<CheckBox>().CurrentValue)
                    {
                        if (Player.Instance.HealthPercent <= Config.Offensive["MyHPT"].Cast<Slider>().CurrentValue
                            && CutlassTarget.HealthPercent <= Config.Offensive["TargetHPT"].Cast<Slider>().CurrentValue)
                        {
                            if (Items.Hextech_Gunblade.IsOwned() && Items.Hextech_Gunblade.IsReady()) Items.Hextech_Gunblade.Cast();
                        }
                    }
                }
                if (Player.Instance.CountEnemiesInRange(1000) >= 1)
                {
                    if ((Config.Offensive["cbmvitem"].Cast<CheckBox>().CurrentValue
                      && Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Combo))
                      || !Config.Offensive["cbmvitem"].Cast<CheckBox>().CurrentValue)
                    {
                        if (Items.Youmuu_s_Ghostblade.IsOwned() && Items.Youmuu_s_Ghostblade.IsReady()) Items.Youmuu_s_Ghostblade.Cast();
                    }
                }
            }
        }
        public static void OnPostAttack(AttackableUnit target, EventArgs args)
        {
            if (Config.Offensive["styletitanic"].Cast<ComboBox>().CurrentValue == 0)
            {
                switch (Config.Offensive["Tiamat"].Cast<ComboBox>().CurrentValue)
                {
                    case 0:
                        break;
                    case 1:
                        {
                            if (Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Harass))
                            {
                                if (Items.Titanic_Hydra.IsOwned() && Items.Titanic_Hydra.IsReady()) Items.Titanic_Hydra.Cast();
                                Orbwalker.ResetAutoAttack();
                                Player.IssueOrder(GameObjectOrder.AttackTo, target);
                            }
                        }
                        break;
                    case 2:
                        {
                            if (Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Combo))
                            {
                                if (Items.Titanic_Hydra.IsOwned() && Items.Titanic_Hydra.IsReady()) Items.Titanic_Hydra.Cast();
                                Orbwalker.ResetAutoAttack();
                                Player.IssueOrder(GameObjectOrder.AttackTo, target);
                            }
                        }
                        break;
                    case 3:
                        {
                            if (Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Harass) || Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Combo))
                            {
                                if (Items.Titanic_Hydra.IsOwned() && Items.Titanic_Hydra.IsReady()) Items.Titanic_Hydra.Cast();
                                Orbwalker.ResetAutoAttack();
                                Player.IssueOrder(GameObjectOrder.AttackTo, target);
                            }
                        }
                        break;
                    case 4:
                        {
                            if (Items.Titanic_Hydra.IsOwned() && Items.Titanic_Hydra.IsReady()) Items.Titanic_Hydra.Cast();
                            Orbwalker.ResetAutoAttack();
                            Player.IssueOrder(GameObjectOrder.AttackTo, target);
                        }
                        break;
                }
            }
        }
        public static void OnPreAttack(AttackableUnit target, EventArgs args)
        {
            if (Config.Offensive["styletitanic"].Cast<ComboBox>().CurrentValue == 1)
            {
                switch (Config.Offensive["Tiamat"].Cast<ComboBox>().CurrentValue)
                {
                    case 0:
                        break;
                    case 1:
                        {
                            if (Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Harass))
                            {
                                if (Items.Titanic_Hydra.IsOwned() && Items.Titanic_Hydra.IsReady()) Items.Titanic_Hydra.Cast();
                                Orbwalker.ResetAutoAttack();
                                Player.IssueOrder(GameObjectOrder.AttackTo, target);
                            }
                        }
                        break;
                    case 2:
                        {
                            if (Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Combo))
                            {
                                if (Items.Titanic_Hydra.IsOwned() && Items.Titanic_Hydra.IsReady()) Items.Titanic_Hydra.Cast();
                                Orbwalker.ResetAutoAttack();
                                Player.IssueOrder(GameObjectOrder.AttackTo, target);
                            }
                        }
                        break;
                    case 3:
                        {
                            if (Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Harass) || Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Combo))
                            {
                                if (Items.Titanic_Hydra.IsOwned() && Items.Titanic_Hydra.IsReady()) Items.Titanic_Hydra.Cast();
                                Orbwalker.ResetAutoAttack();
                                Player.IssueOrder(GameObjectOrder.AttackTo, target);
                            }
                        }
                        break;
                    case 4:
                        {
                            if (Items.Titanic_Hydra.IsOwned() && Items.Titanic_Hydra.IsReady()) Items.Titanic_Hydra.Cast();
                            Orbwalker.ResetAutoAttack();
                            Player.IssueOrder(GameObjectOrder.AttackTo, target);
                        }
                        break;
                }
            }
        }
    }
}
 