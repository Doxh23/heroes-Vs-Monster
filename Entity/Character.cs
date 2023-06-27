using heroes_Vs_Monster.Item;
using heroes_Vs_Monster.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace heroes_Vs_Monster.Entity {

  
   public  class Character {
       
        public string Name;
        public Stats stats = new Stats();
        public Inventaire inventaire = new Inventaire();
        public Character() {
            statsGeneration();
            }


        protected virtual void statsGeneration() {
            stats[StatType.force] = Dice.RandomDices(4 ,4 ,3);
            stats[StatType.endurance] = Dice.RandomDices(4 ,4 ,3);

            stats[StatType.hp] = Dice.RandomDices(4 ,4 ,3) + Bonus(StatType.endurance);
            stats[StatType.vitesse] = Dice.RandomDices(4 ,4 ,3);
            }
        public virtual void Attaque(Character E,int nbr) {
            int nbrDice = Dice.RandomDices(nbr ,6 ,nbr);
            int nbrDamage = nbrDice + Bonus(StatType.force);
            nbrDamage = nbrDamage < 0 ? 0 : nbrDamage;
            E.stats[StatType.hp] -= nbrDamage;

            }
       


        protected int Bonus(StatType t) {
            int bonusHp;

            if ( stats[t] < 5 ) {
                bonusHp = -1;
                }
            else if ( stats[t] > 5 && stats[t] < 10 ) {
                bonusHp = 0;
                }
            else if ( stats[t] > 10 && stats[t] < 15 ) {
                bonusHp = 1;
                }
            else {
                bonusHp = 2;
                }
            return bonusHp;
            }

        public override string ToString() {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"name : {Name}");
            for ( int i = 0; i < Enum.GetValues<StatType>().Count(); i++ ) {
                sb.AppendLine($"{(StatType) i} : {stats[(StatType) i]}");
                }
            return sb.ToString();
            
            }
        
        
      
        

        }
   

    }
