using heroes_Vs_Monster.board;
using heroes_Vs_Monster.Item;
using heroes_Vs_Monster.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace heroes_Vs_Monster.Entity {
    public class Heroes : Character {
        public event Action<Character> LootEvent;
        public event Action<Character> HealEvent;
        public int lvl = 1;
        public int xp = 1;
        private int yaw;

        public Heroes() {
            }   
        public void LevelUp() {
            yaw = (int)Math.Round(lvl * 2.5 / 1.2);
            if ( yaw <= xp ) {
                lvl += 1;
                }
            xp = xp % yaw;
            yaw = (int) Math.Round(lvl * 2.5 / 1.2);
            if ( yaw <= xp ) {
                LevelUp();
                }
            }
        public void LootAction(Character monster) {
            for ( int i = 0; i < Enum.GetValues<LootType>().Count(); i++ ) {
                inventaire[(LootType) i] += monster.inventaire[(LootType) i];
                Console.WriteLine(( $"{(LootType) i} : {inventaire[(LootType) i]}" ));
                }
            }
        public void RaiseLootAction(Character monster) {
            LootEvent?.Invoke(monster);
            }
        public void HealAction(Character hero) {
            stats[StatType.hp] += Dice.RandomDices(1 ,4 ,1);
            }
        }
    }
