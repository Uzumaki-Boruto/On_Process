using System;
using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using SharpDX;

namespace UBBard
{
    class Damage
    {
        public static float PassiveDamage(Obj_AI_Base target)
        {
            if (Orbwalker.CanAutoAttack)
                return Player.Instance.CalculateDamageOnUnit(target, DamageType.Mixed, Player.Instance.TotalAttackDamage + 30f);
            else
                return 0f;
        }
        public static float QDamage(Obj_AI_Base target)
        {
            if (Spells.Q.IsReady())
                return Player.Instance.CalculateDamageOnUnit(target, DamageType.Magical, new[] { 0f, 80f, 125f, 170f, 215f, 260f }[Spells.Q.Level] + 0.65f * Player.Instance.TotalMagicalDamage);
            else
                return 0f;
        }
        public static float Damagefromspell(Obj_AI_Base target)
        {
            if (target == null)
            {
                return 0f;
            }
            else
            {
                return PassiveDamage(target) + QDamage(target);
            }
        }
        public static void Damage_Indicator(EventArgs args)
        {
            if (Config.DrawMenu.Checked("dmg") && Config.DrawMenu.Checked("draw"))
            {
                foreach (var unit in EntityManager.Heroes.Enemies.Where(u => u.IsValidTarget() && u.IsHPBarRendered)
                    )
                {

                    var damage = Damagefromspell(unit);

                    if (damage <= 0)
                    {
                        continue;
                    }
                    var Special_X = unit.ChampionName == "Jhin" || unit.ChampionName == "Annie" ? -12 : 0;
                    var Special_Y = unit.ChampionName == "Jhin" || unit.ChampionName == "Annie" ? -3 : 9;

                    var DamagePercent = ((unit.TotalShieldHealth() - damage) > 0
                        ? (unit.TotalShieldHealth() - damage)
                        : 0) / (unit.MaxHealth + unit.AllShield + unit.AttackShield + unit.MagicShield);
                    var currentHealthPercent = unit.TotalShieldHealth() / (unit.MaxHealth + unit.AllShield + unit.AttackShield + unit.MagicShield);

                    var StartPoint = new Vector2((int)(unit.HPBarPosition.X + Special_X + DamagePercent * 107) + 1,
                        (int)unit.HPBarPosition.Y + Special_Y);
                    var EndPoint = new Vector2((int)(unit.HPBarPosition.X + Special_X + currentHealthPercent * 107) + 1,
                        (int)unit.HPBarPosition.Y + Special_Y);
                    var Color = Config.DrawMenu["Color"].Cast<ColorPicker>().CurrentValue;
                    Drawing.DrawLine(StartPoint, EndPoint, 9.82f, Color);
                }
            }
        }
    }
}
