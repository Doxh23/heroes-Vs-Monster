using heroes_Vs_Monster.Item;
using heroes_Vs_Monster.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace heroes_Vs_Monster.Entity {
    public class Loup : Monster{
        public int LootCuir {
            get; set;
            }
        public Loup(int lvlhero) : base(lvlhero) {
            base.statsGeneration();
            stats[StatType.vitesse] += 5;
            Inventaire.Loots[LootType.cuir] = Dice.RandomDices(1 ,4 ,1);
            Name = "loup";
            }
        protected override void SetupLvl(int LvlHero) {
            Lvl = new Random().Next(LvlHero - 3 ,LvlHero + 1);
            for ( int i = 0; i < Lvl; i++ ) {
                int nbr = new Random().Next(0 ,Enum.GetValues(typeof(StatType)).Length);
                stats[(StatType) nbr] += 1;

                }
            }

        }
    }
