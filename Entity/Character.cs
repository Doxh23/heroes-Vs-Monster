using heroes_Vs_Monster.Item;
using heroes_Vs_Monster.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace heroes_Vs_Monster.Entity {


    public class Character {

        private string name;
        private Stats stats = new();
        private Inventaire inventaire = new();

        public string Name {
            get => name;
            set => name = value;
            }
        public Stats Stats {
            get => stats;
            set => stats = value;
            }
        public Inventaire Inventaire {
            get => inventaire;
            set => inventaire =  value ;
            }

        public Character() {
            statsGeneration();
            }


        protected virtual void statsGeneration() {
            Stats[StatType.force] = Dice.RandomDices(4 ,4 ,3);
            Stats[StatType.endurance] = Dice.RandomDices(4 ,4 ,3);

            Stats[StatType.hp] = Dice.RandomDices(4 ,4 ,3) + Bonus(StatType.endurance);
            Stats[StatType.vitesse] = Dice.RandomDices(4 ,4 ,3);
            }
        public virtual void Attaque(Character E,int nbr) {
            int nbrDice = Dice.RandomDices(nbr ,6 ,nbr);
            int nbrDamage = nbrDice + Bonus(StatType.force);
            nbrDamage = nbrDamage < 0 ? 0 : nbrDamage;
            E.Stats[StatType.hp] -= nbrDamage;

            }
       


        protected int Bonus(StatType t) {
            int bonusHp;

            if ( Stats[t] < 5 ) {
                bonusHp = -1;
                }
            else if ( Stats[t] > 5 && Stats[t] < 10 ) {
                bonusHp = 0;
                }
            else if ( Stats[t] > 10 && Stats[t] < 15 ) {
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
                sb.AppendLine($"{(StatType) i} : {Stats[(StatType) i]}");
                }
            return sb.ToString();
            
            }
        
        
      
        

        }
   

    }
