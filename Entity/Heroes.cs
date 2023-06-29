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
        public string Icon;
        public Heroes(string icon) {
            Icon = icon;
            }   
        public void LevelUp() {
            yaw = (int)Math.Round(lvl * 2.5 / 1.2);
            if ( yaw <= xp ) {
                lvl += 1;
                }
            xp %= yaw;
            yaw = (int) Math.Round(lvl * 2.5 / 1.2);
            if ( yaw <= xp ) {
                LevelUp();
                }
            }
        public void LootAction(Character monster) {
            for ( int i = 0; i < Enum.GetValues<LootType>().Count(); i++ ) {
                Inventaire[(LootType) i] += monster.Inventaire[(LootType) i];
                Console.WriteLine(( $"{(LootType) i} : {Inventaire[(LootType) i]}" ));
                }
            }
        public void RaiseLootAction(Character monster) {
            LootEvent?.Invoke(monster);
            }
        public void HealAction(Character hero) {
            Stats[StatType.hp] += Dice.RandomDices(1 ,100 ,1);
            }
        }
    }
