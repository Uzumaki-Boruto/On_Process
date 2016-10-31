using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EloBuddy.SDK.Enumerations;
using EloBuddy;

namespace UBEvade.Data.EvadeSkillsData
{
    public enum SpellTargets
    {
        AllyMinions,
        EnemyMinions,

        AllyWards,
        EnemyWards,

        AllyChampions,
        EnemyChampions,

        AllySandSoldier,
        MySelf,
    }
    public enum EvadeType
    {
        Blink,
        Dash,
        SpellShield,
        Shield,
        ShieldSkillShot,
        Wall,
        Unselectable,
        MovementSpeedBuff
    }
    internal class EvadeSpellData
    {
        public delegate float PercentMvmBuff();

        public bool Active;
        public bool CanCastAllies;
        public int DashSpeed;
        public int CastWidth;
        public int DangerValue;
        public bool DefautDisable;
        public int DelayRiposte;
        public int Delay;
        public bool FixedRange;
        public bool Invert;
        public ItemId ItemId;
        public EvadeType Type;
        public bool IsSummonerSpell;
        public bool MagicShieldOnly;
        public float MaxRange;
        public string Name;
        public bool NeedUnitAround;
        public string OtherName;
        public string Object;
        public PercentMvmBuff PercentMovementBuff;
        public bool RequiresPreMove;
        public string RequiresPlayerBuff;
        public string RequiresTargetBuff;
        public SpellSlot Slot;
        public SpellTargets[] ValidTargets;

        public EvadeSpellData() { }

        public EvadeSpellData(string name, int dangerLevel)
        {
            Name = name;
            DangerValue = dangerLevel;
        }

        public bool IsTargetted
        {
            get { return ValidTargets != null; }
        }
        public float RawMovementSpeed
        {
            get { return Player.Instance.MoveSpeed + Player.Instance.MoveSpeed * PercentMovementBuff.Invoke(); }
        }
        public float CappedMovementSpeed
        {
            get
            {
                if (RawMovementSpeed <= 415)
                {
                    return RawMovementSpeed;
                }
                else if (RawMovementSpeed <= 490)
                {
                    return 415 + (RawMovementSpeed - 415) * 0.8f;
                }
                else
                {
                    return 415 + 60 + (RawMovementSpeed - 490) * 0.5f;
                }
            }
        }

    }

    internal class Dash : EvadeSpellData
    {
        public Dash(string name, SpellSlot slot, float range, bool fixedRange, int delay, int speed, int dangervalue)
        {
            Name = name;
            MaxRange = range;
            Slot = slot;
            FixedRange = fixedRange;
            Delay = delay;
            DashSpeed = speed;
            DangerValue = dangervalue;
            Type = EvadeType.Dash;
        }
    }

    internal class Blink : EvadeSpellData
    {
        public Blink(string name,
            SpellSlot slot,
            float range,
            int delay,
            int dangervalue,
            bool isSummonerSpell = false)
        {
            Name = name;
            MaxRange = range;
            Slot = slot;
            Delay = delay;
            DangerValue = dangervalue;
            IsSummonerSpell = isSummonerSpell;
            Type = EvadeType.Blink;
        }
    }

    internal class UnSelectable : EvadeSpellData
    {
        public UnSelectable(string name, SpellSlot slot, float range, int delay, int dangervalue)
        {
            Name = name;
            Slot = slot;
            MaxRange = range;
            Delay = delay;
            DangerValue = dangervalue;
            Type = EvadeType.Unselectable;
        }
    }

    internal class Shield : EvadeSpellData
    {
        public Shield(string name, SpellSlot slot, int delay, int dangervalue, bool isSpellShield = false)
        {
            Name = name;
            Slot = slot;
            Delay = delay;
            DangerValue = dangervalue;
            Active = !CanCastAllies;
            Type = isSpellShield ? EvadeType.SpellShield : EvadeType.Shield;
        }
    }

    internal class MovementBuff : EvadeSpellData
    {
        public MovementBuff(string name, SpellSlot slot, int delay, int dangervalue, PercentMvmBuff amount)
        {
            Name = name;
            Slot = slot;
            Delay = delay;
            DangerValue = dangervalue;
            PercentMovementBuff = amount;
            Active = !CanCastAllies;
            Type = EvadeType.MovementSpeedBuff;
        }
    }

    internal class Wall : EvadeSpellData
    {
        public Wall(string name, SpellSlot slot, int delay, int dangervalue)
        {
            Name = name;
            Slot = slot;
            Delay = delay;
            DangerValue = dangervalue;
            Type = EvadeType.Wall;
        }
    }
}
