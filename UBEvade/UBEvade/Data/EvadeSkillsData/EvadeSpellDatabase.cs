using System.Collections.Generic;
using System.Linq;
using EloBuddy;
using EloBuddy.SDK;

namespace UBEvade.Data.EvadeSkillsData
{
    internal class EvadeSpellDatabase
    {
        public static List<EvadeSpellData> Spells = new List<EvadeSpellData>();

        static EvadeSpellDatabase()
        {
            #region Var
            EvadeSpellData spell;
            #endregion

            #region Champion SpellWall

            #region Braum
            if (Player.Instance.ChampionName == "Braum")
            {
                spell = new Wall("Braum", SpellSlot.E, 0, 1)
                {
                    MaxRange = 250,
                };
                Spells.Add(spell);
            }
            #endregion

            #region Yasuo
            if (Player.Instance.ChampionName == "Yasuo")
            {
                spell = new Wall("Yasuo W", SpellSlot.W, 0, 3);
                Spells.Add(spell);
            }
            #endregion

            #endregion

            #region Champion SpellShields

            #region Fiora
            if (Player.Instance.ChampionName == "Fiora")
            {
                spell = new Shield("Fiora W", SpellSlot.W, 0, 3)
                {
                    Type = EvadeType.ShieldSkillShot,
                    MaxRange = 750,
                    CastWidth = 90,
                    DelayRiposte = 750,
                };
                Spells.Add(spell);
            }
            #endregion

            #region Nocturne

            if (Player.Instance.ChampionName == "Nocturne")
            {
                spell = new Shield("Nocturne W", SpellSlot.W, 0, 2, true);
                Spells.Add(spell);
            }

            #endregion

            #region Sivir

            if (Player.Instance.ChampionName == "Sivir")
            {
                spell = new Shield("Sivir E", SpellSlot.E, 0, 2, true);
                Spells.Add(spell);
            }

            #endregion

            #endregion

            #region Champion Dashes

            #region Aatrox

            if (Player.Instance.ChampionName == "Aatrox")
            {
                spell = new Dash("Aatrox Q", SpellSlot.Q, 650, false, 400, 3000, 3);
                Spells.Add(spell);
            }

            #endregion

            #region Ahri
            spell = new Dash("Ahri R", SpellSlot.R, 500, true, 0, 1575, 3)
            {
                RequiresPreMove = true,
            };
            Spells.Add(spell);
            #endregion

            #region Akali

            if (Player.Instance.ChampionName == "Akali")
            {
                spell = new Dash("Akali R", SpellSlot.R, 800, false, 0, 2461, 3)
                {
                    ValidTargets = new[] { SpellTargets.EnemyChampions, SpellTargets.EnemyMinions }
                };
                Spells.Add(spell);
            }

            #endregion

            #region Alistar

            if (Player.Instance.ChampionName == "Alistar")
            {
                spell = new Dash("Alistar W", SpellSlot.W, 650, false, 0, 1900, 3)
                {
                    ValidTargets = new[] { SpellTargets.EnemyChampions, SpellTargets.EnemyMinions },
                };
                Spells.Add(spell);
            }

            #endregion

            //Add Azir
            #region Azir

            #endregion

            //Add braum
            #region Braum
            spell = new Dash("Braum W", SpellSlot.W, 650, false, 0, 500, 4)
            {
                ValidTargets = new[] { SpellTargets.AllyChampions, SpellTargets.AllyMinions },
            };
            Spells.Add(spell);
            #endregion

            #region Caitlyn

            if (Player.Instance.ChampionName == "Caitlyn")
            {
                spell = new Dash("Caitlyn E", SpellSlot.E, 390, true, 250, 1000, 3)
                {
                    Invert = true,
                };
                Spells.Add(spell);
            }

            #endregion

            #region Corki

            if (Player.Instance.ChampionName == "Corki")
            {
                spell = new Dash("Corki W", SpellSlot.W, 600, false, 250, 650, 3);
                Spells.Add(spell);
            }

            #endregion

            //Add Kotek
            #region Diana
            #endregion

            //Add Timer Boy
            #region Ekko
            spell = new Dash("Ekko E", SpellSlot.E, 350, true, 0, 1150, 3);
            Spells.Add(spell);
            #endregion

            //Add Fiora
            #region Fiora

            #endregion

            #region Fizz

            if (Player.Instance.ChampionName == "Fizz")
            {
                spell = new Dash("Fizz Q", SpellSlot.Q, 550, true, 100, 1400, 2)
                {
                    ValidTargets = new[] { SpellTargets.EnemyMinions, SpellTargets.EnemyChampions },
                };
                Spells.Add(spell);
            }

            #endregion

            #region Gragas

            if (Player.Instance.ChampionName == "Gragas")
            {
                spell = new Dash("Gragas E", SpellSlot.E, 600, true, 250, 911, 3);
                Spells.Add(spell);
            }

            #endregion

            #region Gnar

            if (Player.Instance.ChampionName == "Gnar")
            {
                spell = new Dash("Gnar E", SpellSlot.E, 475, false, 0, 900, 3)
                {
                    OtherName = "GnarE",
                };
                Spells.Add(spell);
            }

            #endregion

            #region Graves

            if (Player.Instance.ChampionName == "Graves")
            {
                spell = new Dash("Graves E", SpellSlot.E, 425, true, 0, 1223, 2);
                Spells.Add(spell);
            }

            #endregion

            #region Irelia

            if (Player.Instance.ChampionName == "Irelia")
            {
                spell = new Dash("Irelia Q", SpellSlot.Q, 650, false, 250, 2200, 3)
                {
                    ValidTargets = new[] { SpellTargets.EnemyChampions, SpellTargets.EnemyMinions },
                };
                Spells.Add(spell);
            }

            #endregion

            //Add Jarvan IV
            #region Jarvan IV
            #endregion

            #region Jax

            if (Player.Instance.ChampionName == "Jax")
            {
                spell = new Dash("Jax Q", SpellSlot.Q, 700, false, 100, 1400, 2)
                {
                    ValidTargets = new[]
                    {
                        SpellTargets.AllyChampions, SpellTargets.AllyWards, SpellTargets.AllyMinions,
                        SpellTargets.EnemyWards, SpellTargets.EnemyChampions, SpellTargets.EnemyMinions
                    },
                };
                Spells.Add(spell);
            }

            #endregion

            //Add Khazik
            #region Khazik
            #endregion

            //Add Kindred
            #region Kindred
            #endregion

            #region Leblanc

            if (Player.Instance.ChampionName == "Leblanc")
            {
                spell = new Dash("LeBlanc W", SpellSlot.W, 600, false, 100, 1621, 3)
                {
                    OtherName = "LeblancSlide",
                };
                Spells.Add(spell);
            }

            if (Player.Instance.ChampionName == "Leblanc")
            {
                spell = new Dash("LeBlanc W fake", SpellSlot.R, 600, false, 100, 1621, 3)
                {
                    OtherName = "LeblancSlideM",
                };
                Spells.Add(spell);
            }

            #endregion

            #region LeeSin

            if (Player.Instance.ChampionName == "LeeSin")
            {
                spell = new Dash("LeeSin Q", SpellSlot.Q, 1150, false, 150, 2000, 4)
                {
                    ValidTargets = new[] { SpellTargets.EnemyChampions, SpellTargets.EnemyMinions },
                    OtherName = "",
                };
                Spells.Add(spell);

                spell = new Dash("LeeSin W", SpellSlot.W, 700, false, 250, 2000, 3)
                {
                    ValidTargets = new[] { SpellTargets.AllyChampions, SpellTargets.AllyMinions, SpellTargets.AllyWards },
                    OtherName = "BlindMonkWOne",
                };
                Spells.Add(spell);
            }

            #endregion

            #region Lucian

            if (Player.Instance.ChampionName == "Lucian")
            {
                spell = new Dash("Lucian E", SpellSlot.E, 425, false, 100, 1350, 2);
                Spells.Add(spell);
            }

            #endregion

            #region Nidalee

            if (Player.Instance.ChampionName == "Nidalee")
            {
                spell = new Dash("Nidalee W", SpellSlot.W, 375, true, 250, 943, 3)
                {
                    OtherName = "Pounce",
                };
                Spells.Add(spell);
            }

            #endregion

            #region Pantheon

            if (Player.Instance.ChampionName == "Pantheon")
            {
                spell = new Dash("Pantheon W", SpellSlot.W, 600, false, 100, 1000, 3)
                {
                    ValidTargets = new[] { SpellTargets.EnemyChampions, SpellTargets.EnemyMinions },
                };
                Spells.Add(spell);
            }

            #endregion

            #region Riven

            if (Player.Instance.ChampionName == "Riven")
            {
                spell = new Dash("Riven Q", SpellSlot.Q, 260, true, 250, 560, 3)
                {
                    RequiresPreMove = true,
                };
                Spells.Add(spell);

                spell = new Dash("Riven E", SpellSlot.E, 325, false, 250, 1200, 3);
                Spells.Add(spell);
            }

            #endregion

            #region Tristana

            if (Player.Instance.ChampionName == "Tristana")
            {
                spell = new Dash("Tristana W", SpellSlot.W, 900, true, 350, 800, 5);
                Spells.Add(spell);
            }

            #endregion

            #region Tryndamare

            if (Player.Instance.ChampionName == "Tryndamere")
            {
                spell = new Dash("Tryndamere E", SpellSlot.E, 650, true, 250, 900, 3);
                Spells.Add(spell);
            }

            #endregion

            #region Vayne

            if (Player.Instance.ChampionName == "Vayne")
            {
                spell = new Dash("Vayne Q", SpellSlot.Q, 300, true, 0, 910, 2);
                Spells.Add(spell);
            }

            #endregion

            #region MonkeyKing

            if (Player.Instance.ChampionName == "MonkeyKing")
            {
                spell = new Dash("Wukong E", SpellSlot.E, 650, false, 250, 1400, 3)
                {
                    ValidTargets = new[] { SpellTargets.EnemyChampions, SpellTargets.EnemyMinions },
                };
                Spells.Add(spell);
            }

            #endregion

            #region Yasuo

            if (Player.Instance.ChampionName == "Yasuo")
            {
                spell = new Dash("Yasuo E", SpellSlot.E, 475, true, 50, 2000, 2)
                {
                    ValidTargets = new[] { SpellTargets.EnemyChampions, SpellTargets.EnemyMinions },
                };
                Spells.Add(spell);
            }

            #endregion



            #endregion

            #region Champion Blinks

            //Add timer boy
            #region Ekko
            // E aa & R blinks
            #endregion

            #region Ezreal

            if (Player.Instance.ChampionName == "Ezreal")
            {
                spell = new Blink("Ezreal E", SpellSlot.E, 450, 350, 3);
                Spells.Add(spell);
            }

            #endregion

            #region Kassadin

            if (Player.Instance.ChampionName == "Kassadin")
            {
                spell = new Blink("Kassadin R", SpellSlot.R, 700, 250, 3);
                Spells.Add(spell);
            }

            #endregion

            #region Katarina

            if (Player.Instance.ChampionName == "Katarina")
            {
                spell = new Blink("Katarina E", SpellSlot.E, 700, 250, 3)
                {
                    ValidTargets = new[]              
                    {                   
                        SpellTargets.AllyChampions, SpellTargets.AllyMinions, SpellTargets.AllyWards,                   
                        SpellTargets.EnemyChampions, SpellTargets.EnemyMinions, SpellTargets.EnemyWards
                    },
                };
                Spells.Add(spell);
            }

            #endregion

            #region Shaco

            if (Player.Instance.ChampionName == "Shaco")
            {
                spell = new Blink("Shaco Q", SpellSlot.Q, 400, 350, 3);
                Spells.Add(spell);
            }

            #endregion

            #region Talon

            if (Player.Instance.ChampionName == "Talon")
            {
                spell = new Blink("Talon E", SpellSlot.E, 700, 250, 3)
                {
                    ValidTargets = new[] { SpellTargets.EnemyChampions, SpellTargets.EnemyMinions },
                };
                Spells.Add(spell);
            }

            #endregion

            #endregion

            #region Champion UnSelectable

            #region Elise

            if (Player.Instance.ChampionName == "Elise")
            {
                spell = new UnSelectable("Elise E", SpellSlot.E, 0, 250, 3)
                {
                    OtherName = "EliseSpiderEInitial",
                    Active = true,
                };
                Spells.Add(spell);
            }

            #endregion

            #region Fizz

            if (Player.Instance.ChampionName == "Fizz")
            {
                spell = new UnSelectable("Fizz E", SpellSlot.E, 330, 250, 3)
                {
                    OtherName = "",
                };
                Spells.Add(spell);
            }

            #endregion

            //add Ice queen
            #region Lissandra
            if (Player.Instance.ChampionName == "Lissandra")
            {
                spell = new UnSelectable("Lissandra R", SpellSlot.R, 330, 250, 5)
                {
                    ValidTargets = new[] { SpellTargets.MySelf }
                };
                Spells.Add(spell);
            }
            #endregion

            #region MasterYi

            if (Player.Instance.ChampionName == "MasterYi")
            {
                spell = new UnSelectable("MasterYi Q", SpellSlot.Q, 600, 250, 3)
                {
                    ValidTargets = new[] { SpellTargets.EnemyChampions, SpellTargets.EnemyMinions },
                };
                Spells.Add(spell);
            }

            #endregion

            #region Vladimir

            if (Player.Instance.ChampionName == "Vladimir")
            {
                spell = new UnSelectable("Vladimir W", SpellSlot.W, 0, 250, 3)
                {
                    Active = true,
                };
                Spells.Add(spell);
            }

            #endregion

            #endregion

            #region Champion MoveSpeed buffs

            #region Blitzcrank

            if (Player.Instance.ChampionName == "Blitzcrank")
            {
                spell = new MovementBuff(
                    "Blitzcrank W", SpellSlot.W, 100, 3,
                    () =>
                        Player.Instance.MoveSpeed *
                        (1 + 0.12f + 0.04f * Player.Instance.Spellbook.GetSpell(SpellSlot.W).Level));
                Spells.Add(spell);
            }

            #endregion

            #region Draven

            if (Player.Instance.ChampionName == "Draven")
            {
                spell = new MovementBuff(
                    "Draven W", SpellSlot.W, 100, 3,
                    () =>
                        Player.Instance.MoveSpeed *
                        (1 + 0.35f + 0.05f * Player.Instance.Spellbook.GetSpell(SpellSlot.W).Level));
                Spells.Add(spell);
            }

            #endregion

            #region Evelynn

            if (Player.Instance.ChampionName == "Evelynn")
            {
                spell = new MovementBuff(
                    "Evelynn W", SpellSlot.W, 100, 3,
                    () =>
                        Player.Instance.MoveSpeed *
                        (1 + 0.2f + 0.1f * Player.Instance.Spellbook.GetSpell(SpellSlot.W).Level));
                Spells.Add(spell);
            }

            #endregion

            #region Garen

            if (Player.Instance.ChampionName == "Garen")
            {
                spell = new MovementBuff("Garen Q", SpellSlot.Q, 100, 3, () => Player.Instance.MoveSpeed * (1.35f));
                Spells.Add(spell);
            }

            #endregion

            #region Katarina

            if (Player.Instance.ChampionName == "Katarina")
            {
                spell = new MovementBuff(
                    "Katarina W", SpellSlot.W, 100, 3,
                    () =>
                        ObjectManager.Get<AIHeroClient>().Any(h => h.IsValidTarget(375))
                            ? Player.Instance.MoveSpeed *
                              (1 + 0.10f + 0.05f * Player.Instance.Spellbook.GetSpell(SpellSlot.W).Level)
                            : 0);
                Spells.Add(spell);
            }

            #endregion

            #region Karma

            if (Player.Instance.ChampionName == "Karma")
            {
                spell = new MovementBuff(
                    "Karma E", SpellSlot.E, 100, 3,
                    () =>
                        Player.Instance.MoveSpeed *
                        (1 + 0.35f + 0.05f * Player.Instance.Spellbook.GetSpell(SpellSlot.E).Level));
                Spells.Add(spell);
            }

            #endregion

            #region Kennen

            if (Player.Instance.ChampionName == "Kennen")
            {
                spell = new MovementBuff("Kennen E", SpellSlot.E, 100, 3, () => 200 + Player.Instance.MoveSpeed);
                //Actually it should be +335 but ingame you only gain +230, rito plz
                Spells.Add(spell);
            }

            #endregion

            #region Khazix

            if (Player.Instance.ChampionName == "Khazix")
            {
                spell = new MovementBuff("Khazix R", SpellSlot.R, 100, 5, () => Player.Instance.MoveSpeed * 1.4f);
                Spells.Add(spell);
            }

            #endregion

            #region Lulu

            if (Player.Instance.ChampionName == "Lulu")
            {
                spell = new MovementBuff(
                    "Lulu W", SpellSlot.W, 100, 5,
                    () => Player.Instance.MoveSpeed * (1.3f + Player.Instance.FlatMagicDamageMod / 100 * 0.1f));
                Spells.Add(spell);
            }

            #endregion

            #region Nunu

            if (Player.Instance.ChampionName == "Nunu")
            {
                spell = new MovementBuff(
                    "Nunu W", SpellSlot.W, 100, 3,
                    () =>
                        Player.Instance.MoveSpeed *
                        (1 + 0.1f + 0.01f * Player.Instance.Spellbook.GetSpell(SpellSlot.W).Level));
                Spells.Add(spell);
            }

            #endregion

            //Correct Ryze
            #region Ryze
            #endregion

            #region Sivir

            if (Player.Instance.ChampionName == "Sivir")
            {
                spell = new MovementBuff("Sivir R", SpellSlot.R, 100, 5, () => Player.Instance.MoveSpeed * (1.6f));
                Spells.Add(spell);
            }

            #endregion

            #region Shyvana

            if (Player.Instance.ChampionName == "Shyvana")
            {
                spell = new MovementBuff(
                    "Shyvana W", SpellSlot.W, 100, 4,
                    () =>
                        Player.Instance.MoveSpeed *
                        (1 + 0.25f + 0.05f * Player.Instance.Spellbook.GetSpell(SpellSlot.W).Level));
                spell.OtherName = "ShyvanaImmolationAura";
                Spells.Add(spell);
            }

            #endregion

            #region Sona

            if (Player.Instance.ChampionName == "Sona")
            {
                spell = new MovementBuff(
                    "Sona E", SpellSlot.E, 100, 3,
                    () =>
                        Player.Instance.MoveSpeed *
                        (1 + 0.12f + 0.01f * Player.Instance.Spellbook.GetSpell(SpellSlot.E).Level +
                         Player.Instance.FlatMagicDamageMod / 100 * 0.075f +
                         0.02f * Player.Instance.Spellbook.GetSpell(SpellSlot.R).Level));
                Spells.Add(spell);
            }

            #endregion

            #region Teemo

            if (Player.Instance.ChampionName == "Teemo")
            {
                spell = new MovementBuff(
                    "Teemo W", SpellSlot.W, 100, 3,
                    () =>
                        Player.Instance.MoveSpeed *
                        (1 + 0.06f + 0.04f * Player.Instance.Spellbook.GetSpell(SpellSlot.W).Level));
                Spells.Add(spell);
            }

            #endregion

            #region Udyr

            if (Player.Instance.ChampionName == "Udyr")
            {
                spell = new MovementBuff(
                    "Udyr E", SpellSlot.E, 100, 3,
                    () =>
                        Player.Instance.MoveSpeed *
                        (1 + 0.1f + 0.05f * Player.Instance.Spellbook.GetSpell(SpellSlot.E).Level));
                Spells.Add(spell);
            }

            #endregion

            #region Zilean

            if (Player.Instance.ChampionName == "Zilean")
            {
                spell = new MovementBuff("Zilean E", SpellSlot.E, 100, 3, () => Player.Instance.MoveSpeed * 1.55f);
                Spells.Add(spell);
            }

            #endregion

            #endregion

            #region Champion Shields / Amor or MagicS buff / Reduce Damage

            #region Annie
            if (Player.Instance.ChampionName == "Annie")
            {
                spell = new Shield("Annie E", SpellSlot.E, 0, 1);
                Spells.Add(spell);
            }
            #endregion

            #region Diana
            if (Player.Instance.ChampionName == "Diana")
            {
                spell = new Shield("Diana W", SpellSlot.W, 0, 1);
                Spells.Add(spell);
            }
            #endregion

            #region Janna
            #endregion

            #region Karma
            #endregion

            #region Kayle
            #endregion

            #region Lulu
            #endregion

            #region Lux
            #endregion

            #region Morgana
            #endregion

            #region Orianna
            #endregion

            #region Rumble
            #endregion

            #region Taric
            #endregion

            #region Ryze
            #endregion

            #region TahmKench
            #endregion

            #region Thresh
            #endregion

            #region Udyr
            #endregion

            #region Thresh
            #endregion

            #region Viktor
            #endregion

            #endregion
        }
    }
}
