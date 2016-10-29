using EloBuddy;
using EloBuddy.SDK.Spells;

namespace UBEvade.Data.SkillshotsData
{
    public class SpellsData
    {
        public bool AddHitbox;
        public int Angel;
        public bool CanBeRemoved = false;
        public bool CcOrMgDamage = false;
        public bool Centered;
        public string ChampionName;
        public CollisionType[] CollisionObjects = { };
        public int DangerValue;
        public int Delay;
        public bool DefaultDisable = false;
        public bool DisableFowDetection = false;
        public bool DontAddExtraDuration;
        public bool DontCheckForDuplicates = false;
        public bool DontCross = false;
        public bool DontRemove = false;
        public int EndExplosionRadius = 0;
        public int ExtraDuration;
        public string[] ExtraMissileNames = { };
        public int ExtraRange = -1;
        public string[] ExtraSpellNames = { };
        public bool FixedRange;
        public bool ForceRemove = false;
        public bool FollowCaster = false;
        public string FromObject = "";
        public string[] FromObjects = { };
        public int Id = -1;
        public bool Invert;
        public bool IsDangerous = false;
        public string MenuName = "";
        public int MissileAccel = 0;
        public bool MissileDelayed;
        public bool MissileFollowsUnit;
        public int MissileMaxSpeed;
        public int MissileMinSpeed;
        public int MissileSpeed;
        public string MissileSpellName = "";
        public float MultipleAngle;
        public int MultipleNumber = -1;
        public int RingRadius;
        public string SourceObjectName = "";
        public SpellSlot Slot;
        public string SpellName;
        public bool TakeClosestPath = false;
        public string ToggleParticleName = "";
        public SpellType Type;
        private int _radius;
        private int _range;

        public SpellsData() { }

        public SpellsData(string championName,
            string spellName,
            string menuName,
            SpellSlot slot,
            SpellType type,
            int delay,
            int range,
            int radius,
            int missileSpeed,
            bool addHitbox,
            bool fixedRange,
            int dangerValue)
        {
            ChampionName = championName;
            SpellName = spellName;
            MenuName = menuName;
            Slot = slot;
            Type = type;
            Delay = delay;
            Range = range;
            _radius = radius;
            MissileSpeed = missileSpeed;
            AddHitbox = addHitbox;
            FixedRange = fixedRange;
            DangerValue = dangerValue;
        }
        public int Radius
        {
            get
            {
                return (!AddHitbox)
                    ? _radius /*+ Config.SkillShotsExtraRadius*/
                    : /*Config.SkillShotsExtraRadius +*/ _radius + (int)ObjectManager.Player.BoundingRadius;
            }
            set { _radius = value; }
        }

        public int RawRadius
        {
            get { return _radius; }
        }

        public int RawRange
        {
            get { return _range; }
        }

        public int Range
        {
            get
            {
                return _range +
                       ((Type == SpellType.Line || Type == SpellType.MissileLine)
                           ? /*Config.SkillShotsExtraRange*/ 0
                           : 0);
            }
            set { _range = value; }
        }
    }
}

