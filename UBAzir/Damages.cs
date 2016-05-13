﻿using System;
using System.Linq;
using EloBuddy;
using EloBuddy.SDK;

namespace UBAzir
{
    class Damages
    {
        // 65 / 85 / 105 / 125 / 145 (+ 50% AP)
        public static float QDamage(Obj_AI_Base target)
        {
            if (!Player.Instance.HasBuff("SummonerExhaust"))
                return Player.Instance.CalculateDamageOnUnit(target, DamageType.Magical, (new[] { 0f, 65f, 85f, 105f, 125f, 145f }[Spells.Q.Level]) + 0.5f * Player.Instance.TotalMagicalDamage);
            else return Player.Instance.CalculateDamageOnUnit(target, DamageType.Magical, ((new[] { 0f, 65f, 85f, 105f, 125f, 145f }[Spells.Q.Level]) + 0.5f * Player.Instance.TotalMagicalDamage) * 0.6f);
        }

        public static float WDamage(Obj_AI_Base target)
        {
            if (!Player.Instance.HasBuff("SummonerExhaust"))
                return Player.Instance.CalculateDamageOnUnit(target, DamageType.Magical, (new[] { 50f, 55f, 60f, 65f, 70f, 75f, 80f, 85f, 90f, 95f, 100f, 110f, 120f, 130f, 140f, 150f, 160f, 170f }[Player.Instance.Level]) + 0.6f * Player.Instance.TotalMagicalDamage, true, true);
            else return Player.Instance.CalculateDamageOnUnit(target, DamageType.Magical, ((new[] { 50f, 55f, 60f, 65f, 70f, 75f, 80f, 85f, 90f, 95f, 100f, 110f, 120f, 130f, 140f, 150f, 160f, 170f }[Player.Instance.Level]) + 0.6f * Player.Instance.TotalMagicalDamage) * 0.6f, true, true);
        }

        public static float EDamage(Obj_AI_Base target)
        {
            if (!Player.Instance.HasBuff("SummonerExhaust"))
                return Player.Instance.CalculateDamageOnUnit(target, DamageType.Magical, (new[] { 0f, 60f, 90f, 120f, 150f, 180f }[Spells.E.Level]) + 0.4f * Player.Instance.TotalMagicalDamage);
            else return Player.Instance.CalculateDamageOnUnit(target, DamageType.Magical,((new[] { 0f, 60f, 90f, 120f, 150f, 180f }[Spells.E.Level]) + 0.4f * Player.Instance.TotalMagicalDamage) * 0.6f);
        }

        public static float RDamage(Obj_AI_Base target)
        {
            if (!Player.Instance.HasBuff("SummonerExhaust"))
                return Player.Instance.CalculateDamageOnUnit(target, DamageType.Magical, (new[] { 0f, 150f, 225f, 300f }[Spells.R.Level]) + 0.6f * Player.Instance.TotalMagicalDamage);
            else return Player.Instance.CalculateDamageOnUnit(target, DamageType.Magical, ((new[] { 0f, 150f, 225f, 300f }[Spells.R.Level]) + 0.6f * Player.Instance.TotalMagicalDamage) * 0.6f);
        }

        public static float Damagefromspell(Obj_AI_Base target, bool Q, bool W, bool E, bool R)
        {
            if (target == null)
            {
                return 0;
            }
            var damage = 0f;
            if (Q)
            {
                damage = damage + QDamage(target);
            }
            if (W)
            {
                damage = damage + WDamage(target);
            }
            if (E)
            {
                damage = damage + EDamage(target);
            }
            if (R)
            {
                damage = damage + RDamage(target);
            }
            return damage;
        }
    }
}