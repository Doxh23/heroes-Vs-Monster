using heroes_Vs_Monster.Item;
using heroes_Vs_Monster.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace heroes_Vs_Monster.Entity {
    public class Dragonnet: Monster {
        
        public Dragonnet(int lvlhero,string ascii): base(lvlhero,ascii) {
            base.statsGeneration();
            stats[StatType.hp] += 15;
            Inventaire.Loots[LootType.or] = Dice.RandomDices(1 ,4 ,1);
            Inventaire.Loots[LootType.cuir] = Dice.RandomDices(1 ,4 ,1);
            Name = "dragonnet";

            }

        protected override void SetupLvl(int LvlHero) {
            Lvl = new Random().Next(LvlHero - 3 ,LvlHero + 1);
            for ( int i = 0; i < Lvl; i++ ) {
                int nbr = new Random().Next(0 ,Enum.GetValues(typeof(StatType)).Length);
                stats[(StatType) nbr] += 3;

                }
            }
        public override void Attaque(Character monster ,int nbr) {
            int nbrDice = Dice.RandomDices(nbr ,4 ,nbr);
            int nbrDamage = ( nbrDice + stats.Bonus(StatType.force) );
            nbrDamage = nbrDamage < 0 ? 0 : nbrDamage;
            monster.DamageTaken(nbrDamage);
            }
        }
        }
