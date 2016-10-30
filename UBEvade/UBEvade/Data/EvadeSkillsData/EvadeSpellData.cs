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
        public delegate float MovementSpeedAmount();

        public bool CanShieldAllies;
        public int CastWidth;
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
        public MovementSpeedAmount MovementSpeedTotalAmount;
        public string Name;
        public bool NeedUnitAround;
        public string OtherName;
        public string Object;
        public bool RequiresPreMove;
        public bool Active;
        public SpellSlot Slot;

        public int Speed;
        public SpellTargets[] ValidTargets;

        public int _dangerLevel;

        public EvadeSpellData() { }

        public EvadeSpellData(string name, int dangerLevel)
        {
            Name = name;
            _dangerLevel = dangerLevel;
        }

        public bool IsTargetted
        {
            get { return ValidTargets != null; }
        }       
    }

    internal class Dash : EvadeSpellData
    {
        public Dash(string name, SpellSlot slot, float range, bool fixedRange, int delay, int speed, int dangerLevel)
        {
            Name = name;
            MaxRange = range;
            Slot = slot;
            FixedRange = fixedRange;
            Delay = delay;
            Speed = speed;
            _dangerLevel = dangerLevel;
            Type = EvadeType.Dash;
        }
    }

    internal class Blink : EvadeSpellData
    {
        public Blink(string name,
            SpellSlot slot,
            float range,
            int delay,
            int dangerLevel,
            bool isSummonerSpell = false)
        {
            Name = name;
            MaxRange = range;
            Slot = slot;
            Delay = delay;
            _dangerLevel = dangerLevel;
            IsSummonerSpell = isSummonerSpell;
            Type = EvadeType.Blink;
        }
    }

    internal class UnSelectable : EvadeSpellData
    {
        public UnSelectable(string name, SpellSlot slot, float range, int delay, int dangerLevel)
        {
            Name = name;
            Slot = slot;
            MaxRange = range;
            Delay = delay;
            _dangerLevel = dangerLevel;
            Type = EvadeType.Unselectable;
        }
    }

    internal class Shield : EvadeSpellData
    {
        public Shield(string name, SpellSlot slot, int delay, int dangerLevel, bool isSpellShield = false)
        {
            Name = name;
            Slot = slot;
            Delay = delay;
            _dangerLevel = dangerLevel;
            Type = isSpellShield ? EvadeType.SpellShield : EvadeType.Shield;
        }
    }

    internal class MovementBuff : EvadeSpellData
    {
        public MovementBuff(string name, SpellSlot slot, int delay, int dangerLevel, MovementSpeedAmount amount)
        {
            Name = name;
            Slot = slot;
            Delay = delay;
            _dangerLevel = dangerLevel;
            MovementSpeedTotalAmount = amount;
            Type = EvadeType.MovementSpeedBuff;
        }
    }

    internal class Wall : EvadeSpellData
    {
        public Wall(string name, SpellSlot slot, int delay, int dangerLevel)
        {
            Name = name;
            Slot = slot;
            Delay = delay;
            _dangerLevel = dangerLevel;
            Type = EvadeType.Wall;
        }
    }
}
