using heroes_Vs_Monster.Item;
using heroes_Vs_Monster.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace heroes_Vs_Monster.Entity {
    public class Orc:Monster {
        
        public Orc(int lvlhero) : base(lvlhero) {
            base.statsGeneration();
            stats[StatType.force] += 4;
            Inventaire.Loots[LootType.or] = Dice.RandomDices(1 ,4 ,1);
            Name = "orc";
            }
        protected override void SetupLvl(int LvlHero) {
            Lvl = new Random().Next(LvlHero - 3 ,LvlHero + 1);
            for ( int i = 0; i < Lvl; i++ ) {
                int nbr = new Random().Next(0 ,Enum.GetValues(typeof(StatType)).Length);
               stats[(StatType) nbr] += 2;

                }
            }
        }
    }
