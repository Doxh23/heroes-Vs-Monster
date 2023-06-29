using heroes_Vs_Monster.Item;
using heroes_Vs_Monster.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace heroes_Vs_Monster.Entity {
    public class Loup : Character{
        public int LootCuir {
            get; set;
            }
        public Loup() {
            base.statsGeneration();
            Stats[StatType.vitesse] += 5;
            Inventaire.Loots[LootType.cuir] = Dice.RandomDices(1 ,4 ,1);
            Name = "loup";
            }
        
        }
    }
