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

                Board.chooseStat();
                int r = new Random().Next(Enum.GetValues(typeof(StatType)).Length);
                int rStats = new Random().Next(1,Dice.RandomDice(Dice.DiceType.d4));

                stats[(StatType) r] += rStats;
                }
            xp %= necessaryXp;
            necessaryXp = (int) Math.Round((double) ( 25 * lvl * ( 1 + lvl ) )*2);
            if ( necessaryXp <= xp ) {
                LevelUp();
                }
            }
        public override int getValueStat(StatType stat) {
            if(stat == StatType.hp ) {
                return stats[stat] + stats.Bonus(StatType.endurance) + equipements.getValueStat(stat);
                }
            return stats[stat] + stats.Bonus(stat) + equipements.getValueStat(stat);
            }
        public void FullLife() {
            currentHp = hp;
            // currentMp = mp;
            } 
    
        }
    }
