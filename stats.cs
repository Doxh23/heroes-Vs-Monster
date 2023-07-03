using heroes_Vs_Monster.Entity;
using heroes_Vs_Monster.utils;
using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace heroes_Vs_Monster {
    public enum StatType {
        hp,force,endurance,vitesse
        }
    public class Stats {



        public Dictionary<StatType ,int> Stat = new Dictionary<StatType ,int>();

        public Stats() {
        
            
            }

        public int this[StatType stat] {
            get {
                if ( !Stat.ContainsKey(stat) ) {
                    Stat.Add(stat ,0);
                    }
                return Stat[stat];
                }
            set {
                if ( !Stat.ContainsKey(stat) ) {
                    Stat.Add(stat ,0);
                    }
                Stat[stat] = value;
                }
            }

        private void GenerateStats() {
            Stat[StatType.force] = Dice.RandomDices(4 ,4 ,3);
            Stat[StatType.endurance] = Dice.RandomDices(4 ,4 ,3);

            Stat[StatType.hp] = Dice.RandomDices(4 ,4 ,3) + Bonus(StatType.endurance);
            Stat[StatType.vitesse] = Dice.RandomDices(4 ,4 ,3);
            }
        public int Bonus(StatType t) {
            // faire un foreach pour calculer les nouvelles stats
            int bonusHp;

            if ( Stat[t] < 5 ) {
                bonusHp = -1;
                }
            else if ( Stat[t] > 5 && Stat[t] < 10 ) {
                bonusHp = 0;
                }
            else if ( Stat[t] > 10 && Stat[t] < 15 ) {
                bonusHp = 1;
                }
            else {
                bonusHp = 2;
                }
            return bonusHp;
            }
        }
    }
