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
            stats[StatType.hp] += 15;
            inventaire.Loots[LootType.or] = Dice.RandomDices(1 ,4 ,1);
            inventaire.Loots[LootType.cuir] = Dice.RandomDices(1 ,4 ,1);
            Name = "dragonnet";
            }
        }
    }
