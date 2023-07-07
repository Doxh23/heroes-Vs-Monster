using System;
using heroes_Vs_Monster.utils;
/// <summary>
/// Summary description for Class1
/// </summary>
/// 

namespace heroes_Vs_Monster.Entity {
    public class Voleur:Heroes {

        public Voleur(string name ,string icon) : base(icon) {
            Name = name;
            }

        protected override void statsGeneration() {
            base.statsGeneration();
            stats[StatType.hp] += +99;
            }
        public override void Attaque(Character monster ,int nbr) {
            int nbrDice = Dice.RandomDices(nbr*2 ,Dice.DiceType.d4 ,nbr*2);
            int nbrDamage = (nbrDice + stats.Bonus(StatType.force));
            nbrDamage = nbrDamage < 0 ? 0 : nbrDamage;
            monster.DamageTaken(nbrDamage);
            base.Attaque(monster , nbrDamage);
            }
        }

    
    }

