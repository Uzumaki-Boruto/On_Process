using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EloBuddy;
using EloBuddy.SDK;

namespace UBEvade.SpellBlock
{
    public static class BlockList
    {
        public static Dictionary<SpellSlot, bool> SpellsBlock =
            new Dictionary<SpellSlot, bool>
                    {
                        { SpellSlot.Q, false },
                        { SpellSlot.W, false },
                        { SpellSlot.E, false },
                        { SpellSlot.R, false },
                    };

        static BlockList()
        {
            foreach (var spell in Data.EvadeSkillsData.EvadeSpellDatabase.Spells)
            {
                SpellsBlock[spell.Slot] = true;
            }
            switch (Player.Instance.Hero)
            {
                case Champion.Aatrox:                    
                    SpellsBlock.Remove(SpellSlot.W);
                    break;
                case Champion.Ahri:
                    break;
                case Champion.Akali:
                    SpellsBlock.Remove(SpellSlot.W);
                    break;
                case Champion.Alistar:
                    SpellsBlock.Remove(SpellSlot.E);
                    SpellsBlock.Remove(SpellSlot.R);
                    break;
                case Champion.Amumu:
                    SpellsBlock.Remove(SpellSlot.W);
                    break;
                case Champion.Anivia:
                    SpellsBlock.Remove(SpellSlot.R);
                    break;
                case Champion.Annie:
                    SpellsBlock.Remove(SpellSlot.E);
                    break;
                case Champion.Ashe:
                    SpellsBlock.Remove(SpellSlot.Q);
                    break;
                case Champion.AurelionSol:
                    SpellsBlock.Remove(SpellSlot.W);
                    break;
                case Champion.Azir:
                    SpellsBlock.Remove(SpellSlot.R);
                    break;
                case Champion.Braum:
                    SpellsBlock.Remove(SpellSlot.E);
                    break;
                case Champion.Chogath:
                    SpellsBlock.Remove(SpellSlot.E);
                    break;
                case Champion.Darius:
                    SpellsBlock.Remove(SpellSlot.R);
                    break;
                                      
            }
        }
    }
}
