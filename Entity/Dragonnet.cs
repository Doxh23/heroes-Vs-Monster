using heroes_Vs_Monster.Item;
using heroes_Vs_Monster.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace heroes_Vs_Monster.Entity {
    public class Dragonnet: Character {
        public Dragonnet() {
            base.statsGeneration();
            Stats[StatType.hp] += 15;
            Inventaire.Loots[LootType.or] = Dice.RandomDices(1 ,4 ,1);
            Inventaire.Loots[LootType.cuir] = Dice.RandomDices(1 ,4 ,1);
            Name = "dragonnet";
            }
        }
    }
