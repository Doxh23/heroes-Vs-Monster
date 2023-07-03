using heroes_Vs_Monster.board;
using heroes_Vs_Monster.Entity;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace heroes_Vs_Monster.utils {
    public static class Utils {
        
        public static int DiffMaxCharacter(string s ,int max) {
            return max - s.Length;
            }
        public static void LogCombat(Character hero ,Character monster) {
            LogCombatReset();
            int y = Board.bottomInformationY+2;
            Console.SetCursorPosition(Board.x - 28 ,y - 8);
            Console.Write($"{hero.Name}");
            Console.SetCursorPosition(Board.x - 28 ,y - 7);
            Console.Write($"--------------");
            Console.SetCursorPosition(Board.x - 28 ,y - 6);
            Console.Write($"hp  :   {hero.hp}");
            Console.SetCursorPosition(Board.x - 28 ,y - 5);
            Console.Write($"-------------------");
            Console.SetCursorPosition(Board.x - 28 ,y - 4);
            Console.Write($"{monster.Name}");
            Console.SetCursorPosition(Board.x - 28 ,y - 3);
            Console.Write($"--------------");
            Console.SetCursorPosition(Board.x - 28 ,y - 2);
            Console.Write($"hp  :   {monster.hp}");



            }
        public static void LogCombatReset() { // peut etre transformer pour reset la partie que j'ai envie
            int x = Board.bottomInformationX + 3;
            int y = Board.bottomInformationY;
            for ( int i = 0; i < 8; i++ ) {
                Console.SetCursorPosition(x ,y - i);
                for ( int j = 0; j < Board.x - x - 2; j++ ) {
                    Console.Write(" ");
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

                character = new Loup(hero.lvl);
                break;
                case 5:
                case 6:
                case 7:

                character = new Orc(hero.lvl);
                break;
                case 8:
                case 9:
                character = new Dragonnet(hero.lvl);
                break;

                }
            character.DieEvent += hero.HealAction;
            character.DieEvent +=hero.LootAction;
            //character.DieEvent += hero.grantXp;// a revoir
            return character;


            }
        }
    }
