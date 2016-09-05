using System;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Enumerations;
using SharpDX;

namespace UBSyndra
{
    class Spells
    {
        public static Spell.Skillshot Q { get; private set; }
        public static Spell.Skillshot W { get; private set; }
        public static Spell.Skillshot E { get; private set; }
        public static Spell.Skillshot QE { get; private set; }
        public static Spell.Targeted R { get; private set; }

        public static void InitSpells()
        {
            Q = new Spell.Skillshot(SpellSlot.Q, 800, SkillShotType.Circular, 600, int.MaxValue, 125);

            W = new Spell.Skillshot(SpellSlot.W, 950, SkillShotType.Circular, 350, 1600, 140);

            E = new Spell.Skillshot(SpellSlot.E, 700, SkillShotType.Cone, 250, 2500, 22);

            R = new Spell.Targeted(SpellSlot.R, 675);

            QE = new Spell.Skillshot(SpellSlot.E, 1200, SkillShotType.Linear, 500, 2500, 55);
        }
        public static void UpdateSpells(EventArgs args)
        {
            if (R.Level == 3 && R.Range == 675)
            {
                R = new Spell.Targeted(SpellSlot.R, 750);
            }
        }
        public static void CastQ(PredictionResult pred)
        {
            if (Q.IsReady())
            {
                Q.Cast(pred.CastPosition);
            }
        }
        public static void Grab()
        {
            var spell = Player.GetSpell(SpellSlot.W).ToggleState;
            if (W.IsReady() && spell == 1 && BallManager.Get_Grab_Shit() != null)
            {
                W.Cast(BallManager.Get_Grab_Shit());
            }
        }
        public static void CastW(PredictionResult pred)
        {
            var spell = Player.GetSpell(SpellSlot.W).ToggleState;
            if (W.IsReady() && spell == 2)
            {
                W.Cast(pred.CastPosition);
            }
        }
        public static void CastE(PredictionResult pred)
        {
            if (E.IsReady())
            {
                E.Cast(pred.CastPosition);
            }
        }
        public static void ComboEQ()
        {
            var target = TargetSelector.GetTarget(Spells.QE.Range, DamageType.Magical);
            if (target != null && Q.IsReady())
            {
                Extension.QEcomboing = true;
                var pred = QE.GetPrediction(target);
                if (Q.IsInRange(pred.UnitPosition))
                {
                    Q.Cast(pred.CastPosition);
                }
                else
                {
                    Q.Cast(Player.Instance.Position.Extend(pred.CastPosition, Spells.Q.Range - 50f).To3D());
                }
            }
        }
        public static void Obj_AI_Base_OnProcessSpellCast(Obj_AI_Base sender, GameObjectProcessSpellCastEventArgs args)
        {
            if (!sender.IsMe) return;
            if (args.Slot == SpellSlot.Q && Extension.QEcomboing)
            {
                Spells.E.Cast(args.End);
            }
            if (args.Slot == SpellSlot.E)
            {
                Extension.QEcomboing = false;
            }
        }
    }
}
