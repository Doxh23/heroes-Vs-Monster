using heroes_Vs_Monster.board;
using heroes_Vs_Monster.Entity;
using heroes_Vs_Monster.Entity.Monster;
using heroes_Vs_Monster.Entity.Monster.Monster;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace heroes_Vs_Monster.utils
    {
    public static class Utils {
        
        public static int DiffMaxCharacter(string s ,int max) {
            return max - s.Length;
            }
       
      
        public static void sleep(int timerTicks) {
            Stopwatch stopwatch = Stopwatch.StartNew();
            while ( true ) {
                //some other processing to do possible
                if ( stopwatch.ElapsedTicks >= timerTicks ) {
                    break;
                    }
                }
            }
        public static Monster? generateMonster(Heroes hero) {

            int nbr = new Random().Next(1 ,10);
            Monster? character = null;
            switch ( nbr ) {
                case 1:
                case 2:
                case 3:
                case 4:

                character = new Loup(hero.lvl,AsciiArt.Loup);
                break;
                case 5:
                case 6:
                case 7:

                character = new Orc(hero.lvl,AsciiArt.orc);
                break;
                case 8:
                case 9:
                character = new Dragonnet(hero.lvl,AsciiArt.dragonnet);
                break;

                }
            character.DieEvent += hero.HealAction;
            character.DieEvent +=hero.LootAction;
            character.DieEvent += hero.grantXp;
            //character.DieEvent += hero.grantXp;// a revoir
            return character;


            }
        }
    }
