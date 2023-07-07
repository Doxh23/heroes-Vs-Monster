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
        public Loup(int lvlhero,string ascii) : base(lvlhero,ascii) {
            base.statsGeneration();
            stats[StatType.vitesse] += 5;
            Materiaux[LootType.cuir] = Dice.RandomDices(1 ,Dice.DiceType.d4 ,1);
            Name = "loup";
            }
        protected override void SetupLvl(int LvlHero) {
            Lvl = new Random().Next(LvlHero - 3 ,LvlHero + 1);
            for ( int i = 0; i < Lvl; i++ ) {
                int nbr = new Random().Next(0 ,Enum.GetValues(typeof(StatType)).Length);
                stats[(StatType) nbr] += 1;

                }
            }
        public override void Attaque(Character monster ,int nbr) {
            int nbrDice = Dice.RandomDices(nbr ,Dice.DiceType.d4 ,nbr);
            int nbrDamage = ( nbrDice + stats.Bonus(StatType.force) )/monster.resistance*100;
            nbrDamage = nbrDamage < 0 ? 0 : nbrDamage;
            monster.DamageTaken(nbrDamage);
            }

        }
    }
