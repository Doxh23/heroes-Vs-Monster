﻿using heroes_Vs_Monster.Entity;
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

namespace heroes_Vs_Monster.board {
    static class Board {
        static private int x = 140;
        static private int y = 50;
        static private int yPositionForStat = 4;
        static private int xPositionForStat = x - 28;
        static private int xPositionForItem = x - 28;
        static private int yPositionForItem;
        static public int HeroPositionX = ( x - 2 - 32 ) / 2;
        static public int HeroPositionY = y - 11 / 2;


        public static void InitBoard(Heroes? hero = null) {
            Console.ResetColor();
            Console.BackgroundColor = ConsoleColor.Blue;
            BaseBoard();


            for ( int i = 0; i < Enum.GetValues(typeof(StatType)).Length * 2; i++ ) {
                Console.SetCursorPosition(xPositionForStat ,yPositionForStat + i);

                if ( i % 2 == 0 ) {
                    Console.Write($" {(StatType) ( i / 2 )}  :{hero.stats[(StatType) ( i / 2 )]}");

                    }


                }
            yPositionForItem = yPositionForStat + Enum.GetValues(typeof(StatType)).Length * 2 + 4;
            for ( int i = 0; i < Enum.GetValues(typeof(LootType)).Length * 2; i++ ) {
                Console.SetCursorPosition(xPositionForItem ,yPositionForItem + i);

                if ( i % 2 == 0 ) {
                    Console.Write($" {(LootType) ( i / 2 )}  :{hero.inventaire[(LootType) ( i / 2 )]}");

                    }

                }
            //else if ( b == ( x - 2 - 32 ) / 2 && i == ( y - 11 ) / 2 ) {
            //   sb.Append("€");
            //   }






            }

        private static void BaseBoard() {
            StringBuilder sb = new StringBuilder();

            for ( int i = 0; i < y; i++ ) {

                for ( int b = 0; b < x - 1; b++ ) {

                    if ( ( b == 0 || b == x - 2 || b == x - 32 ) && i != 0 ) {
                        sb.Append("|");
                        }
                    else if ( !( b == 0 || b == x - 2 || b == x - 32 ) && ( i == y - 1 || i == 0 || i == y - 10 ) ) {
                        sb.Append("_");
                        }

                    else {
                        sb.Append(" ");
                        }

                    }
                sb.Append("\n");
                }
            Console.SetWindowSize(x ,y);
            Console.WriteLine(sb.ToString());
            }
        }


    }

