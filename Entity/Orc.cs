using heroes_Vs_Monster.Item;
using heroes_Vs_Monster.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace heroes_Vs_Monster.Entity {
    public class Orc:Character {
        
        public Orc() {
            base.statsGeneration();
            Stats[StatType.force] += 4;
            Inventaire.Loots[LootType.or] = Dice.RandomDices(1 ,4 ,1);
            Name = "orc";
            }
        }
    }
