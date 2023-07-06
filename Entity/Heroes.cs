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
        public int lvl = 1;
        public int xp = 1;
        private int yaw;
        public string Icon;
        public Heroes(string icon) {
            Icon = icon;
            }   
        public void grantXp(Monster monster) {
            xp += monster.GrantXp;
            LevelUp();
            }
        public void LevelUp() {
            yaw = (int) Math.Round((double) ( 25 * lvl * ( 1 + lvl ) ));
            if ( yaw <= xp ) {
                lvl += 1;
                }
            xp %= yaw;
            yaw = (int) Math.Round((double) ( 25 * lvl * ( 1 + lvl ) ));
            if ( yaw <= xp ) {
                LevelUp();
                }
            }
    
        }
    }
