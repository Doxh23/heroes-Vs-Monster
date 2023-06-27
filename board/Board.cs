using heroes_Vs_Monster.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using heroes_Vs_Monster.utils;
using System.Diagnostics;
using heroes_Vs_Monster.Item;
using System.Security.Cryptography.X509Certificates;
using System.Runtime.CompilerServices;
using System.Xml;
using System.ComponentModel.Design;

namespace heroes_Vs_Monster.board {
    static class Board {
        static public int x = 140;
        static public int y = 50;
        static private int yPositionForStat = 4;
        static private int xPositionForStat = x - 28;
        static private int xPositionForItem = x - 28;
        static private int yPositionForItem;
        static public int HeroPositionX = ( x - 2 - 32 ) / 2;
        static public int HeroPositionY = ( y - 11 ) / 2;
        static public int bottomInformationY = y-2;
        static public int bottomInformationX = x - 32;
        static public int logPositionY = ( y - 10 ) / 2;
        public static ConsoleColor BasicBackground = ConsoleColor.Blue;
        public static ConsoleColor Background = ConsoleColor.White;
        public static ConsoleColor fontColor = ConsoleColor.White;
        public static ConsoleColor selectColor = ConsoleColor.Blue;
       

        public static void InitBoard(Heroes? hero = null) {
            yPositionForItem = yPositionForStat + Enum.GetValues(typeof(StatType)).Length * 2 +2;
            Console.ResetColor();
            Console.BackgroundColor = BasicBackground;
            BaseBoard();

            updateStats(hero);
            for ( int i = 2; x >= i + bottomInformationX + 6; i++ ) {
                Console.SetCursorPosition(i + bottomInformationX + 1 ,yPositionForItem - 2);
                if ( i == 2 || i == 3 || i == x - bottomInformationX - 6 || x - bottomInformationX - 7 == i ) {
                    Console.Write("*");
                    }
                else {
                    Console.Write("-");

                    }

                }

            updateLoots(hero);

            }

        private static void updateLoots(Heroes? hero) {
            for ( int i = 0; i < Enum.GetValues(typeof(LootType)).Length * 2; i++ ) {
                Console.SetCursorPosition(xPositionForItem ,yPositionForItem + i);

                if ( i % 2 == 0 ) {
                    Console.Write($" {(LootType) ( i / 2 )}  :{hero.inventaire[(LootType) ( i / 2 )]}");

                    }

                }
            }

        private static void updateStats(Heroes? hero) {
            for ( int i = 0; i < Enum.GetValues(typeof(StatType)).Length * 2; i++ ) {
                Console.SetCursorPosition(xPositionForStat ,yPositionForStat + i);

                if ( i % 2 == 0 ) {
                    Console.Write($" {(StatType) ( i / 2 )}  :{hero.stats[(StatType) ( i / 2 )]}");

                    }


                }
            }

        public static void BaseBoard() {
            Console.SetCursorPosition(0 ,0);
            StringBuilder sb = new StringBuilder();

            for ( int i = 0; i < y; i++ ) {

                for ( int b = 0; b < x - 1; b++ ) {

                    if ( ( b == 0 || b == x - 2 || b == x - 32 ) && i != 0 ) {
                        sb.Append('|');
                        }
                    else if ( !( b == 0 || b == x - 2 || b == x - 32 ) && ( i == y - 1 || i == 0 || i == y - 10 )  ) {
                        sb.Append('_');
                        }

                    else {
                        sb.Append(' ');
                        }

                    }
                sb.Append("\n");
                }
            Console.SetWindowSize(x ,y + 2);
            Console.WriteLine(sb.ToString());
            }
        public static void UpdateBoard(Heroes hero) {
            Console.SetCursorPosition(0 ,0);
            StringBuilder sb = new StringBuilder();
            for ( int b = 1; b < x - 33; b++ ) {
                sb.Append(" ");
                }
            for ( int i = 1; i < y - 10; i++ ) {
                Console.SetCursorPosition(1 ,0 + i);
                Console.Write(sb.ToString());


                }
            updateLoots(hero);
            Utils.LogCombatReset();

            }
       
        }


    }

