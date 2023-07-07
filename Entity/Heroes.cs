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
      
        public string Icon;
        public Heroes(string icon) {
            stats[StatType.hp] += 10;
            Icon = icon;
            FullLife();
            }   
        public void grantXp(Character monster) {
             xp += monster.xp ;
            LevelUp();
            }
        public void LevelUp() {
            necessaryXp = (int) Math.Round((double) ( 25 * lvl * ( 1 + lvl ) )*2);
            if ( necessaryXp <= xp ) {
                lvl += 1;
                }
            xp %= necessaryXp;
            necessaryXp = (int) Math.Round((double) ( 25 * lvl * ( 1 + lvl ) )*2);
            if ( necessaryXp <= xp ) {
                LevelUp();
                }
            }
        public void FullLife() {
            currentHp = hp;
            // currentMp = mp;
            } 
    
        }
    }
