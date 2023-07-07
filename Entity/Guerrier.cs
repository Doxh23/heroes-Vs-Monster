using System;
using heroes_Vs_Monster.utils;
/// <summary>
/// Summary description for Class1
/// </summary>
/// 
namespace heroes_Vs_Monster.Entity {
    public class Guerrier:Heroes {
        

        public Guerrier(string name,string icon) : base(icon) {
        Name =name;
            }
        protected override void statsGeneration() {
            base.statsGeneration();
            stats[StatType.force] += 2;
            
            }
        public override void Attaque(Character monster ,int nbr) {
            int nbrDice = Dice.RandomDices(nbr+1 ,Dice.DiceType.d8 ,nbr);
            int nbrDamage = ( nbrDice + stats.Bonus(StatType.force) );
            nbrDamage = nbrDamage < 0 ? 0 : nbrDamage;
            monster.DamageTaken(nbrDamage);
            base.Attaque(monster ,nbrDamage);
            }

        }
    }

