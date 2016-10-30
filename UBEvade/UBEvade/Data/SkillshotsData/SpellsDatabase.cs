using System;
using System.Collections.Generic;
using EloBuddy;
using EloBuddy.SDK.Spells;

namespace UBEvade.Data.SkillshotsData
{
public static class SpellsDatabase
    {
        public static List<SpellsData> Spells = new List<SpellsData>();

        static SpellsDatabase()
        {
            #region Poro Throw

            Spells.Add(
            new SpellsData
            {
                ChampionName = "AllChampions",
                SpellName = "summonersnowball",
                MenuName = "Poro Throw",
                Slot = SpellSlot.Summoner1,
                Type = SpellType.MissileLine,
                Delay = 0,
                Range = 1600,
                Radius = 60,
                MissileSpeed = 1300,
                FixedRange = false,
                AddHitbox = true,
                DangerValue = 3,
                IsDangerous = true,
                MissileSpellName = "SummonerSnowball",
                CanBeRemoved = false,
                CollisionObjects = new[] { CollisionType.AiHeroClient, CollisionType.ObjAiMinion },
                ExtraSpellNames = new[] { "summonerporothrow", },
            });

            #endregion AllChampions

            #region Aatrox

            Spells.Add(
                new SpellsData
                {
                    ChampionName = "Aatrox",
                    SpellName = "AatroxQ",
                    MenuName = "Aatrox Q",
                    Slot = SpellSlot.Q,
                    Type = SpellType.Circular,
                    Delay = 600,
                    Range = 650,
                    Radius = 250,
                    MissileSpeed = 2000,
                    FixedRange = false,
                    AddHitbox = true,
                    DangerValue = 3,
                    IsDangerous = true,
                    MissileSpellName = "",
                    CcOrMgDamage = true,
                });

            Spells.Add(
                new SpellsData
                {
                    ChampionName = "Aatrox",
                    SpellName = "AatroxE",
                    MenuName = "Aatrox E",
                    Slot = SpellSlot.E,
                    Type = SpellType.MissileLine,
                    Delay = 250,
                    Range = 1075,
                    Radius = 35,
                    MissileSpeed = 1250,
                    FixedRange = true,
                    AddHitbox = true,
                    DangerValue = 2,
                    IsDangerous = false,
                    MissileSpellName = "AatroxEConeMissile",
                });

            #endregion Aatrox

            #region Ahri

            Spells.Add(
                new SpellsData
                {
                    ChampionName = "Ahri",
                    SpellName = "AhriOrbofDeception",
                    MenuName = "Ahri Q",
                    Slot = SpellSlot.Q,
                    Type = SpellType.MissileLine,
                    Delay = 250,
                    Range = 1000,
                    Radius = 100,
                    MissileSpeed = 2500,
                    MissileAccel = -3200,
                    MissileMaxSpeed = 2500,
                    MissileMinSpeed = 400,
                    FixedRange = true,
                    AddHitbox = true,
                    DangerValue = 2,
                    IsDangerous = false,
                    MissileSpellName = "AhriOrbMissile",
                    CanBeRemoved = false,
                    ForceRemove = true,
                    CcOrMgDamage = true,
                    CollisionObjects = new[] { CollisionType.YasuoWall }
                });

            Spells.Add(
                new SpellsData
                {
                    ChampionName = "Ahri",
                    SpellName = "AhriOrbReturn",
                    MenuName = "Ahri Q Return",
                    Slot = SpellSlot.Q,
                    Type = SpellType.MissileLine,
                    Delay = 250,
                    Range = 1000,
                    Radius = 100,
                    MissileSpeed = 60,
                    MissileAccel = 1900,
                    MissileMinSpeed = 60,
                    MissileMaxSpeed = 2600,
                    FixedRange = true,
                    AddHitbox = true,
                    DangerValue = 2,
                    IsDangerous = false,
                    MissileFollowsUnit = true,
                    CanBeRemoved = false,
                    ForceRemove = true,
                    MissileSpellName = "AhriOrbReturn",
                    CcOrMgDamage = true,
                    CollisionObjects = new[] { CollisionType.YasuoWall }
                });

            Spells.Add(
                new SpellsData
                {
                    ChampionName = "Ahri",
                    SpellName = "AhriSeduce",
                    MenuName = "Ahri E",
                    Slot = SpellSlot.E,
                    Type = SpellType.MissileLine,
                    Delay = 250,
                    Range = 1000,
                    Radius = 60,
                    MissileSpeed = 1550,
                    FixedRange = true,
                    AddHitbox = true,
                    DangerValue = 3,
                    IsDangerous = true,
                    MissileSpellName = "AhriSeduceMissile",
                    CanBeRemoved = false,
                    CcOrMgDamage = true,
                    CollisionObjects = new[] { CollisionType.AiHeroClient, CollisionType.ObjAiMinion, CollisionType.YasuoWall }
                });

            #endregion Ahri

            //Alistar
            #region Alistar

            Spells.Add(
                new SpellsData
                {
                ChampionName = "Alistar",
                SpellName = "Pulverize",
                MenuName = "Alistar Q",
                Slot = SpellSlot.Q,
                Type = SpellType.Circular,
                Delay = 400,
                Range = 0,
                Radius = 365,
                MissileSpeed = int.MaxValue,
                DangerValue = 3,
                FixedRange = true,
                AddHitbox = false,
                IsDangerous = true,
                CanBeRemoved = false,
                CcOrMgDamage = true,
                });

            Spells.Add(
                new SpellsData
                {
                    ChampionName = "Alistar",
                    SpellName = "Headbutt",
                    MenuName = "Alistar W",
                    Slot = SpellSlot.W,
                    Type = SpellType.Targeted,
                    Delay = 250,
                    Range = 650,
                    DangerValue = 2,
                    IsDangerous = false,
                    CcOrMgDamage = true,
                });
            #endregion Alistar

            #region Amumu

            Spells.Add(
                new SpellsData
                {
                    ChampionName = "Amumu",
                    SpellName = "BandageToss",
                    MenuName = "Amumu Q",
                    Slot = SpellSlot.Q,
                    Type = SpellType.MissileLine,
                    Delay = 250,
                    Range = 1100,
                    Radius = 90,
                    MissileSpeed = 2000,
                    FixedRange = true,
                    AddHitbox = true,
                    DangerValue = 4,
                    IsDangerous = true,
                    MissileSpellName = "SadMummyBandageToss",
                    CanBeRemoved = false,
                    CcOrMgDamage = true,
                    CollisionObjects = new[] { CollisionType.AiHeroClient, CollisionType.ObjAiMinion, CollisionType.YasuoWall }
                });

            Spells.Add(
                new SpellsData
                {
                    ChampionName = "Amumu",
                    SpellName = "CurseoftheSadMummy",
                    MenuName = "Amumu R",
                    Slot = SpellSlot.R,
                    Type = SpellType.Circular,
                    Delay = 250,
                    Range = 0,
                    Radius = 550,
                    MissileSpeed = int.MaxValue,
                    FixedRange = true,
                    AddHitbox = false,
                    DangerValue = 5,
                    CcOrMgDamage = true,
                    IsDangerous = true,
                });
            #endregion Amumu

            #region Anivia

            Spells.Add(
                new SpellsData
                {
                    ChampionName = "Anivia",
                    SpellName = "FlashFrost",
                    Slot = SpellSlot.Q,
                    Type = SpellType.MissileLine,
                    Delay = 250,
                    Range = 1100,
                    Radius = 110,
                    MissileSpeed = 850,
                    FixedRange = true,
                    AddHitbox = true,
                    DangerValue = 3,
                    IsDangerous = true,
                    MissileSpellName = "FlashFrostSpell",
                    CanBeRemoved = false,
                    CcOrMgDamage = true,
                    CollisionObjects = new[] { CollisionType.YasuoWall }
                });
            #endregion Anivia

            #region Annie

            Spells.Add(
                new SpellsData
                {
                    ChampionName = "Annie",
                    SpellName = "Incinerate",
                    MenuName = "Annie W",
                    Slot = SpellSlot.W,
                    Type = SpellType.Cone,
                    Delay = 250,
                    Range = 825,
                    Angel = 50,
                    Radius = 80,
                    MissileSpeed = int.MaxValue,
                    FixedRange = false,
                    AddHitbox = false,
                    DangerValue = 2,
                    IsDangerous = false,
                    MissileSpellName = "",
                    CcOrMgDamage = true,
                });

            Spells.Add(
                new SpellsData
                {
                    ChampionName = "Annie",
                    SpellName = "InfernalGuardian",
                    MenuName = "Annie R",
                    Slot = SpellSlot.R,
                    Type = SpellType.Circular,
                    Delay = 250,
                    Range = 600,
                    Radius = 251,
                    MissileSpeed = int.MaxValue,
                    FixedRange = false,
                    AddHitbox = true,
                    DangerValue = 5,
                    IsDangerous = true,
                    MissileSpellName = "",
                });

            #endregion Annie

            #region Ashe

            Spells.Add(
                new SpellsData
                {
                    ChampionName = "Ashe",
                    SpellName = "Volley",
                    MenuName = "Ashe W",
                    Slot = SpellSlot.W,
                    Type = SpellType.MissileLine,
                    Delay = 250,
                    Range = 1250,
                    Radius = 60,
                    MissileSpeed = 1500,
                    FixedRange = true,
                    AddHitbox = true,
                    DangerValue = 2,
                    IsDangerous = false,
                    MissileSpellName = "VolleyAttack",
                    MultipleNumber = 9,
                    MultipleAngle = 4.62f * (float)Math.PI / 180,
                    CanBeRemoved = false,
                    CollisionObjects = new[] { CollisionType.AiHeroClient, CollisionType.ObjAiMinion, CollisionType.YasuoWall }
                });

            Spells.Add(
                new SpellsData
                {
                    ChampionName = "Ashe",
                    SpellName = "EnchantedCrystalArrow",
                    MenuName = "Ashe R",
                    Slot = SpellSlot.R,
                    Type = SpellType.MissileLine,
                    Delay = 250,
                    Range = 20000,
                    Radius = 130,
                    MissileSpeed = 1600,
                    FixedRange = true,
                    AddHitbox = true,
                    DangerValue = 5,
                    IsDangerous = true,
                    MissileSpellName = "EnchantedCrystalArrow",
                    CanBeRemoved = false,
                    CcOrMgDamage = true,
                    CollisionObjects = new[] { CollisionType.AiHeroClient, CollisionType.YasuoWall }
                });
            #endregion Ashe

            //Azir
            #region Azir

            //Spells.Add(
            //new SpellsData
            //{
            //    ChampName = "Azir",
            //    Dangerlevel = SpellDangerLevel.Low,
            //    MissileName = "azirsoldiermissile",
            //    Name = "Conquering Sands",
            //    ProjectileSpeed = 1000,
            //    Radius = 80,
            //    Range = 800,
            //    SpellDelay = 250,
            //    SpellKey = SpellSlot.Q,
            //    SpellName = "AzirQ",
            //    SpellType = SpellType.Line,
            //    UsePackets = true,
            //    IsSpecial = true,
            //    CollisionObjects = new[] { CollisionObjectType.YasuoWindWall },
            //    CollisionCount = int.MaxValue,
            //    IsDangerous = false,
            //    IsHardCrownControl = false,

            //});

            //Spells.Add(
            //new SpellsData
            //{
            //    ChampName = "Azir",
            //    Dangerlevel = SpellDangerLevel.High,
            //    MissileName = "azirsoldiermissile",
            //    Name = "Devide",
            //    ProjectileSpeed = 1000,
            //    Radius = 80,
            //    Range = 800,
            //    SpellDelay = 250,
            //    SpellKey = SpellSlot.R,
            //    SpellName = "AzirR",
            //    SpellType = SpellType.Line,
            //    IsDangerous = true,
            //    IsHardCrownControl = true,

            //});
            #endregion Azir

            #region Bard

            Spells.Add(
                new SpellsData
                {
                    ChampionName = "Bard",
                    SpellName = "BardQ",
                    MenuName = "Bard Q",
                    Slot = SpellSlot.Q,
                    Type = SpellType.MissileLine,
                    Delay = 250,
                    Range = 950,
                    Radius = 60,
                    MissileSpeed = 1600,
                    FixedRange = true,
                    AddHitbox = true,
                    DangerValue = 3,
                    IsDangerous = true,
                    MissileSpellName = "BardQMissile",
                    CanBeRemoved = false,
                    CcOrMgDamage = true,
                    CollisionObjects = new[] { CollisionType.AiHeroClient, CollisionType.YasuoWall }
                });

            Spells.Add(
                new SpellsData
                {
                    ChampionName = "Bard",
                    SpellName = "BardR",
                    MenuName = "Bard R",
                    Slot = SpellSlot.R,
                    Type = SpellType.Circular,
                    Delay = 500,
                    Range = 3400,
                    Radius = 350,
                    MissileSpeed = 2100,
                    FixedRange = false,
                    AddHitbox = true,
                    DangerValue = 3,
                    IsDangerous = true,
                    MissileSpellName = "BardR",
                });

            #endregion Bard

            #region Blitzcrank

            Spells.Add(
                new SpellsData
                {
                    ChampionName = "Blitzcrank",
                    SpellName = "RocketGrab",
                    MenuName = "Blitzcrank Q",
                    Slot = SpellSlot.Q,
                    Type = SpellType.MissileLine,
                    Delay = 250,
                    Range = 1050,
                    Radius = 70,
                    MissileSpeed = 1800,
                    FixedRange = true,
                    AddHitbox = true,
                    DangerValue = 4,
                    IsDangerous = true,
                    MissileSpellName = "RocketGrabMissile",
                    CanBeRemoved = false,
                    CcOrMgDamage = true,
                    CollisionObjects = new[] { CollisionType.AiHeroClient, CollisionType.ObjAiMinion, CollisionType.YasuoWall }
                });

            Spells.Add(
                new SpellsData
                {
                    ChampionName = "Blitzcrank",
                    SpellName = "StaticField",
                    MenuName = "Blitzcrank R",
                    Slot = SpellSlot.R,
                    Type = SpellType.Circular,
                    Delay = 250,
                    Range = 0,
                    Radius = 600,
                    MissileSpeed = int.MaxValue,
                    FixedRange = true,
                    AddHitbox = false,
                    DangerValue = 2,
                    IsDangerous = false,
                    CcOrMgDamage = true,
                    MissileSpellName = "",
                });
            #endregion Blitzcrank

            #region Brand

            Spells.Add(
                new SpellsData
                {
                    ChampionName = "Brand",
                    SpellName = "BrandQ",
                    Slot = SpellSlot.Q,
                    Type = SpellType.MissileLine,
                    Delay = 250,
                    Range = 1100,
                    Radius = 60,
                    MissileSpeed = 1600,
                    FixedRange = true,
                    AddHitbox = true,
                    DangerValue = 3,
                    IsDangerous = true,
                    MissileSpellName = "BrandQMissile",
                    CanBeRemoved = false,
                    CcOrMgDamage = true,
                    CollisionObjects = new[] { CollisionType.AiHeroClient, CollisionType.ObjAiMinion, CollisionType.YasuoWall }
                });

            Spells.Add(
                new SpellsData
                {
                    ChampionName = "Brand",
                    SpellName = "BrandW",
                    Slot = SpellSlot.W,
                    Type = SpellType.Circular,
                    Delay = 850,
                    Range = 900,
                    Radius = 260,
                    MissileSpeed = int.MaxValue,
                    FixedRange = false,
                    AddHitbox = false,
                    DangerValue = 2,
                    IsDangerous = false,
                    CanBeRemoved = false,
                    CcOrMgDamage = true,
                    MissileSpellName = "",
                });
            #endregion Brand

            #region Braum

            Spells.Add(
                new SpellsData
                {
                    ChampionName = "Braum",
                    SpellName = "BraumQ",
                    MenuName = "Braum Q",
                    Slot = SpellSlot.Q,
                    Type = SpellType.MissileLine,
                    Delay = 250,
                    Range = 1050,
                    Radius = 60,
                    MissileSpeed = 1700,
                    FixedRange = true,
                    AddHitbox = true,
                    DangerValue = 3,
                    IsDangerous = true,
                    MissileSpellName = "BraumQMissile",
                    CanBeRemoved = false,
                    CcOrMgDamage = true,
                    CollisionObjects = new[] { CollisionType.AiHeroClient, CollisionType.ObjAiMinion, CollisionType.YasuoWall }
                });

            Spells.Add(
                new SpellsData
                {
                    ChampionName = "Braum",
                    SpellName = "BraumRWrapper",
                    MenuName = "Braum R",
                    Slot = SpellSlot.R,
                    Type = SpellType.MissileLine,
                    Delay = 500,
                    Range = 1200,
                    Radius = 115,
                    MissileSpeed = 1400,
                    FixedRange = true,
                    AddHitbox = true,
                    DangerValue = 4,
                    IsDangerous = true,
                    MissileSpellName = "braumrmissile",
                    CcOrMgDamage = true,
                    CollisionObjects = new[] { CollisionType.YasuoWall }
                });
            #endregion Braum

            //Caitlyn
            #region Caitlyn

            Spells.Add(
                new SpellsData
                {
                    ChampionName = "Caitlyn",
                    SpellName = "CaitlynPiltoverPeacemaker",
                    MenuName = "Caitlyn Q",
                    Slot = SpellSlot.Q,
                    Type = SpellType.MissileLine,
                    Delay = 625,
                    Range = 1300,
                    Radius = 90,
                    MissileSpeed = 2200,
                    FixedRange = true,
                    AddHitbox = true,
                    DangerValue = 1,
                    IsDangerous = false,
                    MissileSpellName = "CaitlynPiltoverPeacemaker",
                    CcOrMgDamage = false,
                    CollisionObjects = new[] { CollisionType.YasuoWall }
                });

            Spells.Add(
                new SpellsData
                {
                    ChampionName = "Caitlyn",
                    SpellName = "CaitlynEntrapment",
                    MenuName = "Caitlyn E",
                    Slot = SpellSlot.E,
                    Type = SpellType.MissileLine,
                    Delay = 125,
                    Range = 1000,
                    Radius = 70,
                    MissileSpeed = 1600,
                    FixedRange = true,
                    AddHitbox = true,
                    DangerValue = 2,
                    IsDangerous = false,
                    MissileSpellName = "CaitlynEntrapmentMissile",
                    CanBeRemoved = false,
                    CcOrMgDamage = true,
                    CollisionObjects = new[] { CollisionType.AiHeroClient, CollisionType.ObjAiMinion, CollisionType.YasuoWall }
                });
            #endregion Caitlyn

            #region Cassiopeia

            Spells.Add(
                 new SpellsData
                 {
                     ChampionName = "Cassiopeia",
                     SpellName = "CassiopeiaQ",
                     MenuName = "Cassiopeia Q",
                     Slot = SpellSlot.Q,
                     Type = SpellType.Circular,
                     Delay = 750,
                     Range = 850,
                     Radius = 150,
                     MissileSpeed = int.MaxValue,
                     FixedRange = false,
                     AddHitbox = true,
                     DangerValue = 2,
                     IsDangerous = false,
                     CcOrMgDamage = true,
                     MissileSpellName = "CassiopeiaQ",
                 });

            Spells.Add(
                new SpellsData
                {
                    ChampionName = "Cassiopeia",
                    SpellName = "CassiopeiaW",
                    MenuName = "Cassiopeia W",
                    Slot = SpellSlot.W,
                    Type = SpellType.Circular,
                    Delay = 350,
                    Range = 1000,
                    Radius = 170,
                    MissileSpeed = int.MaxValue,
                    FixedRange = false,
                    AddHitbox = true,
                    DangerValue = 3,
                    IsDangerous = false,
                    CcOrMgDamage = true,
                    MissileSpellName = "CassiopeiaWMissile",
                    ExtraDuration = 5200,
                    DontCross = true,
                });


            Spells.Add(
                new SpellsData
                {
                    ChampionName = "Cassiopeia",
                    SpellName = "CassiopeiaR",
                    MenuName = "Cassiopeia R",
                    Slot = SpellSlot.R,
                    Type = SpellType.Cone,
                    Delay = 600,
                    Range = 825,
                    Angel = 65,
                    Radius = 80,
                    MissileSpeed = int.MaxValue,
                    FixedRange = false,
                    AddHitbox = false,
                    DangerValue = 5,
                    IsDangerous = true,
                    MissileSpellName = "CassiopeiaR",
                });
            #endregion Cassiopeia

            //Chogath
            #region Chogath

            Spells.Add(
                new SpellsData
                {
                    ChampionName = "Chogath",
                    SpellName = "Rupture",
                    MenuName = "Chogath Q",
                    Slot = SpellSlot.Q,
                    Type = SpellType.Circular,
                    Delay = 1200,
                    Range = 950,
                    Radius = 250,
                    MissileSpeed = int.MaxValue,
                    FixedRange = false,
                    AddHitbox = true,
                    DangerValue = 3,
                    IsDangerous = false,
                    CanBeRemoved = false,
                    CcOrMgDamage = true,
                    MissileSpellName = "Rupture",
                });

            Spells.Add(
                new SpellsData
                {
                    ChampionName = "Chogath",
                    SpellName = "FeralScream",
                    MenuName = "Chogath W",
                    Slot = SpellSlot.W,
                    Type = SpellType.Cone,
                    Delay = 250,
                    Angel = 30,
                    Radius = 20,
                    Range = 650,
                    MissileSpeed = int.MaxValue,
                    FixedRange = false,
                    AddHitbox = true,
                    DangerValue = 2,
                    IsDangerous = false,
                    CcOrMgDamage = true,
                    MissileSpellName = "FeralScream"

                });
            #endregion Chogath

            #region Corki

            Spells.Add(
                new SpellsData
                {
                    ChampionName = "Corki",
                    SpellName = "PhosphorusBomb",
                    MenuName = "Corki Q",
                    Slot = SpellSlot.Q,
                    Type = SpellType.Circular,
                    Delay = 300,
                    Range = 825,
                    Radius = 250,
                    MissileSpeed = 1000,
                    FixedRange = false,
                    AddHitbox = true,
                    DangerValue = 2,
                    IsDangerous = false,
                    CcOrMgDamage = true,
                    MissileSpellName = "PhosphorusBombMissile",
                    CollisionObjects = new[] { CollisionType.YasuoWall }
                });

            Spells.Add(
                new SpellsData
                {
                    ChampionName = "Corki",
                    SpellName = "MissileBarrage",
                    MenuName = "Corki R",
                    Slot = SpellSlot.R,
                    Type = SpellType.MissileLine,
                    Delay = 200,
                    Range = 1300,
                    Radius = 40,
                    MissileSpeed = 2000,
                    FixedRange = true,
                    AddHitbox = true,
                    DangerValue = 2,
                    IsDangerous = false,
                    CcOrMgDamage = true,
                    MissileSpellName = "MissileBarrageMissile",
                    CanBeRemoved = false,
                    CollisionObjects = new[] { CollisionType.AiHeroClient, CollisionType.ObjAiMinion, CollisionType.YasuoWall }
                });

            Spells.Add(
                new SpellsData
                {
                    ChampionName = "Corki",
                    SpellName = "MissileBarrage2",
                    MenuName = "Corki R Powered",
                    Slot = SpellSlot.R,
                    Type = SpellType.MissileLine,
                    Delay = 200,
                    Range = 1500,
                    Radius = 40,
                    MissileSpeed = 2000,
                    FixedRange = true,
                    AddHitbox = true,
                    DangerValue = 2,
                    IsDangerous = false,
                    CcOrMgDamage = true,
                    MissileSpellName = "MissileBarrageMissile2",
                    CanBeRemoved = false,
                    CollisionObjects = new[] { CollisionType.AiHeroClient, CollisionType.ObjAiMinion, CollisionType.YasuoWall }
                });
            #endregion Corki

            //Darius
            #region Darius

            Spells.Add(
                new SpellsData
                {
                    ChampionName = "Darius",
                    SpellName = "DariusCleave",
                    MenuName = "Darius Q",
                    Slot = SpellSlot.Q,
                    Type = SpellType.Circular,
                    Delay = 750,
                    Range = 0,
                    Radius = 375,
                    MissileSpeed = int.MaxValue,
                    FixedRange = true,
                    AddHitbox = true,
                    DangerValue = 2,
                    IsDangerous = false,
                    CcOrMgDamage = false,
                    MissileSpellName = "DariusCleave",
                    FollowCaster = true,
                    DefaultDisable = true,
                });

            Spells.Add(
                new SpellsData
                {
                    ChampionName = "Darius",
                    SpellName = "DariusAxeGrabCone",
                    MenuName = "Darius E",
                    Slot = SpellSlot.E,
                    Type = SpellType.Cone,
                    Delay = 250,
                    Range = 550,
                    Angel = 25,
                    Radius = 80,
                    MissileSpeed = int.MaxValue,
                    FixedRange = true,
                    AddHitbox = false,
                    DangerValue = 3,
                    IsDangerous = true,
                    CcOrMgDamage = true,
                    MissileSpellName = "DariusAxeGrabCone",
                });
            #endregion Darius

            #region Diana
            Spells.Add(
                new SpellsData
                {
                    ChampionName = "Diana",
                    SpellName = "DianaArc",
                    MenuName = "Diana Q End",
                    Slot = SpellSlot.Q,
                    Type = SpellType.Circular,
                    Delay = 250,
                    Range = 895,
                    Radius = 195,
                    MissileSpeed = 1400,
                    FixedRange = false,
                    AddHitbox = true,
                    DangerValue = 3,
                    IsDangerous = true,
                    CcOrMgDamage = true,
                    MissileSpellName = "DianaArcArc",
                    CollisionObjects = new[] { CollisionType.YasuoWall }
                });

            Spells.Add(
                new SpellsData
                {
                    ChampionName = "Diana",
                    SpellName = "DianaArcArc",
                    MenuName = "Diana Q Side",
                    Slot = SpellSlot.Q,
                    Type = SpellType.Arc,
                    Delay = 250,
                    Range = 895,
                    Radius = 195,
                    DontCross = true,
                    MissileSpeed = 1400,
                    FixedRange = false,
                    AddHitbox = true,
                    DangerValue = 3,
                    IsDangerous = true,
                    CcOrMgDamage = true,
                    MissileSpellName = "DianaArcArc",
                    TakeClosestPath = true,
                    CollisionObjects = new[] { CollisionType.YasuoWall }
                });
            #endregion Diana

            #region DrMundo

            Spells.Add(
                new SpellsData
                {
                    ChampionName = "DrMundo",
                    SpellName = "InfectedCleaverMissileCast",
                    MenuName = "Mundo Q",
                    Slot = SpellSlot.Q,
                    Type = SpellType.MissileLine,
                    Delay = 250,
                    Range = 1050,
                    Radius = 60,
                    MissileSpeed = 2000,
                    FixedRange = true,
                    AddHitbox = true,
                    DangerValue = 3,
                    IsDangerous = false,
                    CcOrMgDamage = true,
                    MissileSpellName = "InfectedCleaverMissile",
                    CanBeRemoved = false,
                    CollisionObjects = new[] { CollisionType.AiHeroClient, CollisionType.ObjAiMinion, CollisionType.YasuoWall }
                });
            #endregion DrMundo

            #region Draven

            Spells.Add(
                new SpellsData
                {
                    ChampionName = "Draven",
                    SpellName = "DravenDoubleShot",
                    MenuName = "Draven E",
                    Slot = SpellSlot.E,
                    Type = SpellType.MissileLine,
                    Delay = 250,
                    Range = 1100,
                    Radius = 130,
                    MissileSpeed = 1400,
                    FixedRange = true,
                    AddHitbox = true,
                    DangerValue = 3,
                    IsDangerous = true,
                    CcOrMgDamage = true,
                    MissileSpellName = "DravenDoubleShotMissile",
                    CanBeRemoved = false,
                    CollisionObjects = new[] { CollisionType.YasuoWall }
                });

            Spells.Add(
                new SpellsData
                {
                    ChampionName = "Draven",
                    SpellName = "DravenRCast",
                    MenuName = "Draven R",
                    Slot = SpellSlot.R,
                    Type = SpellType.MissileLine,
                    Delay = 400,
                    Range = 20000,
                    Radius = 160,
                    MissileSpeed = 2000,
                    FixedRange = true,
                    AddHitbox = true,
                    DangerValue = 4,
                    IsDangerous = true,
                    CcOrMgDamage = false,
                    MissileSpellName = "DravenR",
                    CollisionObjects = new[] { CollisionType.YasuoWall }
                });
            #endregion Draven

            #region Ekko

            Spells.Add(
                new SpellsData
                {
                    ChampionName = "Ekko",
                    SpellName = "EkkoQ",
                    MenuName = "Ekko Q",
                    Slot = SpellSlot.Q,
                    Type = SpellType.MissileLine,
                    Delay = 250,
                    Range = 950,
                    Radius = 60,
                    MissileSpeed = 1650,
                    FixedRange = true,
                    AddHitbox = true,
                    DangerValue = 2,
                    IsDangerous = false,
                    CcOrMgDamage = true,
                    MissileSpellName = "ekkoqmis",
                    CanBeRemoved = false,
                    CollisionObjects = new[] { CollisionType.AiHeroClient, CollisionType.YasuoWall }
                });

            Spells.Add(
                new SpellsData
                {
                    ChampionName = "Ekko",
                    SpellName = "EkkoW",
                    MenuName = "Ekko W",
                    Slot = SpellSlot.W,
                    Type = SpellType.Circular,
                    Delay = 3750,
                    Range = 1600,
                    Radius = 375,
                    MissileSpeed = 1650,
                    FixedRange = false,
                    AddHitbox = false,
                    DangerValue = 2,
                    IsDangerous = false,
                    CcOrMgDamage = true,
                    MissileSpellName = "EkkoW",
                    CanBeRemoved = true
                });

            Spells.Add(
                new SpellsData
                {
                    ChampionName = "Ekko",
                    SpellName = "EkkoR",
                    MenuName = "Ekko R",
                    Slot = SpellSlot.R,
                    Type = SpellType.Circular,
                    Delay = 250,
                    Range = 1600,
                    Radius = 375,
                    MissileSpeed = 1650,
                    FixedRange = true,
                    AddHitbox = true,
                    DangerValue = 4,
                    IsDangerous = false,
                    CcOrMgDamage = true,
                    MissileSpellName = "EkkoR",
                    CanBeRemoved = false,
                    FromObjects = new[] { "Ekko_Base_R_TrailEnd.troy" }
                });

            #endregion Ekko

            #region Elise

            Spells.Add(
                new SpellsData
                {
                    ChampionName = "Elise",
                    SpellName = "EliseHumanE",
                    MenuName = "Elise Human E",
                    Slot = SpellSlot.E,
                    Type = SpellType.MissileLine,
                    Delay = 250,
                    Range = 1100,
                    Radius = 55,
                    MissileSpeed = 1600,
                    FixedRange = true,
                    AddHitbox = true,
                    DangerValue = 3,
                    IsDangerous = true,
                    CcOrMgDamage = true,
                    MissileSpellName = "EliseHumanE",
                    CanBeRemoved = false,
                    CollisionObjects = new[] { CollisionType.AiHeroClient, CollisionType.ObjAiMinion, CollisionType.YasuoWall }
                });
            #endregion Elise

            #region Evelynn

            Spells.Add(
                new SpellsData
                {
                    ChampionName = "Evelynn",
                    SpellName = "EvelynnR",
                    MenuName = "Evelynn R",
                    Slot = SpellSlot.R,
                    Type = SpellType.Circular,
                    Delay = 250,
                    Range = 650,
                    Radius = 350,
                    MissileSpeed = int.MaxValue,
                    FixedRange = false,
                    AddHitbox = true,
                    DangerValue = 4,
                    IsDangerous = true,
                    CcOrMgDamage = true,
                    MissileSpellName = "EvelynnR",
                });
            #endregion Evelynn

            #region Ezreal
            Spells.Add(
                new SpellsData
                {
                    ChampionName = "Ezreal",
                    SpellName = "EzrealMysticShot",
                    MenuName = "Ezreal Q",
                    Slot = SpellSlot.Q,
                    Type = SpellType.MissileLine,
                    Delay = 250,
                    Range = 1200,
                    Radius = 60,
                    MissileSpeed = 2000,
                    FixedRange = true,
                    AddHitbox = true,
                    DangerValue = 2,
                    IsDangerous = false,
                    CcOrMgDamage = false,
                    MissileSpellName = "EzrealMysticShotMissile",
                    ExtraMissileNames = new[] { "EzrealMysticShotPulseMissile" },
                    CanBeRemoved = false,
                    CollisionObjects = new[] { CollisionType.AiHeroClient, CollisionType.ObjAiMinion, CollisionType.YasuoWall },
                    Id = 229,
                });

            Spells.Add(
                new SpellsData
                {
                    ChampionName = "Ezreal",
                    SpellName = "EzrealEssenceFlux",
                    MenuName = "Ezreal W",
                    Slot = SpellSlot.W,
                    Type = SpellType.MissileLine,
                    Delay = 250,
                    Range = 1050,
                    Radius = 80,
                    MissileSpeed = 1600,
                    FixedRange = true,
                    AddHitbox = true,
                    DangerValue = 1,
                    IsDangerous = false,
                    CcOrMgDamage = true,
                    MissileSpellName = "EzrealEssenceFluxMissile",
                    CollisionObjects = new[] { CollisionType.YasuoWall },
                });

            Spells.Add(
                new SpellsData
                {
                    ChampionName = "Ezreal",
                    SpellName = "EzrealTrueshotBarrage",
                    MenuName = "Ezreal R",
                    Slot = SpellSlot.R,
                    Type = SpellType.MissileLine,
                    Delay = 1000,
                    Radius = 160,
                    Range = 25000,
                    MissileSpeed = 2000,
                    FixedRange = true,
                    AddHitbox = true,
                    IsDangerous = false,
                    CcOrMgDamage = true,
                    CollisionObjects = new[] { CollisionType.YasuoWall },

                });
            #endregion Ezreal

            #region Fiora

            Spells.Add(
                new SpellsData
                {
                    ChampionName = "Fiora",
                    SpellName = "FioraW",
                    MenuName = "Fiora W",
                    Slot = SpellSlot.W,
                    Type = SpellType.MissileLine,
                    Delay = 750,
                    Range = 750,
                    Radius = 70,
                    MissileSpeed = 3200,
                    FixedRange = true,
                    AddHitbox = true,
                    DangerValue = 3,
                    IsDangerous = false,
                    CcOrMgDamage = true,
                    MissileSpellName = "FioraWMissile",
                    CollisionObjects = new[] { CollisionType.AiHeroClient, CollisionType.YasuoWall },
                });

            #endregion Fiora

            #region Fizz

            Spells.Add(
                new SpellsData
                {
                    ChampionName = "Fizz",
                    SpellName = "FizzMarinerDoom",
                    MenuName = "Fiora W",
                    Slot = SpellSlot.R,
                    Type = SpellType.MissileLine,
                    Delay = 250,
                    Range = 1300,
                    Radius = 120,
                    MissileSpeed = 1350,
                    FixedRange = false,
                    AddHitbox = true,
                    DangerValue = 5,
                    IsDangerous = true,
                    CcOrMgDamage = true,
                    MissileSpellName = "FizzMarinerDoomMissile",
                    CollisionObjects = new[] { CollisionType.AiHeroClient, CollisionType.YasuoWall },
                    CanBeRemoved = false,
                });
            #endregion Fizz

            #region Galio

            Spells.Add(
                new SpellsData
                {
                    ChampionName = "Galio",
                    SpellName = "GalioResoluteSmite",
                    MenuName = "Galio Q",
                    Slot = SpellSlot.Q,
                    Type = SpellType.Circular,
                    Delay = 250,
                    Range = 900,
                    Radius = 200,
                    MissileSpeed = 1300,
                    FixedRange = false,
                    AddHitbox = true,
                    DangerValue = 2,
                    IsDangerous = false,
                    CcOrMgDamage = true,
                    MissileSpellName = "GalioResoluteSmite",
                });

            Spells.Add(
                new SpellsData
                {
                    ChampionName = "Galio",
                    SpellName = "GalioRighteousGust",
                    MenuName = "Galio E",
                    Slot = SpellSlot.E,
                    Type = SpellType.MissileLine,
                    Delay = 250,
                    Range = 1200,
                    Radius = 120,
                    MissileSpeed = 1200,
                    FixedRange = true,
                    AddHitbox = true,
                    DangerValue = 2,
                    IsDangerous = false,
                    CcOrMgDamage = true,
                    MissileSpellName = "GalioRighteousGust",
                    CollisionObjects = new[] { CollisionType.YasuoWall },
                });

            Spells.Add(
                new SpellsData
                {
                    ChampionName = "Galio",
                    SpellName = "GalioIdolOfDurand",
                    MenuName = "Galio R",
                    Slot = SpellSlot.R,
                    Type = SpellType.Circular,
                    Delay = 250,
                    Range = 0,
                    Radius = 550,
                    MissileSpeed = int.MaxValue,
                    FixedRange = true,
                    AddHitbox = false,
                    DangerValue = 5,
                    IsDangerous = true,
                    CcOrMgDamage = true,
                    MissileSpellName = "",
                });
            #endregion Galio

            #region Gnar

            Spells.Add(
                new SpellsData
                {
                    ChampionName = "Gnar",
                    SpellName = "GnarQ",
                    MenuName = "Tiny-Gnar Q",
                    Slot = SpellSlot.Q,
                    Type = SpellType.MissileLine,
                    Delay = 250,
                    Range = 1125,
                    Radius = 60,
                    MissileSpeed = 2500,
                    MissileAccel = -3000,
                    MissileMaxSpeed = 2500,
                    MissileMinSpeed = 1400,
                    FixedRange = true,
                    AddHitbox = true,
                    DangerValue = 2,
                    IsDangerous = false,
                    CcOrMgDamage = false,
                    CanBeRemoved = false,
                    ForceRemove = true,
                    MissileSpellName = "gnarqmissile",
                    CollisionObjects = new[] { CollisionType.YasuoWall },
                });

            Spells.Add(
                new SpellsData
                {
                    ChampionName = "Gnar",
                    SpellName = "GnarQReturn",
                    MenuName = "Tiny-Gnar Q Return",
                    Slot = SpellSlot.Q,
                    Type = SpellType.MissileLine,
                    Delay = 0,
                    Range = 2500,
                    Radius = 65,
                    MissileSpeed = 60,
                    MissileAccel = 800,
                    MissileMaxSpeed = 2600,
                    MissileMinSpeed = 60,
                    FixedRange = true,
                    AddHitbox = true,
                    DangerValue = 2,
                    IsDangerous = false,
                    CcOrMgDamage = false,
                    CanBeRemoved = false,
                    ForceRemove = true,
                    MissileSpellName = "GnarQMissileReturn",
                    DisableFowDetection = false,
                    DefaultDisable = true,
                    CollisionObjects = new[] { CollisionType.YasuoWall },
                });

            Spells.Add(
                new SpellsData
                {
                    ChampionName = "Gnar",
                    SpellName = "GnarBigQ",
                    MenuName = "Mega-Gnar Q",
                    Slot = SpellSlot.Q,
                    Type = SpellType.MissileLine,
                    Delay = 500,
                    Range = 1150,
                    Radius = 90,
                    MissileSpeed = 2100,
                    FixedRange = true,
                    AddHitbox = true,
                    DangerValue = 2,
                    IsDangerous = false,
                    CcOrMgDamage = false,
                    MissileSpellName = "GnarBigQMissile",
                    CollisionObjects = new[] { CollisionType.AiHeroClient, CollisionType.ObjAiMinion ,CollisionType.YasuoWall },
                });

            Spells.Add(
                new SpellsData
                {
                    ChampionName = "Gnar",
                    SpellName = "GnarBigW",
                    MenuName = "Mega-Gnar W",
                    Slot = SpellSlot.W,
                    Type = SpellType.Line,
                    Delay = 600,
                    Range = 600,
                    Radius = 80,
                    MissileSpeed = int.MaxValue,
                    FixedRange = true,
                    AddHitbox = true,
                    DangerValue = 2,
                    IsDangerous = false,
                    CcOrMgDamage = true,
                    MissileSpellName = "GnarBigW",
                });

            Spells.Add(
                new SpellsData
                {
                    ChampionName = "Gnar",
                    SpellName = "GnarE",
                    MenuName = "Tiny-Gnar E",
                    Slot = SpellSlot.E,
                    Type = SpellType.Circular,
                    Delay = 0,
                    Range = 475,
                    Radius = 150,
                    MissileSpeed = 903,
                    FixedRange = false,
                    AddHitbox = true,
                    DangerValue = 2,
                    IsDangerous = false,
                    CcOrMgDamage = false,
                    MissileSpellName = "GnarE",
                });

            Spells.Add(
                new SpellsData
                {
                    ChampionName = "Gnar",
                    SpellName = "GnarBigE",
                    MenuName = "Mega-Gnar E",
                    Slot = SpellSlot.E,
                    Type = SpellType.Circular,
                    Delay = 250,
                    Range = 475,
                    Radius = 200,
                    MissileSpeed = 1000,
                    FixedRange = false,
                    AddHitbox = true,
                    DangerValue = 2,
                    IsDangerous = false,
                    CcOrMgDamage = false,
                    MissileSpellName = "GnarBigE",
                });

            Spells.Add(
                new SpellsData
                {
                    ChampionName = "Gnar",
                    SpellName = "GnarR",
                    MenuName = "Gnar R",
                    Slot = SpellSlot.R,
                    Type = SpellType.Circular,
                    Delay = 250,
                    Range = 0,
                    Radius = 500,
                    MissileSpeed = int.MaxValue,
                    FixedRange = true,
                    AddHitbox = false,
                    DangerValue = 5,
                    IsDangerous = true,
                    CcOrMgDamage = true,
                    MissileSpellName = "",
                });

            #endregion Gnar

            #region Gragas

            Spells.Add(
                new SpellsData
                {
                    ChampionName = "Gragas",
                    SpellName = "GragasQ",
                    MenuName = "Gragas Q",
                    Slot = SpellSlot.Q,
                    Type = SpellType.Circular,
                    Delay = 250,
                    Range = 1100,
                    Radius = 275,
                    MissileSpeed = 1300,
                    FixedRange = false,
                    AddHitbox = true,
                    DangerValue = 2,
                    IsDangerous = false,
                    CcOrMgDamage = true,
                    MissileSpellName = "GragasQMissile",
                    ExtraDuration = 4500,
                    ToggleParticleName = "Gragas_.+_Q_(Enemy|Ally)",
                    DontCross = true,
                });

            Spells.Add(
                new SpellsData
                {
                    ChampionName = "Gragas",
                    SpellName = "GragasE",
                    MenuName = "Gragas E",
                    Slot = SpellSlot.E,
                    Type = SpellType.MissileLine,
                    Delay = 0,
                    Range = 950,
                    Radius = 200,
                    MissileSpeed = 1200,
                    FixedRange = true,
                    AddHitbox = true,
                    DangerValue = 3,
                    IsDangerous = true,
                    CcOrMgDamage = true,
                    MissileSpellName = "GragasE",
                    CanBeRemoved = false,
                    ExtraRange = 300,
                    CollisionObjects = new[] { CollisionType.AiHeroClient, CollisionType.ObjAiMinion },
                });

            Spells.Add(
                new SpellsData
                {
                    ChampionName = "Gragas",
                    SpellName = "GragasR",
                    MenuName = "Gragas R",
                    Slot = SpellSlot.R,
                    Type = SpellType.Circular,
                    Delay = 550,
                    Range = 1050,
                    Radius = 375,
                    MissileSpeed = int.MaxValue,
                    FixedRange = false,
                    AddHitbox = true,
                    DangerValue = 5,
                    IsDangerous = true,
                    CcOrMgDamage = true,
                    MissileSpellName = "GragasRBoom",
                    CollisionObjects = new[] { CollisionType.YasuoWall },
                });           
            #endregion Gragas

            #region Graves

            Spells.Add(
                new SpellsData
                {
                    ChampionName = "Graves",
                    SpellName = "GravesQLineSpell",
                    MenuName = "Graves Q",
                    Slot = SpellSlot.Q,
                    Type = SpellType.MissileLine,
                    Delay = 250,
                    Range = 808,
                    Radius = 40,
                    MissileSpeed = 3000,
                    FixedRange = true,
                    AddHitbox = true,
                    DangerValue = 2,
                    IsDangerous = false,
                    CcOrMgDamage = false,
                    MissileSpellName = "GravesQLineMis",
                    CollisionObjects = new[] { CollisionType.YasuoWall }, //Wall is collision too kappa
                    ExtraMissileNames = new[] { "GravesQReturn" },
                });

            Spells.Add(
                new SpellsData
                {
                    ChampionName = "Graves",
                    SpellName = "GravesChargeShot",
                    MenuName = "Graves R",
                    Slot = SpellSlot.R,
                    Type = SpellType.MissileLine,
                    Delay = 250,
                    Range = 1100,
                    Radius = 100,
                    MissileSpeed = 2100,
                    FixedRange = true,
                    AddHitbox = true,
                    DangerValue = 4,
                    IsDangerous = false,
                    CcOrMgDamage = false,
                    MissileSpellName = "GravesChargeShotShot",
                    CollisionObjects = new[] { CollisionType.YasuoWall},
                });
            #endregion Graves

            #region Hecarim

            Spells.Add(
                new SpellsData
                {
                    ChampionName = "Hecarim",
                    SpellName = "HecarimUlt",
                    MenuName = "Hecarim R",
                    Slot = SpellSlot.R,
                    Type = SpellType.MissileLine,
                    Delay = 250,
                    Range = 1500,
                    Radius = 300,
                    MissileSpeed = 1100,
                    FixedRange = true,
                    AddHitbox = true,
                    DangerValue = 5,
                    IsDangerous = true,
                    CcOrMgDamage = true,
                    MissileSpellName = "hecarimultmissile",
                });
            #endregion Hecarim

            #region Heimerdinger
            Spells.Add(
            new SpellsData
            {
                ChampionName = "Heimerdinger",
                SpellName = "HeimerdingerTurretEnergyBlast",
                MenuName = "Heimerdinger Q Energy Blast",
                Slot = SpellSlot.Q,
                Type = SpellType.MissileLine,
                Delay = 435,
                Range = 1000,
                Radius = 50,
                MissileSpeed = 1650,
                DangerValue = 1,
                IsDangerous = false,
                DefaultDisable = true,
                CcOrMgDamage = true,
                CollisionObjects = new[] { CollisionType.YasuoWall },
            });

            Spells.Add(
            new SpellsData
            {
                ChampionName = "Heimerdinger",
                SpellName = "HeimerdingerTurretEnergyBlast",
                MenuName = "Heimerdinger R-Q Energy Blast",
                Slot = SpellSlot.Q,
                Type = SpellType.MissileLine,
                Delay = 350,
                Range = 1000,
                Radius = 50,
                MissileSpeed = 1650,
                DangerValue = 1,
                IsDangerous = false,
                DefaultDisable = true,
                CcOrMgDamage = true,
                CollisionObjects = new[] { CollisionType.YasuoWall },
            });

            Spells.Add(
                new SpellsData
                {
                    ChampionName = "Heimerdinger",
                    SpellName = "Heimerdingerwm",
                    MenuName = "Heimerdinger W",
                    Slot = SpellSlot.W,
                    Type = SpellType.MissileLine,
                    Delay = 250,
                    Range = 1500,
                    Radius = 70,
                    MissileSpeed = 1800,
                    FixedRange = true,
                    AddHitbox = true,
                    DangerValue = 3,
                    IsDangerous = false,
                    CcOrMgDamage = true,
                    MissileSpellName = "HeimerdingerWAttack2",
                    CollisionObjects = new[] { CollisionType.YasuoWall },
                });

            Spells.Add(
                new SpellsData
                {
                    ChampionName = "Heimerdinger",
                    SpellName = "HeimerdingerE",
                    MenuName = "Heimerdinger E",
                    Slot = SpellSlot.E,
                    Type = SpellType.Circular,
                    Delay = 250,
                    Range = 925,
                    Radius = 100,
                    MissileSpeed = 1200,
                    FixedRange = false,
                    AddHitbox = true,
                    DangerValue = 3,
                    IsDangerous = true,
                    CcOrMgDamage = true,
                    MissileSpellName = "heimerdingerespell",
                    CollisionObjects = new[] { CollisionType.YasuoWall },
                });            
            #endregion Heimerdinger

            #region Illaoi

            Spells.Add(
                new SpellsData
                {
                    ChampionName = "Illaoi",
                    SpellName = "IllaoiQ",
                    MenuName = "Illaoi Q",
                    Slot = SpellSlot.Q,
                    Type = SpellType.Line,
                    Delay = 750,
                    Range = 850,
                    Radius = 100,
                    MissileSpeed = int.MaxValue,
                    FixedRange = true,
                    AddHitbox = true,
                    DangerValue = 3,
                    IsDangerous = false,
                    CcOrMgDamage = false,
                });

            Spells.Add(
                new SpellsData
                {
                    ChampionName = "Illaoi",
                    SpellName = "IllaoiE",
                    MenuName = "Illaoi E",
                    Slot = SpellSlot.E,
                    Type = SpellType.MissileLine,
                    Delay = 250,
                    Range = 950,
                    Radius = 50,
                    MissileSpeed = 1900,
                    FixedRange = true,
                    AddHitbox = true,
                    DangerValue = 3,
                    IsDangerous = true,
                    CcOrMgDamage = false,
                    MissileSpellName = "illaoiemis",
                    CollisionObjects = new[] { CollisionType.AiHeroClient, CollisionType.ObjAiMinion, CollisionType.YasuoWall },
                });

            Spells.Add(
                new SpellsData
                {
                    ChampionName = "Illaoi",
                    SpellName = "IllaoiR",
                    MenuName = "Illaoi R",
                    Slot = SpellSlot.R,
                    Type = SpellType.Circular,
                    Delay = 500,
                    Range = 0,
                    Radius = 450,
                    MissileSpeed = int.MaxValue,
                    FixedRange = true,
                    AddHitbox = false,
                    DangerValue = 4,
                    IsDangerous = true,
                    CcOrMgDamage = false,
                });
            #endregion Illaoi
            
            #region Irelia

            Spells.Add(
            new SpellsData
            {
                ChampionName = "Irelia",
                SpellName = "IreliaTranscendentBlades",
                MenuName = "Irelia R",
                Slot = SpellSlot.R,
                Type = SpellType.MissileLine,
                Delay = 0,
                Range = 1200,
                Radius = 65,
                MissileSpeed = 1600,
                FixedRange = true,
                AddHitbox = true,
                DangerValue = 2,
                IsDangerous = false,
                CcOrMgDamage = false,
                MissileSpellName = "IreliaTranscendentBlades",
                CollisionObjects = new[] { CollisionType.YasuoWall },
            });
            #endregion Irelia

            #region Ivern

            Spells.Add(
                new SpellsData
                {
                    ChampionName = "Ivern",
                    SpellName = "IvernQ",
                    MenuName = "Ivern Q",
                    Slot = SpellSlot.Q,
                    Type = SpellType.MissileLine,
                    Delay = 250,
                    Range = 1100,
                    Radius = 65,
                    MissileSpeed = 1300,
                    FixedRange = true,
                    AddHitbox = true,
                    DangerValue = 3,
                    IsDangerous = true,
                    CcOrMgDamage = true,
                    MissileSpellName = "IvernQ",
                    CollisionObjects = new[] { CollisionType.AiHeroClient, CollisionType.ObjAiMinion, CollisionType.YasuoWall },
                });

            #endregion Ivern

            #region Janna

            Spells.Add(
            new SpellsData
            {
                ChampionName = "Janna",
                SpellName = "JannaQ",
                MenuName = "Janna Q",
                Slot = SpellSlot.Q,
                Type = SpellType.MissileLine,
                Delay = 250,
                Range = 1700,
                Radius = 120,
                MissileSpeed = 900,
                FixedRange = false,
                AddHitbox = true,
                DangerValue = 3,
                IsDangerous = true,
                MissileSpellName = "HowlingGaleSpell",
                CollisionObjects = new[] { CollisionType.YasuoWall },
            });
            #endregion Janna

            #region JarvanIV

            Spells.Add(
                new SpellsData
                {
                    ChampionName = "JarvanIV",
                    SpellName = "JarvanIVDragonStrike",
                    MenuName = "JarvanIV Q",
                    Slot = SpellSlot.Q,
                    Type = SpellType.Line,
                    Delay = 500,
                    Range = 770,
                    Radius = 70,
                    MissileSpeed = int.MaxValue,
                    FixedRange = true,
                    AddHitbox = true,
                    DangerValue = 3,
                    IsDangerous = false,
                    CcOrMgDamage = false,
                });

            Spells.Add(
                new SpellsData
                {
                    ChampionName = "JarvanIV",
                    SpellName = "JarvanIVEQ",
                    MenuName = "JarvanIV E-Q Combo",
                    Slot = SpellSlot.Q,
                    Type = SpellType.MissileLine,
                    Delay = 250,
                    Range = 880,
                    Radius = 70,
                    MissileSpeed = 1450,
                    FixedRange = true,
                    AddHitbox = true,
                    DangerValue = 3,
                    IsDangerous = true,
                    CcOrMgDamage = true,
                });

            Spells.Add(
                new SpellsData
                {
                    ChampionName = "JarvanIV",
                    SpellName = "JarvanIVDemacianStandard",
                    MenuName = "JarvenIV E",
                    Slot = SpellSlot.E,
                    Type = SpellType.Circular,
                    Delay = 500,
                    Range = 860,
                    Radius = 175,
                    MissileSpeed = int.MaxValue,
                    FixedRange = false,
                    AddHitbox = true,
                    DangerValue = 1,
                    IsDangerous = false,
                    CcOrMgDamage = true,
                    DefaultDisable = true,
                    MissileSpellName = "JarvanIVDemacianStandard",
                });
            #endregion JarvanIV

            #region Jayce

            Spells.Add(
                new SpellsData
                {
                    ChampionName = "Jayce",
                    SpellName = "jayceshockblast",
                    MenuName = "Jayce Q Normal",
                    Slot = SpellSlot.Q,
                    Type = SpellType.MissileLine,
                    Delay = 250,
                    Range = 1300,
                    Radius = 70,
                    MissileSpeed = 1450,
                    FixedRange = true,
                    AddHitbox = true,
                    DangerValue = 2,
                    IsDangerous = false,
                    CcOrMgDamage = false,
                    MissileSpellName = "JayceShockBlastMis",
                    CanBeRemoved = false,
                    CollisionObjects = new[] { CollisionType.AiHeroClient, CollisionType.ObjAiMinion, CollisionType.YasuoWall },
                });

            Spells.Add(
                new SpellsData
                {
                    ChampionName = "Jayce",
                    SpellName = "JayceQAccel",
                    MenuName = "Jayce Q Empowered",
                    Slot = SpellSlot.Q,
                    Type = SpellType.MissileLine,
                    Delay = 250,
                    Range = 1300,
                    Radius = 70,
                    MissileSpeed = 2350,
                    FixedRange = true,
                    AddHitbox = true,
                    DangerValue = 3,
                    IsDangerous = false,
                    CcOrMgDamage = false,
                    MissileSpellName = "JayceShockBlastWallMis",
                    CanBeRemoved = false,
                    CollisionObjects = new[] { CollisionType.AiHeroClient, CollisionType.ObjAiMinion, CollisionType.YasuoWall },
                });
            #endregion Jayce

            #region Jhin

            Spells.Add(
                new SpellsData
                {
                    ChampionName = "Jhin",
                    SpellName = "JhinW",
                    MenuName = "Jhin W",
                    Slot = SpellSlot.W,
                    Type = SpellType.MissileLine,
                    Delay = 750,
                    Range = 2550,
                    Radius = 40,
                    MissileSpeed = 5000,
                    FixedRange = true,
                    AddHitbox = true,
                    DangerValue = 3,
                    IsDangerous = true,
                    CcOrMgDamage = false,
                    MissileSpellName = "JhinWMissile",
                    CanBeRemoved = false,
                    CollisionObjects = new[] { CollisionType.AiHeroClient, CollisionType.YasuoWall },
                });

            Spells.Add(
                new SpellsData
                {
                    ChampionName = "Jhin",
                    SpellName = "JhinE",
                    MenuName = "Jhin E",
                    Slot = SpellSlot.E,
                    Type = SpellType.Circular,
                    Delay = 250,
                    Range = 700,
                    Radius = 130,
                    MissileSpeed = int.MaxValue,
                    FixedRange = false,
                    AddHitbox = true,
                    DangerValue = 1,
                    IsDangerous = false,
                    CcOrMgDamage = true,
                    MissileSpellName = "JhinEMiss",
                    DontCross = true,
                    ExtraDuration = 120000,
                    DefaultDisable = true,
                });


            Spells.Add(
                new SpellsData
                {
                    ChampionName = "Jhin",
                    SpellName = "JhinRShot",
                    MenuName = "Jhin R",
                    Slot = SpellSlot.R,
                    Type = SpellType.MissileLine,
                    Delay = 250,
                    Range = 3500,
                    Radius = 80,
                    MissileSpeed = 5000,
                    FixedRange = true,
                    AddHitbox = true,
                    DangerValue = 3,
                    IsDangerous = true,
                    CcOrMgDamage = false,
                    MissileSpellName = "JhinRShotMis",
                    ExtraMissileNames = new[] { "JhinRShotMis4" },
                    CanBeRemoved = false,
                    CollisionObjects = new[] { CollisionType.AiHeroClient, CollisionType.YasuoWall },
                });

            #endregion Jhin

            #region Jinx

            Spells.Add(
                new SpellsData
                {
                    ChampionName = "Jinx",
                    SpellName = "JinxW",
                    Slot = SpellSlot.W,
                    Type = SpellType.MissileLine,
                    Delay = 600,
                    Range = 1500,
                    Radius = 60,
                    MissileSpeed = 3300,
                    FixedRange = true,
                    AddHitbox = true,
                    DangerValue = 3,
                    IsDangerous = true,
                    CcOrMgDamage = false,
                    MissileSpellName = "JinxWMissile",
                    CanBeRemoved = false,
                    CollisionObjects = new[] { CollisionType.AiHeroClient, CollisionType.ObjAiMinion, CollisionType.YasuoWall },
                });

            Spells.Add(
                new SpellsData
                {
                    ChampionName = "Jinx",
                    SpellName = "JinxE",
                    Slot = SpellSlot.E,
                    Type = SpellType.Line,
                    Delay = 350,
                    Range = 850,
                    Radius = 65,
                    MissileSpeed = int.MaxValue,
                    FixedRange = false,
                    AddHitbox = true,
                    DangerValue = 3,
                    IsDangerous = true,
                    CcOrMgDamage = true,
                    MissileSpellName = "JinxEMissile",
                    ExtraDuration = 5300,
                    DontCross = true,
                });

            Spells.Add(
                new SpellsData
                {
                    ChampionName = "Jinx",
                    SpellName = "JinxR",
                    MenuName = "Jinx R",
                    Slot = SpellSlot.R,
                    Type = SpellType.MissileLine,
                    Delay = 600,
                    Range = 20000,
                    Radius = 140,
                    MissileSpeed = 1700,
                    FixedRange = true,
                    AddHitbox = true,
                    DangerValue = 4,
                    IsDangerous = true,
                    CcOrMgDamage = false,
                    MissileSpellName = "JinxR",
                    CanBeRemoved = false,
                    CollisionObjects = new[] { CollisionType.AiHeroClient, CollisionType.YasuoWall },
                });
            #endregion Jinx

            #region Kalista

            Spells.Add(
                new SpellsData
                {
                    ChampionName = "Kalista",
                    SpellName = "KalistaMysticShot",
                    MenuName = "Kalista Q",
                    Slot = SpellSlot.Q,
                    Type = SpellType.MissileLine,
                    Delay = 250,
                    Range = 1200,
                    Radius = 40,
                    MissileSpeed = 1700,
                    FixedRange = true,
                    AddHitbox = true,
                    DangerValue = 2,
                    IsDangerous = false,
                    CcOrMgDamage = false,
                    MissileSpellName = "kalistamysticshotmis",
                    ExtraMissileNames = new[] { "kalistamysticshotmistrue" },
                    CanBeRemoved = false,
                    CollisionObjects = new[] { CollisionType.AiHeroClient, CollisionType.ObjAiMinion, CollisionType.YasuoWall },
                });
            #endregion Kalista

            #region Karma

            Spells.Add(
                new SpellsData
                {
                    ChampionName = "Karma",
                    SpellName = "KarmaQ",
                    MenuName = "Karma Q",
                    Slot = SpellSlot.Q,
                    Type = SpellType.MissileLine,
                    Delay = 250,
                    Range = 1050,
                    Radius = 60,
                    MissileSpeed = 1700,
                    FixedRange = true,
                    AddHitbox = true,
                    DangerValue = 2,
                    IsDangerous = false,
                    CcOrMgDamage = true,
                    MissileSpellName = "KarmaQMissile",
                    CanBeRemoved = false,
                    CollisionObjects = new[] { CollisionType.AiHeroClient, CollisionType.ObjAiMinion, CollisionType.YasuoWall },
                });

            Spells.Add(
                new SpellsData
                {
                    ChampionName = "Karma",
                    SpellName = "KarmaQMantra",
                    MenuName = "Karma R-Q",
                    Slot = SpellSlot.Q,
                    Type = SpellType.MissileLine,
                    Delay = 250,
                    Range = 950,
                    Radius = 80,
                    EndExplosionRadius = 250,
                    MissileSpeed = 1700,
                    FixedRange = true,
                    AddHitbox = true,
                    DangerValue = 2,
                    IsDangerous = false,
                    CcOrMgDamage = true,
                    MissileSpellName = "KarmaQMissileMantra",
                    CanBeRemoved = false,
                    CollisionObjects = new[] { CollisionType.AiHeroClient, CollisionType.ObjAiMinion, CollisionType.YasuoWall },
                });
            #endregion Karma

            #region Karthus

            Spells.Add(
                new SpellsData
                {
                    ChampionName = "Karthus",
                    SpellName = "KarthusLayWasteA2",
                    MenuName = "Karthus Q",
                    ExtraSpellNames = new[] { "karthuslaywastea3", "karthuslaywastea1", "karthuslaywastedeada1", "karthuslaywastedeada2", "karthuslaywastedeada3" },
                    Slot = SpellSlot.Q,
                    Type = SpellType.Circular,
                    Delay = 625,
                    Range = 875,
                    Radius = 160,
                    MissileSpeed = int.MaxValue,
                    FixedRange = false,
                    AddHitbox = true,
                    DangerValue = 1,
                    IsDangerous = false,
                    CcOrMgDamage = true,
                    MissileSpellName = "",
                });

            #endregion Karthus

            //Kassadin
            #region Kassadin

            Spells.Add(
                new SpellsData
                {
                    //Fix radius
                    ChampionName = "Kassadin",
                    SpellName = "ForcePulse",
                    MenuName = "Kassadin E",
                    Slot = SpellSlot.E,
                    Type = SpellType.Cone,
                    Delay = 250,
                    Range = 700,
                    Angel = 70,
                    Radius = 20,
                    MissileSpeed = int.MaxValue,
                    FixedRange = false,
                    AddHitbox = true,
                    DangerValue = 3,
                    CcOrMgDamage = true,
                });

            Spells.Add(
                new SpellsData
                {
                    ChampionName = "Kassadin",
                    SpellName = "RiftWalk",
                    Slot = SpellSlot.R,
                    Type = SpellType.Circular,
                    Delay = 250,
                    Range = 450,
                    Radius = 270,
                    MissileSpeed = int.MaxValue,
                    FixedRange = false,
                    AddHitbox = true,
                    DangerValue = 1,
                    IsDangerous = false,
                    CcOrMgDamage = true,
                    MissileSpellName = "RiftWalk",
                });
            #endregion Kassadin

            #region Katarina
            //Nothing here, Only prepare for Assasin Update
            #endregion

            #region Kennen

            Spells.Add(
                new SpellsData
                {
                    ChampionName = "Kennen",
                    SpellName = "KennenShurikenHurlMissile1",
                    MenuName = "Kennen Q",
                    Slot = SpellSlot.Q,
                    Type = SpellType.MissileLine,
                    Delay = 250,
                    Range = 1050,
                    Radius = 50,
                    MissileSpeed = 1700,
                    FixedRange = true,
                    AddHitbox = true,
                    DangerValue = 3,
                    IsDangerous = true,
                    CcOrMgDamage = true,
                    MissileSpellName = "KennenShurikenHurlMissile1",
                    CanBeRemoved = false,
                    CollisionObjects = new[] { CollisionType.AiHeroClient, CollisionType.ObjAiMinion, CollisionType.YasuoWall },
                });
            #endregion Kennen

            #region Khazix

            Spells.Add(
                new SpellsData
                {
                    ChampionName = "Khazix",
                    SpellName = "KhazixW",
                    MenuName = "Khazix W",
                    ExtraSpellNames = new[] { "khazixwlong" },
                    Slot = SpellSlot.W,
                    Type = SpellType.MissileLine,
                    Delay = 250,
                    Range = 1025,
                    Radius = 73,
                    MissileSpeed = 1700,
                    FixedRange = true,
                    AddHitbox = true,
                    DangerValue = 2,
                    IsDangerous = false,
                    CcOrMgDamage = false,
                    MissileSpellName = "KhazixWMissile",
                    CanBeRemoved = false,
                    MultipleNumber = 3,
                    MultipleAngle = 22f * (float)Math.PI / 180,
                    CollisionObjects = new[] { CollisionType.AiHeroClient, CollisionType.ObjAiMinion, CollisionType.YasuoWall },
                });

            Spells.Add(
                new SpellsData
                {
                    ChampionName = "Khazix",
                    SpellName = "KhazixE",
                    MenuName = "Khazix E",
                    Slot = SpellSlot.E,
                    Type = SpellType.Circular,
                    Delay = 250,
                    Range = 600,
                    Radius = 300,
                    MissileSpeed = 1500,
                    FixedRange = false,
                    AddHitbox = true,
                    DangerValue = 1,
                    IsDangerous = false,
                    CcOrMgDamage = false,
                    MissileSpellName = "KhazixE",
                });
            #endregion Khazix

            #region Kled

            Spells.Add(
                new SpellsData
                {
                    ChampionName = "Kled",
                    SpellName = "KledQ",
                    MenuName = "Kled Mounted Q",
                    Slot = SpellSlot.Q,
                    Type = SpellType.MissileLine,
                    Delay = 250,
                    Range = 800,
                    Radius = 45,
                    MissileSpeed = 1600,
                    FixedRange = true,
                    AddHitbox = true,
                    DangerValue = 3,
                    IsDangerous = true,
                    CcOrMgDamage = true,
                    MissileSpellName = "KledQMissile",
                    CanBeRemoved = false,
                    CollisionObjects = new[] { CollisionType.AiHeroClient, CollisionType.ObjAiMinion, CollisionType.YasuoWall },
                });

            Spells.Add(
                new SpellsData
                {
                    ChampionName = "Kled",
                    SpellName = "KledE",
                    MenuName = "Kled E",
                    Slot = SpellSlot.E,
                    Type = SpellType.MissileLine,
                    Delay = 0,
                    Range = 750,
                    Radius = 125,
                    MissileSpeed = 945,
                    FixedRange = true,
                    AddHitbox = true,
                    DangerValue = 3,
                    IsDangerous = true,
                    MissileSpellName = "",
                    CanBeRemoved = false,
                    CollisionObjects = new[] { CollisionType.AiHeroClient, CollisionType.YasuoWall },
                });

            Spells.Add(
                new SpellsData
                {
                    ChampionName = "Kled",
                    SpellName = "KledRiderQ",
                    Slot = SpellSlot.Q,
                    Type = SpellType.MissileLine,
                    Delay = 250,
                    Range = 700,
                    Radius = 40,
                    MissileSpeed = 3000,
                    FixedRange = true,
                    AddHitbox = true,
                    DangerValue = 1,
                    IsDangerous = false,
                    DefaultDisable = true,
                    CcOrMgDamage = false,
                    MissileSpellName = "KledRiderQMissile",
                    MultipleNumber = 5,
                    MultipleAngle = 5 * (float)Math.PI / 180,
                    CanBeRemoved = false,
                    CollisionObjects = new[] { CollisionType.YasuoWall },
                });

            #endregion Kled

            #region KogMaw

            Spells.Add(
                new SpellsData
                {
                    ChampionName = "Kogmaw",
                    SpellName = "KogMawQ",
                    MenuName = "Kogmaw Q",
                    Slot = SpellSlot.Q,
                    Type = SpellType.MissileLine,
                    Delay = 250,
                    Range = 1200,
                    Radius = 70,
                    MissileSpeed = 1650,
                    FixedRange = true,
                    AddHitbox = true,
                    DangerValue = 2,
                    IsDangerous = false,
                    CcOrMgDamage = true,
                    MissileSpellName = "KogMawQ",
                    CanBeRemoved = false,
                    CollisionObjects = new[] { CollisionType.AiHeroClient, CollisionType.ObjAiMinion, CollisionType.YasuoWall },
                });

            Spells.Add(
                new SpellsData
                {
                    ChampionName = "Kogmaw",
                    SpellName = "KogMawVoidOoze",
                    MenuName = "Kogmaw E",
                    Slot = SpellSlot.E,
                    Type = SpellType.MissileLine,
                    Delay = 250,
                    Range = 1360,
                    Radius = 120,
                    MissileSpeed = 1400,
                    FixedRange = true,
                    AddHitbox = true,
                    DangerValue = 2,
                    IsDangerous = false,
                    CcOrMgDamage = true,
                    MissileSpellName = "KogMawVoidOozeMissile",
                    CollisionObjects = new[] { CollisionType.YasuoWall },
                });

            Spells.Add(
                new SpellsData
                {
                    ChampionName = "Kogmaw",
                    SpellName = "KogMawLivingArtillery",
                    MenuName = "Kogmaw R",
                    Slot = SpellSlot.R,
                    Type = SpellType.Circular,
                    Delay = 1200,
                    Range = 1800,
                    Radius = 225,
                    MissileSpeed = int.MaxValue,
                    FixedRange = false,
                    AddHitbox = true,
                    DangerValue = 2,
                    IsDangerous = false,
                    CcOrMgDamage = true,
                    MissileSpellName = "KogMawLivingArtillery",
                });
            #endregion KogMaw

            #region Leblanc

            Spells.Add(
                new SpellsData
                {
                    ChampionName = "Leblanc",
                    SpellName = "LeblancSlide",
                    MenuName = "Leblanc W",
                    Slot = SpellSlot.W,
                    Type = SpellType.Circular,
                    Delay = 0,
                    Range = 600,
                    Radius = 220,
                    MissileSpeed = 1450,
                    FixedRange = false,
                    AddHitbox = true,
                    DangerValue = 2,
                    IsDangerous = false,
                    CcOrMgDamage = true,
                    MissileSpellName = "LeblancSlide",
                });

            Spells.Add(
                new SpellsData
                {
                    ChampionName = "Leblanc",
                    SpellName = "LeblancSlideM",
                    MenuName = "Leblanc W Fake",
                    Slot = SpellSlot.R,
                    Type = SpellType.Circular,
                    Delay = 0,
                    Range = 600,
                    Radius = 220,
                    MissileSpeed = 1450,
                    FixedRange = false,
                    AddHitbox = true,
                    DangerValue = 2,
                    IsDangerous = false,
                    CcOrMgDamage = true,
                    MissileSpellName = "LeblancSlideM",
                });

            Spells.Add(
                new SpellsData
                {
                    ChampionName = "Leblanc",
                    SpellName = "LeblancSoulShackle",
                    MenuName = "Leblanc E",
                    Slot = SpellSlot.E,
                    Type = SpellType.Circular,
                    Delay = 250,
                    Range = 950,
                    Radius = 55,
                    MissileSpeed = 1750,
                    FixedRange = true,
                    AddHitbox = true,
                    DangerValue = 3,
                    IsDangerous = true,
                    CcOrMgDamage = true,
                    MissileSpellName = "LeblancSoulShackle",
                    CanBeRemoved = false,
                    CollisionObjects = new[] { CollisionType.AiHeroClient, CollisionType.ObjAiMinion, CollisionType.YasuoWall },
                });

            Spells.Add(
                new SpellsData
                {
                    ChampionName = "Leblanc",
                    SpellName = "LeblancSoulShackleM",
                    MenuName = "Leblanc E Fake",
                    Slot = SpellSlot.R,
                    Type = SpellType.Circular,
                    Delay = 250,
                    Range = 950,
                    Radius = 55,
                    MissileSpeed = 1750,
                    FixedRange = true,
                    AddHitbox = true,
                    DangerValue = 3,
                    IsDangerous = true,
                    CcOrMgDamage = true,
                    MissileSpellName = "LeblancSoulShackleM",
                    CanBeRemoved = false,
                    CollisionObjects = new[] { CollisionType.AiHeroClient, CollisionType.ObjAiMinion, CollisionType.YasuoWall },
                });
            #endregion Leblanc

            #region LeeSin

            Spells.Add(
                new SpellsData
                {
                    ChampionName = "LeeSin",
                    SpellName = "BlindMonkQOne",
                    MenuName = "LeeSin Q",
                    Slot = SpellSlot.Q,
                    Type = SpellType.MissileLine,
                    Delay = 250,
                    Range = 1100,
                    Radius = 65,
                    MissileSpeed = 1800,
                    FixedRange = true,
                    AddHitbox = true,
                    DangerValue = 3,
                    IsDangerous = true,
                    CcOrMgDamage = false,
                    MissileSpellName = "BlindMonkQOne",
                    CanBeRemoved = false,
                    CollisionObjects = new[] { CollisionType.AiHeroClient, CollisionType.ObjAiMinion, CollisionType.YasuoWall },
                });
            #endregion LeeSin

            #region Leona

            Spells.Add(
                new SpellsData
                {
                    ChampionName = "Leona",
                    SpellName = "LeonaZenithBlade",
                    MenuName = "Leona E",
                    Slot = SpellSlot.E,
                    Type = SpellType.MissileLine,
                    Delay = 250,
                    Range = 905,
                    Radius = 70,
                    MissileSpeed = 2000,
                    FixedRange = true,
                    AddHitbox = true,
                    DangerValue = 3,
                    IsDangerous = true,
                    CcOrMgDamage = true,
                    TakeClosestPath = true,
                    MissileSpellName = "LeonaZenithBladeMissile",
                    CollisionObjects = new[] { CollisionType.YasuoWall },
                });

            Spells.Add(
                new SpellsData
                {
                    ChampionName = "Leona",
                    SpellName = "LeonaSolarFlare",
                    MenuName = "Leona R",
                    Slot = SpellSlot.R,
                    Type = SpellType.Circular,
                    Delay = 1000,
                    Range = 1200,
                    Radius = 300,
                    MissileSpeed = int.MaxValue,
                    FixedRange = false,
                    AddHitbox = true,
                    DangerValue = 5,
                    IsDangerous = true,
                    CcOrMgDamage = true,
                    MissileSpellName = "LeonaSolarFlare",
                });
            #endregion Leona

            #region Lissandra

            Spells.Add(
                new SpellsData
                {
                    ChampionName = "Lissandra",
                    SpellName = "LissandraQ",
                    MenuName = "Lissandra Q",
                    Slot = SpellSlot.Q,
                    Type = SpellType.MissileLine,
                    Delay = 250,
                    Range = 825,
                    Radius = 75,
                    MissileSpeed = 2200,
                    FixedRange = true,
                    AddHitbox = true,
                    DangerValue = 2,
                    IsDangerous = false,
                    CcOrMgDamage = true,
                    MissileSpellName = "LissandraQMissile",
                    CollisionObjects = new[] { CollisionType.YasuoWall },
                });

            //Spells.Add(
            //    new SpellsData
            //    {
            //        ChampionName = "Lissandra",
            //        SpellName = "LissandraQShards",
            //        MenuName = 
            //        Slot = SpellSlot.Q,
            //        Type = SpellType.MissileLine,
            //        Delay = 250,
            //        Range = 825,
            //        Radius = 90,
            //        MissileSpeed = 2200,
            //        FixedRange = true,
            //        AddHitbox = true,
            //        DangerValue = 2,
            //        IsDangerous = false,
            //        MissileSpellName = "lissandraqshards",
            //        CollisionObjects = new[] { CollisionType.YasuoWall },
            //    });

            Spells.Add(
                new SpellsData
                {
                    ChampionName = "Lissandra",
                    SpellName = "LissandraE",
                    MenuName = "Lissandra E",
                    Slot = SpellSlot.E,
                    Type = SpellType.MissileLine,
                    Delay = 250,
                    Range = 1025,
                    Radius = 125,
                    MissileSpeed = 850,
                    FixedRange = true,
                    AddHitbox = true,
                    DangerValue = 2,
                    IsDangerous = false,
                    CcOrMgDamage = true,
                    MissileSpellName = "LissandraEMissile",
                    CollisionObjects = new[] { CollisionType.YasuoWall },
                });
            #endregion Lissandra

            #region Lucian

            Spells.Add(
                new SpellsData
                {
                    ChampionName = "Lucian",
                    SpellName = "LucianQ",
                    MenuName = "Lucian Q",
                    Slot = SpellSlot.Q,
                    Type = SpellType.Line,
                    Delay = 500,
                    Range = 1300,
                    Radius = 65,
                    MissileSpeed = int.MaxValue,
                    FixedRange = true,
                    AddHitbox = true,
                    DangerValue = 2,
                    IsDangerous = false,
                    CcOrMgDamage = false,
                    MissileSpellName = "LucianQ",
                });

            Spells.Add(
                new SpellsData
                {
                    ChampionName = "Lucian",
                    SpellName = "LucianW",
                    MenuName = "Lucian W",
                    Slot = SpellSlot.W,
                    Type = SpellType.MissileLine,
                    Delay = 250,
                    Range = 1000,
                    Radius = 55,
                    MissileSpeed = 1600,
                    FixedRange = true,
                    AddHitbox = true,
                    DangerValue = 2,
                    IsDangerous = false,
                    CcOrMgDamage = true,
                    MissileSpellName = "lucianwmissile",
                    CollisionObjects = new[] { CollisionType.AiHeroClient, CollisionType.ObjAiMinion, CollisionType.YasuoWall },
                });

            Spells.Add(
                new SpellsData
                {
                    ChampionName = "Lucian",
                    SpellName = "LucianRMis",
                    MenuName = "Lucian R",
                    Slot = SpellSlot.R,
                    Type = SpellType.MissileLine,
                    Delay = 500,
                    Range = 1400,
                    Radius = 110,
                    MissileSpeed = 2800,
                    FixedRange = true,
                    AddHitbox = true,
                    DangerValue = 4,
                    IsDangerous = false,
                    CcOrMgDamage = false,
                    MissileSpellName = "lucianrmissileoffhand",
                    ExtraMissileNames = new[] { "lucianrmissile" },
                    CollisionObjects = new[] { CollisionType.AiHeroClient, CollisionType.ObjAiMinion, CollisionType.YasuoWall },
                    DontCheckForDuplicates = true,
                });
            #endregion Lucian

            #region Lulu

            Spells.Add(
                new SpellsData
                {
                    ChampionName = "Lulu",
                    SpellName = "LuluQ",
                    MenuName = "Lulu Q",
                    Slot = SpellSlot.Q,
                    Type = SpellType.MissileLine,
                    Delay = 250,
                    Range = 950,
                    Radius = 60,
                    MissileSpeed = 1450,
                    FixedRange = true,
                    AddHitbox = true,
                    DangerValue = 2,
                    IsDangerous = false,
                    CcOrMgDamage = true,
                    MissileSpellName = "LuluQMissile",
                    CollisionObjects = new[] { CollisionType.YasuoWall },
                });

            Spells.Add(
                new SpellsData
                {
                    ChampionName = "Lulu",
                    SpellName = "LuluQPix",
                    MenuName = "Pix Q",
                    Slot = SpellSlot.Q,
                    Type = SpellType.MissileLine,
                    Delay = 250,
                    Range = 950,
                    Radius = 60,
                    MissileSpeed = 1450,
                    FixedRange = true,
                    AddHitbox = true,
                    DangerValue = 2,
                    IsDangerous = false,
                    CcOrMgDamage = true,
                    MissileSpellName = "LuluQMissileTwo",
                    CollisionObjects = new[] { CollisionType.YasuoWall },
                });
            #endregion Lulu

            #region Lux

            Spells.Add(
                new SpellsData
                {
                    ChampionName = "Lux",
                    SpellName = "LuxLightBinding",
                    MenuName = "Lux Q",
                    Slot = SpellSlot.Q,
                    Type = SpellType.MissileLine,
                    Delay = 250,
                    Range = 1300,
                    Radius = 70,
                    MissileSpeed = 1200,
                    FixedRange = true,
                    AddHitbox = true,
                    DangerValue = 4,
                    IsDangerous = true,
                    CcOrMgDamage = true,
                    MissileSpellName = "LuxLightBindingMis",
                });

            Spells.Add(
                new SpellsData
                {
                    ChampionName = "Lux",
                    SpellName = "LuxLightStrikeKugel",
                    MenuName = "Lux E",
                    Slot = SpellSlot.E,
                    Type = SpellType.Circular,
                    Delay = 250,
                    Range = 1100,
                    Radius = 340,
                    MissileSpeed = 1300,
                    FixedRange = false,
                    AddHitbox = true,
                    DangerValue = 2,
                    IsDangerous = false,
                    CcOrMgDamage = true,
                    MissileSpellName = "LuxLightStrikeKugel",
                    ExtraDuration = 5500,
                    ToggleParticleName = "Lux_.+_E_tar_aoe_",
                    DontCross = true,
                    CanBeRemoved = false,
                    CollisionObjects = new[] { CollisionType.YasuoWall },
                });

            Spells.Add(
                new SpellsData
                {
                    ChampionName = "Lux",
                    SpellName = "LuxMaliceCannon",
                    MenuName = "Lux R",
                    Slot = SpellSlot.R,
                    Type = SpellType.Line,
                    Delay = 1000,
                    Range = 3500,
                    Radius = 190,
                    MissileSpeed = int.MaxValue,
                    FixedRange = true,
                    AddHitbox = true,
                    DangerValue = 5,
                    IsDangerous = true,
                    CcOrMgDamage = true,
                    MissileSpellName = "LuxMaliceCannon",
                });
            #endregion Lux

            #region Malphite

            Spells.Add(
                new SpellsData
                {
                    ChampionName = "Malphite",
                    SpellName = "UFSlash",
                    MenuName = "Malphite R",
                    Slot = SpellSlot.R,
                    Type = SpellType.Circular,
                    Delay = 0,
                    Range = 1000,
                    Radius = 270,
                    MissileSpeed = 1500,
                    FixedRange = false,
                    AddHitbox = true,
                    DangerValue = 5,
                    IsDangerous = true,
                    CcOrMgDamage = true,
                    MissileSpellName = "UFSlash",
                });
            #endregion Malphite

            #region Malzahar

            Spells.Add(
                new SpellsData
                {
                    ChampionName = "Malzahar",
                    SpellName = "MalzaharQ",
                    MenuName = "Malzahar Q",
                    Slot = SpellSlot.Q,
                    Type = SpellType.Line,
                    Delay = 750,
                    Range = 900,
                    Radius = 85,
                    MissileSpeed = int.MaxValue,
                    FixedRange = false,
                    AddHitbox = true,
                    DangerValue = 2,
                    CcOrMgDamage = true,
                    IsDangerous = false,
                    DontCross = true,
                    MissileSpellName = "MalzaharQ",
                });
            #endregion Malzahar

            #region MonkeyKing

            //Should I add R?
            /*Spells.Add(
            new SpellsData
            {
                CharName = "MonkeyKing",
                Dangerlevel = SpellDangerLevel.High,
                Name = "MonkeyKingSpinToWin",
                Radius = 225,
                Range = 300,
                SpellDelay = 250,
                SpellKey = SpellSlot.R,
                SpellName = "MonkeyKingSpinToWin",
                SpellType = SpellType.Circular,
                DefaultOff = true,
            });*/
            #endregion MonkeyKing

            #region Morgana

            Spells.Add(
                new SpellsData
                {
                    ChampionName = "Morgana",
                    SpellName = "DarkBindingMissile",
                    MenuName = "Morgana Q",
                    Slot = SpellSlot.Q,
                    Type = SpellType.MissileLine,
                    Delay = 250,
                    Range = 1300,
                    Radius = 80,
                    MissileSpeed = 1200,
                    FixedRange = true,
                    AddHitbox = true,
                    DangerValue = 3,
                    IsDangerous = true,
                    CcOrMgDamage = true,
                    MissileSpellName = "DarkBindingMissile",
                    CanBeRemoved = false,
                    CollisionObjects = new[] { CollisionType.AiHeroClient, CollisionType.ObjAiMinion, CollisionType.YasuoWall },
                });

            Spells.Add(
                 new SpellsData
                 {
                     ChampionName = "Morgana",
                     SpellName = "TormentedSoil",
                     MenuName = "Morgana W",
                     Slot = SpellSlot.W,
                     Type = SpellType.Circular,
                     Delay = 50,
                     Range = 1000,
                     Radius = 275,
                     MissileSpeed = int.MaxValue,
                     FixedRange = false,
                     AddHitbox = true,
                     DangerValue = 1,
                     IsDangerous = false,
                     DefaultDisable = true,
                     CcOrMgDamage = true,
                     MissileSpellName = "",
                     ExtraDuration = 5000,
                     DontCross = true,
                 });
            #endregion Morgana

            #region Nami

            Spells.Add(
                new SpellsData
                {
                    ChampionName = "Nami",
                    SpellName = "NamiQ",
                    MenuName = "Nami Q",
                    Slot = SpellSlot.Q,
                    Type = SpellType.Circular,
                    Delay = 950,
                    Range = 1625,
                    Radius = 150,
                    MissileSpeed = int.MaxValue,
                    FixedRange = false,
                    AddHitbox = true,
                    DangerValue = 3,
                    IsDangerous = true,
                    CcOrMgDamage = true,
                    MissileSpellName = "namiqmissile",
                });

            Spells.Add(
                new SpellsData
                {
                    ChampionName = "Nami",
                    SpellName = "NamiR",
                    MenuName = "Nami R",
                    Slot = SpellSlot.R,
                    Type = SpellType.MissileLine,
                    Delay = 500,
                    Range = 2750,
                    Radius = 260,
                    MissileSpeed = 850,
                    FixedRange = true,
                    AddHitbox = true,
                    DangerValue = 2,
                    IsDangerous = true,
                    MissileSpellName = "NamiRMissile",
                    CollisionObjects = new[] { CollisionType.YasuoWall },
                });

            #endregion Nami

            #region Nautilus

            Spells.Add(
                new SpellsData
                {
                    ChampionName = "Nautilus",
                    SpellName = "NautilusAnchorDrag",
                    MenuName = "Nautilus Q",
                    Slot = SpellSlot.Q,
                    Type = SpellType.MissileLine,
                    Delay = 250,
                    Range = 1250,
                    Radius = 90,
                    MissileSpeed = 2000,
                    FixedRange = true,
                    AddHitbox = true,
                    DangerValue = 4,
                    IsDangerous = true,
                    CcOrMgDamage = true,
                    MissileSpellName = "NautilusAnchorDragMissile",
                    CanBeRemoved = false,
                    CollisionObjects = new[] { CollisionType.AiHeroClient, CollisionType.ObjAiMinion, CollisionType.YasuoWall },  //Wall is collision too kappa                   
                });
            #endregion Nautilus

            #region Nidalee

            Spells.Add(
                new SpellsData
                {
                    ChampionName = "Nidalee",
                    SpellName = "JavelinToss",
                    MenuName = "Nidalee Q",
                    Slot = SpellSlot.Q,
                    Type = SpellType.MissileLine,
                    Delay = 250,
                    Range = 1500,
                    Radius = 40,
                    MissileSpeed = 1300,
                    FixedRange = true,
                    AddHitbox = true,
                    DangerValue = 3,
                    IsDangerous = true,
                    CcOrMgDamage = true,
                    MissileSpellName = "JavelinToss",
                    CanBeRemoved = false,
                    CollisionObjects = new[] { CollisionType.AiHeroClient, CollisionType.ObjAiMinion, CollisionType.YasuoWall },
                });
            #endregion Nidalee

            #region Nocturne

            Spells.Add(
                new SpellsData
                {
                    ChampionName = "Nocturne",
                    SpellName = "NocturneDuskbringer",
                    MenuName = "Nocturne Q",
                    Slot = SpellSlot.Q,
                    Type = SpellType.MissileLine,
                    Delay = 250,
                    Range = 1125,
                    Radius = 60,
                    MissileSpeed = 1400,
                    DangerValue = 1,
                    IsDangerous = false,
                    CcOrMgDamage = false,
                    MissileSpellName = "NocturneDuskbringer",
                    CollisionObjects = new[] { CollisionType.YasuoWall }
                });
            #endregion Nocturne

            #region Olaf

            Spells.Add(
                new SpellsData
                {
                    ChampionName = "Olaf",
                    SpellName = "OlafAxeThrowCast",
                    MenuName = "Olaf Q",
                    Slot = SpellSlot.Q,
                    Type = SpellType.MissileLine,
                    Delay = 250,
                    Range = 1000,
                    ExtraRange = 150,
                    Radius = 105,
                    MissileSpeed = 1600,
                    FixedRange = false,
                    AddHitbox = true,
                    DangerValue = 2,
                    IsDangerous = false,
                    CcOrMgDamage = false,
                    MissileSpellName = "olafaxethrow",
                    CanBeRemoved = false,
                    CollisionObjects = new[] { CollisionType.YasuoWall }
                });
            #endregion Olaf
            
            //Oriana R
            #region Orianna

            Spells.Add(
                new SpellsData
                {
                    ChampionName = "Orianna",
                    SpellName = "OriannasQ",
                    MenuName = "Orianna Q",
                    Slot = SpellSlot.Q,
                    Type = SpellType.MissileLine,
                    Delay = 0,
                    Range = 1500,
                    Radius = 80,
                    MissileSpeed = 1200,
                    FixedRange = false,
                    AddHitbox = true,
                    DangerValue = 2,
                    IsDangerous = false,
                    CcOrMgDamage = true,
                    MissileSpellName = "orianaizuna",
                    CollisionObjects = new[] { CollisionType.YasuoWall },
                });

            Spells.Add(
                new SpellsData
                {
                    ChampionName = "Orianna",
                    SpellName = "OriannaQend",
                    Slot = SpellSlot.Q,
                    Type = SpellType.Circular,
                    Delay = 0,
                    Range = 1500,
                    Radius = 90,
                    MissileSpeed = 1200,
                    FixedRange = false,
                    AddHitbox = true,
                    DangerValue = 2,
                    IsDangerous = false,
                    CcOrMgDamage = true,
                    MissileSpellName = "",
                    CollisionObjects = new[] { CollisionType.YasuoWall },
                });

            Spells.Add(
                new SpellsData
                {
                    ChampionName = "Orianna",
                    SpellName = "OrianaDissonanceCommand-",
                    Slot = SpellSlot.W,
                    Type = SpellType.Circular,
                    Delay = 250,
                    Range = 0,
                    Radius = 255,
                    MissileSpeed = int.MaxValue,
                    FixedRange = true,
                    AddHitbox = true,
                    DangerValue = 1,
                    IsDangerous = false,
                    CcOrMgDamage = true,
                    MissileSpellName = "OrianaDissonanceCommand-",
                    FromObject = "yomu_ring_",
                    SourceObjectName = "w_dissonance_ball" //Orianna_Base_W_Dissonance_ball_green.troy & Orianna_Base_W_Dissonance_cas_green.troy
                });
            #endregion Orianna

            #region Pantheon

            //Should I add Pantheon?
            //Spells.Add(
            //new SpellsData
            //{
            //    Angle = 35,
            //    ChampName = "Pantheon",
            //    Dangerlevel = SpellDangerLevel.Medium,
            //    Name = "Heartseeker",
            //    Radius = 100,
            //    Range = 650,
            //    SpellDelay = 1000,
            //    SpellKey = SpellSlot.E,
            //    SpellName = "PantheonE",
            //    SpellType = SpellType.Cone,

            //});
            #endregion Pantheon

            //Poppy
            #region Poppy

            Spells.Add(
                new SpellsData
                {
                    ChampionName = "Poppy",
                    SpellName = "PoppyQ",
                    MenuName = "Poppy Q",
                    Slot = SpellSlot.Q,
                    Type = SpellType.Line,
                    Delay = 500,
                    Range = 430,
                    Radius = 100,
                    MissileSpeed = int.MaxValue,
                    FixedRange = true,
                    AddHitbox = true,
                    DangerValue = 1,
                    IsDangerous = false,
                    CcOrMgDamage = false,
                    MissileSpellName = "PoppyQ",
                });

            Spells.Add(
                new SpellsData
                {
                    ChampionName = "Poppy",
                    SpellName = "PoppyRSpell",
                    MenuName = "Poppy R",
                    Slot = SpellSlot.R,
                    Type = SpellType.MissileLine,
                    Delay = 300,
                    Range = 1200,
                    Radius = 100,
                    MissileSpeed = 1600,
                    FixedRange = true,
                    AddHitbox = true,
                    DangerValue = 3,
                    IsDangerous = true,
                    CcOrMgDamage = true,
                    MissileSpellName = "PoppyRMissile",
                    CanBeRemoved = false,
                    CollisionObjects = new[] { CollisionType.AiHeroClient, CollisionType.YasuoWall },
                });
            #endregion

            #region Quinn

            Spells.Add(
                new SpellsData
                {
                    ChampionName = "Quinn",
                    SpellName = "QuinnQ",
                    MenuName = "Quinn Q",
                    Slot = SpellSlot.Q,
                    Type = SpellType.MissileLine,
                    Delay = 313,
                    Range = 1050,
                    Radius = 60,
                    MissileSpeed = 1550,
                    FixedRange = true,
                    AddHitbox = true,
                    DangerValue = 3,
                    IsDangerous = true,
                    CcOrMgDamage = false,
                    MissileSpellName = "QuinnQ",
                    CanBeRemoved = false,
                    CollisionObjects = new[] { CollisionType.AiHeroClient, CollisionType.ObjAiMinion, CollisionType.YasuoWall },
                });
            #endregion Quinn

            #region RekSai

            Spells.Add(
                new SpellsData
                {
                    ChampionName = "RekSai",
                    SpellName = "reksaiqburrowed",
                    MenuName = "Reksai Q",
                    Slot = SpellSlot.Q,
                    Type = SpellType.MissileLine,
                    Delay = 500,
                    Range = 1625,
                    Radius = 60,
                    MissileSpeed = 1950,
                    FixedRange = true,
                    AddHitbox = true,
                    DangerValue = 1,
                    IsDangerous = false,
                    MissileSpellName = "RekSaiQBurrowedMis",
                    CollisionObjects = new[] { CollisionType.AiHeroClient, CollisionType.ObjAiMinion, CollisionType.YasuoWall },
                });
            #endregion RekSai

            #region Rengar

            Spells.Add(
                new SpellsData
                {
                    ChampionName = "Rengar",
                    SpellName = "RengarE",
                    MenuName = "Rengar E",
                    Slot = SpellSlot.E,
                    Type = SpellType.MissileLine,
                    Delay = 250,
                    Range = 1000,
                    Radius = 70,
                    MissileSpeed = 1500,
                    FixedRange = true,
                    AddHitbox = true,
                    DangerValue = 3,
                    IsDangerous = true,
                    MissileSpellName = "RengarEFinal",
                    CanBeRemoved = false,
                    CollisionObjects = new[] { CollisionType.AiHeroClient, CollisionType.ObjAiMinion, CollisionType.YasuoWall },
                });

            #endregion Rengar

            #region Riven

            Spells.Add(
            new SpellsData
            {
                ChampionName = "Riven",
                SpellName = "RivenMartyr",
                MenuName = "Riven W",
                Slot = SpellSlot.W,
                Type = SpellType.Circular,
                Delay = 250,
                Range = 0,
                Radius = 280,
                MissileSpeed = int.MaxValue,
                FixedRange = true,
                AddHitbox = false,
                DangerValue = 3,
                IsDangerous = true,
                CcOrMgDamage = true,
            });
            Spells.Add(
                new SpellsData
                {
                    ChampionName = "Riven",
                    SpellName = "rivenizunablade",
                    MenuName = "Riven R",
                    Slot = SpellSlot.R,
                    Type = SpellType.MissileLine,
                    Delay = 250,
                    Range = 1100,
                    Radius = 125,
                    MissileSpeed = 1600,
                    FixedRange = false,
                    AddHitbox = false,
                    DangerValue = 4,
                    IsDangerous = true,
                    CcOrMgDamage = false,
                    MultipleNumber = 3,
                    MultipleAngle = 15 * (float)Math.PI / 180,
                    MissileSpellName = "RivenLightsaberMissile",
                    ExtraMissileNames = new[] { "RivenLightsaberMissileSide" }
                });
            #endregion Riven

            #region Rumble

            Spells.Add(
                new SpellsData
                {
                    ChampionName = "Rumble",
                    SpellName = "RumbleGrenade",
                    MenuName = "Rumble E",
                    Slot = SpellSlot.E,
                    Type = SpellType.MissileLine,
                    Delay = 250,
                    Range = 950,
                    Radius = 60,
                    MissileSpeed = 2000,
                    FixedRange = true,
                    AddHitbox = true,
                    DangerValue = 2,
                    IsDangerous = false,
                    CcOrMgDamage = true,
                    MissileSpellName = "RumbleGrenade",
                    CanBeRemoved = false,
                    CollisionObjects = new[] { CollisionType.AiHeroClient, CollisionType.ObjAiMinion, CollisionType.YasuoWall },
                });

            Spells.Add(
                new SpellsData
                {
                    ChampionName = "Rumble",
                    SpellName = "RumbleCarpetBombM",
                    MenuName = "Rumble R",
                    Slot = SpellSlot.R,
                    Type = SpellType.MissileLine,
                    Delay = 400,
                    MissileDelayed = true,
                    Range = 1200,
                    Radius = 200,
                    MissileSpeed = 1600,
                    FixedRange = true,
                    AddHitbox = true,
                    DangerValue = 4,
                    IsDangerous = false,
                    CcOrMgDamage = true,
                    DontCross = true,
                    MissileSpellName = "RumbleCarpetBombMissile",
                    CanBeRemoved = false,
                });
            #endregion Rumble

            #region Ryze

            Spells.Add(
                new SpellsData
                {
                    ChampionName = "Ryze",
                    SpellName = "RyzeQ",
                    MenuName = "Ryze Q",
                    Slot = SpellSlot.Q,
                    Type = SpellType.MissileLine,
                    Delay = 250,
                    Range = 1000,
                    Radius = 55,
                    MissileSpeed = 1700,
                    FixedRange = true,
                    AddHitbox = true,
                    DangerValue = 1,
                    IsDangerous = false,
                    CcOrMgDamage = true,
                    MissileSpellName = "RyzeQ",
                    CanBeRemoved = false,
                    CollisionObjects = new[] { CollisionType.AiHeroClient, CollisionType.ObjAiMinion, CollisionType.YasuoWall },
                });

            #endregion Ryze

            #region Sejuani
            Spells.Add(
                new SpellsData
                {
                    ChampionName = "Sejuani",
                    SpellName = "SejuaniArcticAssault",
                    MenuName = " Sejuani Q",
                    Slot = SpellSlot.Q,
                    Type = SpellType.MissileLine,
                    Delay = 0,
                    Range = 900,
                    Radius = 70,
                    MissileSpeed = 1600,
                    FixedRange = false,
                    AddHitbox = true,
                    DangerValue = 3,
                    IsDangerous = true,
                    CcOrMgDamage = true,
                    MissileSpellName = "",
                    ExtraRange = 200,
                    CollisionObjects = new[] { CollisionType.AiHeroClient, CollisionType.ObjAiMinion, CollisionType.YasuoWall },
                });

            Spells.Add(
                new SpellsData
                {
                    ChampionName = "Sejuani",
                    SpellName = "SejuaniGlacialPrisonStart",
                    MenuName = "Sejuani R",
                    Slot = SpellSlot.R,
                    Type = SpellType.MissileLine,
                    Delay = 250,
                    Range = 1100,
                    Radius = 110,
                    MissileSpeed = 1600,
                    FixedRange = true,
                    AddHitbox = true,
                    DangerValue = 5,
                    IsDangerous = true,
                    CcOrMgDamage = true,
                    EndExplosionRadius = 350,
                    MissileSpellName = "sejuaniglacialprison",
                    CanBeRemoved = false,
                    CollisionObjects = new[] { CollisionType.AiHeroClient, CollisionType.YasuoWall },
                });
            #endregion Sejuani

            #region Shen

            Spells.Add(
                new SpellsData
                {
                    ChampionName = "Shen",
                    SpellName = "ShenE",
                    MenuName = "Shen R",
                    Slot = SpellSlot.E,
                    Type = SpellType.MissileLine,
                    Delay = 0,
                    Range = 650,
                    Radius = 90,
                    MissileSpeed = 1600,
                    FixedRange = false,
                    AddHitbox = true,
                    DangerValue = 3,
                    IsDangerous = true,
                    CcOrMgDamage = true,
                    MissileSpellName = "ShenE",
                    ExtraRange = 200,
                });

            #endregion Shen

            #region Shyvana

            Spells.Add(
                new SpellsData
                {
                    ChampionName = "Shyvana",
                    SpellName = "ShyvanaFireball",
                    MenuName = "Shyvana Human E",
                    Slot = SpellSlot.E,
                    Type = SpellType.MissileLine,
                    Delay = 250,
                    Range = 950,
                    Radius = 60,
                    MissileSpeed = 1700,
                    FixedRange = true,
                    AddHitbox = true,
                    DangerValue = 2,
                    IsDangerous = false,
                    CcOrMgDamage = false,
                    MissileSpellName = "ShyvanaFireballMissile",
                    CollisionObjects = new[] { CollisionType.YasuoWall },
                });

            Spells.Add(
                new SpellsData
                {
                    ChampionName = "Shyvana",
                    SpellName = "shyvanafireballdragon2",
                    MenuName = "Shyvana Dragon E",
                    Slot = SpellSlot.E,
                    Type = SpellType.MissileLine,
                    Delay = 250,
                    Range = 850,
                    Radius = 70,
                    MissileSpeed = 2000,
                    FixedRange = true,
                    AddHitbox = true,
                    DangerValue = 2,
                    IsDangerous = false,
                    CcOrMgDamage = false,
                    MissileSpellName = "ShyvanaFireballDragonFxMissile",
                    ExtraRange = 200,
                    MultipleNumber = 5,
                    MultipleAngle = 10 * (float)Math.PI / 180
                });

            Spells.Add(
                new SpellsData
                {
                    ChampionName = "Shyvana",
                    SpellName = "ShyvanaTransformCast",
                    Slot = SpellSlot.R,
                    Type = SpellType.MissileLine,
                    Delay = 250,
                    Range = 1000,
                    Radius = 150,
                    MissileSpeed = 1500,
                    FixedRange = true,
                    AddHitbox = true,
                    DangerValue = 3,
                    IsDangerous = true,
                    CcOrMgDamage = true,
                    MissileSpellName = "ShyvanaTransformCast",
                    ExtraRange = 200,
                });
            #endregion Shyvana

            #region Sion

            Spells.Add(
                new SpellsData
                {
                    ChampionName = "Sion",
                    SpellName = "SionE",
                    Slot = SpellSlot.E,
                    Type = SpellType.Line,
                    Delay = 250,
                    Range = 800,
                    Radius = 80,
                    MissileSpeed = int.MaxValue,
                    FixedRange = true,
                    AddHitbox = true,
                    DangerValue = 3,
                    IsDangerous = true,
                    CcOrMgDamage = true,
                    MissileSpellName = "SionEMissile",
                });

            Spells.Add(
                new SpellsData
                {
                    ChampionName = "Sion",
                    SpellName = "SionR",
                    Slot = SpellSlot.R,
                    Type = SpellType.MissileLine,
                    Delay = 500,
                    Range = 800,
                    Radius = 120,
                    MissileSpeed = 1000,
                    FixedRange = true,
                    AddHitbox = true,
                    DangerValue = 3,
                    IsDangerous = true,
                    CcOrMgDamage = true,
                    CollisionObjects = new[] { CollisionType.AiHeroClient }, //Wall too
                });
            #endregion Sion

            #region Sivir
            
            Spells.Add(
                new SpellsData
                {
                    ChampionName = "Sivir",
                    SpellName = "SivirQ",
                    MenuName = "Sivir Q",
                    Slot = SpellSlot.Q,
                    Type = SpellType.MissileLine,
                    Delay = 250,
                    Range = 1250,
                    Radius = 90,
                    MissileSpeed = 1350,
                    FixedRange = true,
                    AddHitbox = true,
                    DangerValue = 1,
                    IsDangerous = false,
                    CcOrMgDamage = false,
                    MissileSpellName = "SivirQMissile",
                    CollisionObjects = new[] { CollisionType.YasuoWall },
                });
            Spells.Add(
                new SpellsData
                {
                    ChampionName = "Sivir",
                    SpellName = "SivirQReturn",
                    MenuName = "Sivir Q Return",
                    Slot = SpellSlot.Q,
                    Type = SpellType.MissileLine,
                    Delay = 0,
                    Range = 1250,
                    Radius = 100,
                    MissileSpeed = 1350,
                    FixedRange = true,
                    AddHitbox = true,
                    DangerValue = 2,
                    IsDangerous = false,
                    CcOrMgDamage = false,
                    MissileSpellName = "SivirQMissileReturn",
                    DisableFowDetection = false,
                    MissileFollowsUnit = true,
                    CollisionObjects = new[] { CollisionType.YasuoWall },
                });

            #endregion Sivir

            #region Skarner

            Spells.Add(
                new SpellsData
                {
                    ChampionName = "Skarner",
                    SpellName = "SkarnerFracture",
                    MenuName = "Skarner E",
                    Slot = SpellSlot.E,
                    Type = SpellType.MissileLine,
                    Delay = 250,
                    Range = 1000,
                    Radius = 70,
                    MissileSpeed = 1500,
                    FixedRange = true,
                    AddHitbox = true,
                    DangerValue = 2,
                    IsDangerous = false,
                    CcOrMgDamage = false,
                    MissileSpellName = "SkarnerFractureMissile",
                    CollisionObjects = new[] { CollisionType.YasuoWall },
                });
            #endregion Skarner

            #region Sona

            Spells.Add(
                new SpellsData
                {
                    ChampionName = "Sona",
                    SpellName = "SonaR",
                    MenuName = "Sona R",
                    Slot = SpellSlot.R,
                    Type = SpellType.MissileLine,
                    Delay = 250,
                    Range = 1000,
                    Radius = 140,
                    MissileSpeed = 2400,
                    FixedRange = true,
                    AddHitbox = true,
                    DangerValue = 5,
                    IsDangerous = true,
                    CcOrMgDamage = true,
                    MissileSpellName = "SonaR",
                    CollisionObjects = new[] { CollisionType.YasuoWall },
                });
            #endregion Sona

            #region Soraka

            Spells.Add(
               new SpellsData
               {
                   ChampionName = "Soraka",
                   SpellName = "SorakaQ",
                   MenuName = "Soraka Q",
                   Slot = SpellSlot.Q,
                   Type = SpellType.Circular,
                   Delay = 500,
                   Range = 950,
                   Radius = 300,
                   MissileSpeed = 1750,
                   FixedRange = false,
                   AddHitbox = true,
                   DangerValue = 2,
                   IsDangerous = false,
                   CcOrMgDamage = true,
                   MissileSpellName = "",
               });

            Spells.Add(
            new SpellsData
            {
                ChampionName = "Soraka",
                SpellName = "SorakaE",
                MenuName = "Soraka E",
                Slot = SpellSlot.E,
                Type = SpellType.Circular,
                Delay = 250,
                Range = 925,
                Radius = 275,
                MissileSpeed = int.MaxValue,
                FixedRange = false,
                AddHitbox = true,
                DangerValue = 3,
                IsDangerous = true,
                CcOrMgDamage = true,
                DontCross = true,
                MissileSpellName = "",
            });
            #endregion Soraka

            #region Swain

            Spells.Add(
                new SpellsData
                {
                    ChampionName = "Swain",
                    SpellName = "SwainShadowGrasp",
                    MenuName = "Swain W",
                    Slot = SpellSlot.W,
                    Type = SpellType.Circular,
                    Delay = 1100,
                    Range = 900,
                    Radius = 180,
                    MissileSpeed = int.MaxValue,
                    FixedRange = false,
                    AddHitbox = true,
                    DangerValue = 3,
                    IsDangerous = true,
                    CcOrMgDamage = true,
                    MissileSpellName = "SwainShadowGrasp",
                });
            #endregion Swain

            //Should find E and E-Q data
            #region Syndra

            Spells.Add(
                new SpellsData
                {
                    ChampionName = "Syndra",
                    SpellName = "SyndraQ",
                    MenuName = "Syndra Q",
                    Slot = SpellSlot.Q,
                    Type = SpellType.Circular,
                    Delay = 600,
                    Range = 800,
                    Radius = 150,
                    MissileSpeed = int.MaxValue,
                    FixedRange = false,
                    AddHitbox = true,
                    DangerValue = 2,
                    IsDangerous = false,
                    CcOrMgDamage = true,
                    MissileSpellName = "SyndraQ",
                });

            Spells.Add(
                new SpellsData
                {
                    ChampionName = "Syndra",
                    SpellName = "syndrawcast",
                    MenuName = "Syndra W",
                    Slot = SpellSlot.W,
                    Type = SpellType.Circular,
                    Delay = 250,
                    Range = 950,
                    Radius = 210,
                    MissileSpeed = 1450,
                    FixedRange = false,
                    AddHitbox = true,
                    DangerValue = 2,
                    IsDangerous = false,
                    CcOrMgDamage = true,
                    MissileSpellName = "syndrawcast",
                });

            //Spells.Add(
            //    new SpellsData
            //    {
            //        ChampionName = "Syndra",
            //        SpellName = "syndrae5",
            //        Slot = SpellSlot.E,
            //        Type = SkillShotType.SkillshotMissileLine,
            //        Delay = 0,
            //        Range = 950,
            //        Radius = 100,
            //        MissileSpeed = 2000,
            //        FixedRange = false,
            //        AddHitbox = true,
            //        DangerValue = 2,
            //        IsDangerous = false,
            //        MissileSpellName = "syndrae5",
            //        DisableFowDetection = false,
            //    });

            //Spells.Add(
            //    new SpellsData
            //    {
            //        ChampionName = "Syndra",
            //        SpellName = "SyndraE",
            //        Slot = SpellSlot.E,
            //        Type = SkillShotType.SkillshotMissileLine,
            //        Delay = 0,
            //        Range = 950,
            //        Radius = 100,
            //        MissileSpeed = 2000,
            //        FixedRange = false,
            //        AddHitbox = true,
            //        DangerValue = 2,
            //        IsDangerous = false,
            //        DisableFowDetection = false,
            //        MissileSpellName = "SyndraE",
            //    });
            #endregion Syndra

            #region TahmKench

            Spells.Add(
                new SpellsData
                {
                    ChampionName = "TahmKench",
                    SpellName = "TahmKenchQ",
                    MenuName = "TahmKench Q",
                    Slot = SpellSlot.Q,
                    Type = SpellType.MissileLine,
                    Delay = 250,
                    Range = 951,
                    Radius = 90,
                    MissileSpeed = 2800,
                    FixedRange = true,
                    AddHitbox = true,
                    DangerValue = 3,
                    IsDangerous = true,
                    MissileSpellName = "tahmkenchqmissile",
                    CanBeRemoved = false,
                    CollisionObjects = new[] { CollisionType.AiHeroClient, CollisionType.ObjAiMinion, CollisionType.YasuoWall },
                });

            #endregion TahmKench

            #region Taliyah

            Spells.Add(
                new SpellsData
                {
                    ChampionName = "Taliyah",
                    SpellName = "TaliyahQ",
                    MenuName = "Taliyah Q",
                    Slot = SpellSlot.Q,
                    Type = SpellType.MissileLine,
                    Delay = 250,
                    Range = 1000,
                    Radius = 100,
                    MissileSpeed = 3600,
                    FixedRange = true,
                    AddHitbox = true,
                    DangerValue = 2,
                    IsDangerous = false,
                    CcOrMgDamage = true,
                    MissileSpellName = "TaliyahQMis",
                    CollisionObjects = new[] { CollisionType.AiHeroClient, CollisionType.ObjAiMinion, CollisionType.YasuoWall },
                });

            Spells.Add(
                new SpellsData
                {
                    ChampionName = "Taliyah",
                    SpellName = "TaliyahW",
                    MenuName = "Taliyah W",
                    Slot = SpellSlot.W,
                    Type = SpellType.Circular,
                    Delay = 600,
                    Range = 900,
                    Radius = 200,
                    MissileSpeed = int.MaxValue,
                    FixedRange = false,
                    AddHitbox = true,
                    DangerValue = 3,
                    IsDangerous = true,
                    CcOrMgDamage = true,
                    MissileSpellName = "TaliyahW",
                });

            #endregion Taliyah

            #region Talon

            Spells.Add(
                new SpellsData
                {
                    ChampionName = "Talon",
                    SpellName = "TalonRake",
                    MenuName = "Talon W",
                    Slot = SpellSlot.W,
                    Type = SpellType.MissileLine,
                    Delay = 250,
                    Range = 800,
                    Radius = 80,
                    MissileSpeed = 2300,
                    FixedRange = true,
                    AddHitbox = true,
                    DangerValue = 2,
                    IsDangerous = false,
                    CcOrMgDamage = false,
                    MultipleNumber = 3,
                    MultipleAngle = 20 * (float)Math.PI / 180,
                    MissileSpellName = "talonrakemissileone",
                });

            Spells.Add(
                new SpellsData
                {
                    ChampionName = "Talon",
                    SpellName = "TalonRakeReturn",
                    MenuName = "Talon W Return",
                    Slot = SpellSlot.W,
                    Type = SpellType.MissileLine,
                    Delay = 250,
                    Range = 800,
                    Radius = 80,
                    MissileSpeed = 1850,
                    FixedRange = true,
                    AddHitbox = true,
                    DangerValue = 2,
                    IsDangerous = false,
                    CcOrMgDamage = false,
                    MultipleNumber = 3,
                    MultipleAngle = 20 * (float)Math.PI / 180,
                    MissileSpellName = "talonrakemissiletwo",
                });
            #endregion Talon

            #region Taric

            Spells.Add(
                new SpellsData
                {
                    ChampionName = "Taric",
                    SpellName = "TaricE",
                    MenuName = "Taric E",
                    Slot = SpellSlot.E,
                    Type = SpellType.Line,
                    Delay = 1000,
                    Range = 750,
                    Radius = 100,
                    MissileSpeed = int.MaxValue,
                    FixedRange = true,
                    AddHitbox = true,
                    DangerValue = 3,
                    IsDangerous = true,
                    CcOrMgDamage = true,
                    MissileSpellName = "TaricE"
                });

            #endregion Taric

            #region Thresh

            Spells.Add(
                new SpellsData
                {
                    ChampionName = "Thresh",
                    SpellName = "ThreshQ",
                    MenuName = "Thresh Q",
                    Slot = SpellSlot.Q,
                    Type = SpellType.MissileLine,
                    Delay = 500,
                    Range = 1100,
                    Radius = 70,
                    MissileSpeed = 1900,
                    FixedRange = true,
                    AddHitbox = true,
                    DangerValue = 4,
                    IsDangerous = true,
                    CcOrMgDamage = true,
                    MissileSpellName = "ThreshQMissile",
                    CanBeRemoved = false,
                    CollisionObjects = new[] { CollisionType.AiHeroClient, CollisionType.ObjAiMinion, CollisionType.YasuoWall },
                });

            Spells.Add(
                new SpellsData
                {
                    ChampionName = "Thresh",
                    SpellName = "ThreshEFlay",
                    MenuName = "Thresh E",
                    Slot = SpellSlot.E,
                    Type = SpellType.MissileLine,
                    Delay = 125,
                    Range = 1075,
                    Radius = 110,
                    MissileSpeed = 2000,
                    FixedRange = true,
                    AddHitbox = true,
                    DangerValue = 3,
                    IsDangerous = true,
                    CcOrMgDamage = true,
                    Centered = true,
                    MissileSpellName = "ThreshEMissile1",
                });
            #endregion Thresh

            #region Tristana

            Spells.Add(
                new SpellsData
                {
                    ChampionName = "Tristana",
                    SpellName = "RocketJump",
                    MenuName = "Tristana W",
                    Slot = SpellSlot.W,
                    Type = SpellType.Circular,
                    Delay = 500,
                    Range = 900,
                    Radius = 270,
                    MissileSpeed = 1500,
                    FixedRange = false,
                    AddHitbox = true,
                    DangerValue = 1,
                    IsDangerous = false,
                    DefaultDisable = true,
                    CcOrMgDamage = false,
                    MissileSpellName = "RocketJump",
                });

            #endregion Tristana

            #region Tryndamere

            Spells.Add(
                new SpellsData
                {
                    ChampionName = "Tryndamere",
                    SpellName = "slashCast",
                    MenuName = "Tryndamere E",
                    Slot = SpellSlot.E,
                    Type = SpellType.MissileLine,
                    Delay = 0,
                    Range = 660,
                    Radius = 93,
                    MissileSpeed = 1300,
                    FixedRange = false,
                    AddHitbox = true,
                    DangerValue = 2,
                    IsDangerous = false,
                    CcOrMgDamage = false,
                    MissileSpellName = "slashCast",
                });

            #endregion Tryndamere

            #region TwistedFate

            Spells.Add(
                new SpellsData
                {
                    ChampionName = "TwistedFate",
                    SpellName = "WildCards",
                    MenuName = "Twisted Fate W",
                    Slot = SpellSlot.Q,
                    Type = SpellType.MissileLine,
                    Delay = 250,
                    Range = 1450,
                    Radius = 40,
                    MissileSpeed = 1000,
                    FixedRange = true,
                    AddHitbox = true,
                    DangerValue = 2,
                    IsDangerous = false,
                    CcOrMgDamage = true,
                    MissileSpellName = "SealFateMissile",
                    MultipleNumber = 3,
                    MultipleAngle = 28 * (float)Math.PI / 180,
                    CollisionObjects = new[] { CollisionType.YasuoWall },
                });
            #endregion TwistedFate

            #region Twitch

            Spells.Add(
                new SpellsData
                {
                    ChampionName = "Twitch",
                    SpellName = "TwitchVenomCask",
                    MenuName = "Twitch W",
                    Slot = SpellSlot.W,
                    Type = SpellType.Circular,
                    Delay = 250,
                    Range = 900,
                    Radius = 275,
                    MissileSpeed = 1400,
                    FixedRange = false,
                    AddHitbox = true,
                    DangerValue = 2,
                    IsDangerous = false,
                    CcOrMgDamage = false,
                    MissileSpellName = "TwitchVenomCaskMissile",
                    CollisionObjects = new[] { CollisionType.YasuoWall },
                });

            #endregion Twitch

            #region Urgot

            Spells.Add(
                new SpellsData
                {
                    ChampionName = "Urgot",
                    SpellName = "UrgotHeatseekingLineMissile",
                    MenuName = "Urgot Q",
                    Slot = SpellSlot.Q,
                    Type = SpellType.MissileLine,
                    Delay = 125,
                    Range = 1000,
                    Radius = 60,
                    MissileSpeed = 1600,
                    FixedRange = true,
                    AddHitbox = true,
                    DangerValue = 1,
                    IsDangerous = false,
                    CcOrMgDamage = true,
                    MissileSpellName = "UrgotHeatseekingLineMissile",
                    CollisionObjects = new[] { CollisionType.AiHeroClient, CollisionType.ObjAiMinion, CollisionType.YasuoWall },
                    CanBeRemoved = false,
                });

            Spells.Add(
                new SpellsData
                {
                    ChampionName = "Urgot",
                    SpellName = "UrgotPlasmaGrenade",
                    MenuName = "Urgot E",
                    Slot = SpellSlot.E,
                    Type = SpellType.Circular,
                    Delay = 250,
                    Range = 1100,
                    Radius = 210,
                    MissileSpeed = 1500,
                    FixedRange = false,
                    AddHitbox = true,
                    DangerValue = 3,
                    IsDangerous = false,
                    CcOrMgDamage = true,
                    MissileSpellName = "UrgotPlasmaGrenadeBoom",
                });
            #endregion Urgot

            #region Varus

            Spells.Add(
                new SpellsData
                {
                    ChampionName = "Varus",
                    SpellName = "VarusQMissilee",
                    MenuName = "Varus Q",
                    Slot = SpellSlot.Q,
                    Type = SpellType.MissileLine,
                    Delay = 250,
                    Range = 1800,
                    Radius = 70,
                    MissileSpeed = 1900,
                    FixedRange = true,
                    AddHitbox = true,
                    DangerValue = 2,
                    IsDangerous = false,
                    CcOrMgDamage = false,
                    MissileSpellName = "VarusQMissile",
                    CollisionObjects = new[] { CollisionType.YasuoWall },
                });

            Spells.Add(
                new SpellsData
                {
                    ChampionName = "Varus",
                    SpellName = "VarusE",
                    MenuName = "Varus E",
                    Slot = SpellSlot.E,
                    Type = SpellType.Circular,
                    Delay = 1000,
                    Range = 925,
                    Radius = 235,
                    MissileSpeed = 1500,
                    FixedRange = false,
                    AddHitbox = true,
                    DangerValue = 2,
                    IsDangerous = false,
                    CcOrMgDamage = true,
                    MissileSpellName = "VarusE",
                });

            Spells.Add(
                new SpellsData
                {
                    ChampionName = "Varus",
                    SpellName = "VarusR",
                    MenuName = "Varus R",
                    Slot = SpellSlot.R,
                    Type = SpellType.MissileLine,
                    Delay = 250,
                    Range = 1200,
                    Radius = 120,
                    MissileSpeed = 1950,
                    FixedRange = true,
                    AddHitbox = true,
                    DangerValue = 4,
                    IsDangerous = true,
                    CcOrMgDamage = true,
                    MissileSpellName = "VarusRMissile",
                    CanBeRemoved = false,
                    CollisionObjects = new[] { CollisionType.AiHeroClient, CollisionType.YasuoWall },
                });
            #endregion Varus

            #region Veigar

            Spells.Add(
                new SpellsData
                {
                    ChampionName = "Veigar",
                    SpellName = "VeigarBalefulStrike",
                    MenuName = "Veigar Q",
                    Slot = SpellSlot.Q,
                    Type = SpellType.MissileLine,
                    Delay = 250,
                    Range = 950,
                    Radius = 70,
                    MissileSpeed = 2200,
                    FixedRange = true,
                    AddHitbox = true,
                    DangerValue = 2,
                    IsDangerous = false,
                    CcOrMgDamage = true,
                    MissileSpellName = "VeigarBalefulStrikeMis",
                    CollisionObjects = new[] { CollisionType.YasuoWall },
                });

            Spells.Add(
                new SpellsData
                {
                    ChampionName = "Veigar",
                    SpellName = "VeigarDarkMatter",
                    MenuName = "Veigar W",
                    Slot = SpellSlot.W,
                    Type = SpellType.Circular,
                    Delay = 1350,
                    Range = 900,
                    Radius = 225,
                    MissileSpeed = int.MaxValue,
                    FixedRange = false,
                    AddHitbox = true,
                    DangerValue = 2,
                    IsDangerous = false,
                    CcOrMgDamage = true,
                    MissileSpellName = "",
                });

            Spells.Add(
                new SpellsData
                {
                    ChampionName = "Veigar",
                    SpellName = "VeigarEventHorizon",
                    Slot = SpellSlot.E,
                    Type = SpellType.Ring,
                    Delay = 500,
                    Range = 700,
                    Radius = 80,
                    MissileSpeed = int.MaxValue,
                    FixedRange = false,
                    AddHitbox = false,
                    DangerValue = 3,
                    IsDangerous = true,
                    CcOrMgDamage = true,
                    DontAddExtraDuration = true,
                    RingRadius = 350,
                    ExtraDuration = 3300,
                    DontCross = true,
                    MissileSpellName = "",
                });

            #endregion Veigar

            #region Velkoz

            Spells.Add(
                new SpellsData
                {
                    ChampionName = "Velkoz",
                    SpellName = "VelkozQ",
                    MenuName = "Velkoz Q",
                    Slot = SpellSlot.Q,
                    Type = SpellType.MissileLine,
                    Delay = 250,
                    Range = 1100,
                    Radius = 50,
                    MissileSpeed = 1300,
                    FixedRange = true,
                    AddHitbox = true,
                    DangerValue = 2,
                    IsDangerous = false,
                    CcOrMgDamage = true,
                    MissileSpellName = "VelkozQMissile",
                    CanBeRemoved = false,
                    CollisionObjects = new[] { CollisionType.AiHeroClient, CollisionType.ObjAiMinion, CollisionType.YasuoWall },
                });

            Spells.Add(
                new SpellsData
                {
                    ChampionName = "Velkoz",
                    SpellName = "VelkozQSplit",
                    MenuName = "Velkoz Q Split",
                    Slot = SpellSlot.Q,
                    Type = SpellType.MissileLine,
                    Delay = 250,
                    Range = 1100,
                    Radius = 55,
                    MissileSpeed = 2100,
                    FixedRange = true,
                    AddHitbox = true,
                    DangerValue = 2,
                    IsDangerous = false,
                    CcOrMgDamage = true,
                    MissileSpellName = "VelkozQMissileSplit",
                    CanBeRemoved = false,
                    CollisionObjects = new[] { CollisionType.AiHeroClient, CollisionType.ObjAiMinion, CollisionType.YasuoWall },
                });

            Spells.Add(
                new SpellsData
                {
                    ChampionName = "Velkoz",
                    SpellName = "VelkozW",
                    MenuName = "Velkoz W",
                    Slot = SpellSlot.W,
                    Type = SpellType.MissileLine,
                    Delay = 250,
                    Range = 1200,
                    Radius = 88,
                    MissileSpeed = 1700,
                    FixedRange = true,
                    AddHitbox = true,
                    DangerValue = 2,
                    IsDangerous = false,
                    CcOrMgDamage = true,
                    MissileSpellName = "VelkozWMissile",
                    CollisionObjects = new[] { CollisionType.YasuoWall },

                });

            Spells.Add(
                new SpellsData
                {
                    ChampionName = "Velkoz",
                    SpellName = "VelkozE",
                    MenuName = "Velkoz E",
                    Slot = SpellSlot.E,
                    Type = SpellType.Circular,
                    Delay = 500,
                    Range = 800,
                    Radius = 225,
                    MissileSpeed = 1500,
                    FixedRange = false,
                    AddHitbox = false,
                    DangerValue = 2,
                    IsDangerous = false,
                    CcOrMgDamage = true,
                    MissileSpellName = "VelkozEMissile",
                });
            #endregion Velkoz

            #region Vi

            Spells.Add(
                new SpellsData
                {
                    ChampionName = "Vi",
                    SpellName = "ViQMissile",
                    MenuName = "Vi Q",
                    Slot = SpellSlot.Q,
                    Type = SpellType.MissileLine,
                    Delay = 250,
                    Range = 1000,
                    Radius = 90,
                    MissileSpeed = 1500,
                    FixedRange = true,
                    AddHitbox = true,
                    DangerValue = 3,
                    IsDangerous = true,
                    CcOrMgDamage = true,
                    MissileSpellName = "ViQMissile",
                    CollisionObjects = new[] { CollisionType.YasuoWall },
                });
            #endregion Vi

            //Add Viktor R
            #region Viktor
            Spells.Add(
                new SpellsData
                {
                    ChampionName = "Viktor",
                    SpellName = "ViktorGravitonField",
                    MenuName = "Viktor W",
                    Slot = SpellSlot.W,
                    Type = SpellType.Circular,
                    Delay = 1500,
                    Range = 300,
                    Radius = 625,
                    MissileSpeed = int.MaxValue,
                    FixedRange = false,
                    AddHitbox = true,
                    DangerValue = 2,
                    IsDangerous = true,
                    CcOrMgDamage = true,
                    DontCross = true,
                });

            Spells.Add(
                new SpellsData
                {
                    ChampionName = "Viktor",
                    SpellName = "ViktorDeathRay3",
                    Slot = SpellSlot.E,
                    Type = SpellType.MissileLine,
                    Delay = 250,
                    Range = 1500,
                    Radius = 80,
                    MissileSpeed = 1050,
                    FixedRange = false,
                    AddHitbox = true,
                    DangerValue = 2,
                    IsDangerous = false,
                    CcOrMgDamage = true,
                    MissileSpellName = "ViktorDeathRayMissile",
                    ExtraMissileNames = new[] { "viktoreaugmissile" },
                    CollisionObjects = new[] { CollisionType.YasuoWall },
                });
            #endregion Viktor

            #region Vladimir

            Spells.Add(
                new SpellsData
                {
                    ChampionName = "Vladimir",
                    SpellName = "VladimirR",
                    MenuName = "Vladimir R",
                    Slot = SpellSlot.R,
                    Type = SpellType.Circular,
                    Delay = 250,
                    Range = 700,
                    Radius = 375,
                    MissileSpeed = int.MaxValue,
                    FixedRange = false,
                    AddHitbox = true,
                    DangerValue = 4,
                    IsDangerous = true,
                    CcOrMgDamage = true,
                    MissileSpellName = "VladimirR",
                    DontCross = true,
                });
            #endregion Vladimir

            #region Xerath

            Spells.Add(
                new SpellsData
                {
                    ChampionName = "Xerath",
                    SpellName = "xeratharcanopulse2",
                    MenuName = "Xerath Q",
                    Slot = SpellSlot.Q,
                    Type = SpellType.Line,
                    Delay = 600,
                    Range = 1600,
                    Radius = 95,
                    MissileSpeed = int.MaxValue,
                    FixedRange = true,
                    AddHitbox = true,
                    DangerValue = 2,
                    IsDangerous = false,
                    CcOrMgDamage = true,
                    MissileSpellName = "xeratharcanopulse2",
                });

            Spells.Add(
                new SpellsData
                {
                    ChampionName = "Xerath",
                    SpellName = "XerathArcaneBarrage2",
                    MenuName = "Xerath W",
                    Slot = SpellSlot.W,
                    Type = SpellType.Circular,
                    Delay = 700,
                    Range = 1000,
                    Radius = 200,
                    MissileSpeed = int.MaxValue,
                    FixedRange = false,
                    AddHitbox = true,
                    DangerValue = 2,
                    IsDangerous = false,
                    CcOrMgDamage = true,
                    MissileSpellName = "XerathArcaneBarrage2",
                });

            Spells.Add(
                new SpellsData
                {
                    ChampionName = "Xerath",
                    SpellName = "XerathMageSpear",
                    MenuName = "Xerath E",
                    Slot = SpellSlot.E,
                    Type = SpellType.MissileLine,
                    Delay = 200,
                    Range = 1150,
                    Radius = 60,
                    MissileSpeed = 1400,
                    FixedRange = true,
                    AddHitbox = true,
                    DangerValue = 3,
                    IsDangerous = true,
                    CcOrMgDamage = true,
                    MissileSpellName = "XerathMageSpearMissile",
                    CanBeRemoved = false,
                    CollisionObjects = new[] { CollisionType.AiHeroClient, CollisionType.ObjAiMinion, CollisionType.YasuoWall },
                });

            Spells.Add(
                new SpellsData
                {
                    ChampionName = "Xerath",
                    SpellName = "xerathrmissilewrapper",
                    MenuName = "Xerath R",
                    Slot = SpellSlot.R,
                    Type = SpellType.Circular,
                    Delay = 700,
                    Range = 5600,
                    Radius = 130,
                    MissileSpeed = int.MaxValue,
                    FixedRange = false,
                    AddHitbox = true,
                    DangerValue = 3,
                    IsDangerous = true,
                    CcOrMgDamage = true,
                    MissileSpellName = "xerathrmissilewrapper",
                });

            #endregion Xerath

            #region Yasuo

            Spells.Add(
                new SpellsData
                {
                    ChampionName = "Yasuo",
                    SpellName = "yasuoq",
                    MenuName = "Yasuo Q1 & Q2",
                    Slot = SpellSlot.Q,
                    Type = SpellType.Line,
                    Delay = 400,
                    Range = 550,
                    Radius = 90,
                    MissileSpeed = int.MaxValue,
                    FixedRange = true,
                    AddHitbox = true,
                    DangerValue = 1,
                    IsDangerous = false,
                    CcOrMgDamage = false,
                    MissileSpellName = "yasuoq",
                    ExtraSpellNames = new[] { "yasuoq2" },
                    ExtraMissileNames = new[] { "yasuoq2" },
                    Invert = true,
                });

            Spells.Add(
                new SpellsData
                {
                    ChampionName = "Yasuo",
                    SpellName = "yasuoq3w",
                    MenuName = "Yasuo Q3",
                    Slot = SpellSlot.Q,
                    Type = SpellType.MissileLine,
                    Delay = 500,
                    Range = 1150,
                    Radius = 90,
                    MissileSpeed = 1500,
                    FixedRange = true,
                    AddHitbox = true,
                    DangerValue = 3,
                    IsDangerous = true,
                    CcOrMgDamage = true,
                    MissileSpellName = "yasuoq3w",
                    CollisionObjects = new[] { CollisionType.YasuoWall }
                });            
            #endregion Yasuo

            #region Zac

            Spells.Add(
                new SpellsData
                {
                    ChampionName = "Zac",
                    SpellName = "ZacQ",
                    MenuName = "Zac Q",
                    Slot = SpellSlot.Q,
                    Type = SpellType.Line,
                    Delay = 500,
                    Range = 550,
                    Radius = 120,
                    MissileSpeed = int.MaxValue,
                    FixedRange = true,
                    AddHitbox = true,
                    DangerValue = 1,
                    IsDangerous = false,
                    CcOrMgDamage = true,
                    MissileSpellName = "ZacQ",
                });

            #endregion Zac

            #region Zed

            Spells.Add(
                new SpellsData
                {
                    ChampionName = "Zed",
                    SpellName = "ZedQ",
                    MenuName = "Zed Q",
                    Slot = SpellSlot.Q,
                    Type = SpellType.MissileLine,
                    Delay = 250,
                    Range = 925,
                    Radius = 50,
                    MissileSpeed = 1700,
                    FixedRange = true,
                    AddHitbox = true,
                    DangerValue = 3,
                    IsDangerous = false,
                    CcOrMgDamage = true,
                    MissileSpellName = "ZedQMissile",
                    FromObjects = new[] { "Zed_Base_W_tar.troy", "Zed_Base_W_cloneswap_buf.troy" },
                    CollisionObjects = new[] { CollisionType.YasuoWall },
                });

            Spells.Add(
                new SpellsData
                {
                    ChampionName = "Zed",
                    SpellName = "ZedE",
                    MenuName = "Zed E",
                    Slot = SpellSlot.Q,
                    Type = SpellType.MissileLine,
                    Delay = 0,
                    Range = 0,
                    Radius = 290,
                    MissileSpeed = int.MaxValue,
                    FixedRange = true,
                    AddHitbox = true,
                    DangerValue = 1,
                    IsDangerous = false,
                    CcOrMgDamage = false,
                    DefaultDisable = true,
                    MissileSpellName = "",
                    FromObjects = new[] { "Zed_Base_W_tar.troy", "Zed_Base_W_cloneswap_buf.troy" },
                    CollisionObjects = new[] { CollisionType.YasuoWall },
                });
            /*Spells.Add(
            new SpellsData
            {
                CharName = "Zed",
                Dangerlevel = SpellDangerLevel.Low,
                Name = "ZedE",
                Radius = 290,
                Range = 290,
                SpellKey = SpellSlot.E,
                SpellName = "ZedE",
                SpellType = SpellType.Circular,
                IsSpecial = true,
                DefaultOff = true,
            });*/

            #endregion Zed

            #region Ziggs

            Spells.Add(
                new SpellsData
                {
                    ChampionName = "Ziggs",
                    SpellName = "ZiggsQ",
                    MenuName = "Ziggs Q",
                    Slot = SpellSlot.Q,
                    Type = SpellType.Circular,
                    Delay = 250,
                    Range = 850,
                    Radius = 140,
                    MissileSpeed = 1700,
                    FixedRange = false,
                    AddHitbox = true,
                    DangerValue = 2,
                    IsDangerous = false,
                    CcOrMgDamage = true,
                    MissileSpellName = "ZiggsQSpell",     
                    CollisionObjects = new[] { CollisionType.YasuoWall },
                    CanBeRemoved = false,
                });

            Spells.Add(
                new SpellsData
                {
                    ChampionName = "Ziggs",
                    SpellName = "ZiggsQBounce1",
                    MenuName = "Ziggs Q - Bounce 1st",
                    Slot = SpellSlot.Q,
                    Type = SpellType.Circular,
                    Delay = 250,
                    Range = 850,
                    Radius = 140,
                    MissileSpeed = 1700,
                    FixedRange = false,
                    AddHitbox = true,
                    DangerValue = 2,
                    IsDangerous = false,
                    CcOrMgDamage = true,
                    MissileSpellName = "ZiggsQSpell2",
                    ExtraMissileNames = new[] { "ZiggsQSpell2" },
                    CollisionObjects = new[] { CollisionType.YasuoWall },
                    CanBeRemoved = false,
                });

            Spells.Add(
                new SpellsData
                {
                    ChampionName = "Ziggs",
                    SpellName = "ZiggsQBounce2",
                    MenuName = "Ziggs Q - Bounce 2rd",
                    Slot = SpellSlot.Q,
                    Type = SpellType.Circular,
                    Delay = 250,
                    Range = 850,
                    Radius = 160,
                    MissileSpeed = 1700,
                    FixedRange = false,
                    AddHitbox = true,
                    DangerValue = 2,
                    IsDangerous = false,
                    CcOrMgDamage = true,
                    MissileSpellName = "ZiggsQSpell3",
                    ExtraMissileNames = new[] { "ZiggsQSpell3" },
                    CollisionObjects = new[] { CollisionType.YasuoWall },
                    CanBeRemoved = false,
                });

            Spells.Add(
                new SpellsData
                {
                    ChampionName = "Ziggs",
                    SpellName = "ZiggsW",
                    MenuName = "Ziggs W",
                    Slot = SpellSlot.W,
                    Type = SpellType.Circular,
                    Delay = 250,
                    Range = 1000,
                    Radius = 275,
                    MissileSpeed = 1750,
                    FixedRange = false,
                    AddHitbox = true,
                    DangerValue = 3,
                    IsDangerous = false,
                    CcOrMgDamage = true,
                    MissileSpellName = "ZiggsW",
                    CollisionObjects = new[] { CollisionType.YasuoWall },
                });

            Spells.Add(
                new SpellsData
                {
                    ChampionName = "Ziggs",
                    SpellName = "ZiggsE",
                    MenuName = "Ziggs E",
                    Slot = SpellSlot.E,
                    Type = SpellType.Circular,
                    Delay = 500,
                    Range = 900,
                    Radius = 235,
                    MissileSpeed = 1750,
                    FixedRange = false,
                    AddHitbox = true,
                    DangerValue = 2,
                    IsDangerous = false,
                    CcOrMgDamage = true,
                    MissileSpellName = "ZiggsE",
                    DontCross = true,
                });

            Spells.Add(
                new SpellsData
                {
                    ChampionName = "Ziggs",
                    SpellName = "ZiggsR",
                    MenuName = "Ziggs R",
                    Slot = SpellSlot.R,
                    Type = SpellType.Circular,
                    Delay = 0,
                    Range = 5300,
                    Radius = 500,
                    MissileSpeed = 1550,
                    FixedRange = false,
                    AddHitbox = true,
                    DangerValue = 4,
                    IsDangerous = true,
                    CcOrMgDamage = true,
                    MissileSpellName = "ZiggsR",
                });
            #endregion Ziggs

            #region Zilean

            Spells.Add(
                new SpellsData
                {
                    ChampionName = "Zilean",
                    SpellName = "ZileanQ",
                    Slot = SpellSlot.Q,
                    Type = SpellType.Circular,
                    Delay = 300,
                    ExtraDuration = 400,
                    Range = 900,
                    Radius = 150,
                    MissileSpeed = int.MaxValue,
                    FixedRange = false,
                    AddHitbox = true,
                    DangerValue = 3,
                    IsDangerous = true,
                    CcOrMgDamage = true,
                    MissileSpellName = "ZileanQMissile",
                    DontCross = true,
                    CollisionObjects = new[] { CollisionType.YasuoWall }
                });

            #endregion Zilean

            #region Zyra

            Spells.Add(
                new SpellsData
                {
                    ChampionName = "Zyra",
                    SpellName = "ZyraQ",
                    MenuName = "Zyra Q",
                    Slot = SpellSlot.Q,
                    Type = SpellType.Line,
                    Delay = 850,
                    Range = 800,
                    Radius = 140,
                    MissileSpeed = int.MaxValue,
                    FixedRange = false,
                    AddHitbox = true,
                    DangerValue = 2,
                    IsDangerous = false,
                    CcOrMgDamage = true,
                    MissileSpellName = "ZyraQ",
                });
            Spells.Add(
                new SpellsData
                {
                    ChampionName = "Zyra",
                    MenuName = "Zyra E",
                    SpellName = "ZyraE",
                    Slot = SpellSlot.E,
                    Type = SpellType.MissileLine,
                    Delay = 250,
                    Range = 1150,
                    Radius = 70,
                    MissileSpeed = 1400,
                    FixedRange = true,
                    AddHitbox = true,
                    DangerValue = 3,
                    IsDangerous = true,
                    MissileSpellName = "ZyraEMissile",
                    CollisionObjects = new[] { CollisionType.YasuoWall },
                });

            Spells.Add(
            new SpellsData
            {
                ChampionName = "Zyra",
                SpellName = "ZyraBrambleZone",
                MenuName = "Zyra R",
                Slot = SpellSlot.R,
                Type = SpellType.Circular,
                Delay = 2250,
                Range = 1150,
                Radius = 70,
                MissileSpeed = 1400,
                FixedRange = true,
                AddHitbox = true,
                DangerValue = 5,
                IsDangerous = true,
                CcOrMgDamage = true,
                MissileSpellName = "",
            });
            #endregion Zyra
        }
    }
}
