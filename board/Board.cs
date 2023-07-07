﻿using heroes_Vs_Monster.Entity;
using System.Text;
using heroes_Vs_Monster.utils;
using heroes_Vs_Monster.Item;
using System.Drawing;
using System.Diagnostics;
using System.Threading;

namespace heroes_Vs_Monster.board {

    public enum SquareType {
        log
        }
    static class Board {

        // faire classe qui permet de modifier une cellule
        static public int x = 140;
        static public int y = 40;
        static public int SizeRightSide = 32;
        static public int boardX = RightSideX - 2;
        static public int boardY = y - 12;
        static private int yPositionForStat = 4;
        static private int xPositionForStat = x - SizeRightSide + 4;
        static private int xPositionForItem = x - SizeRightSide + 4;
        static private int yPositionForItem;
        public static int HeroPositionX = ( x - 2 - SizeRightSide ) / 2;
        public static int HeroPositionY {
            get; private set;
            } = ( y - 11 ) / 2;

        static public int bottomInformationY = y - 2;
        static public int BottomY = y - 10;
        static public int RightSideX = x - 32;
        static public int RightSideY = y - 10;
        static public int logPositionY = ( y - 10 ) / 2;
        public static ConsoleColor BasicBackground = ConsoleColor.DarkCyan;
        public static ConsoleColor SelectBackground = ConsoleColor.White;
        public static ConsoleColor fontColor = ConsoleColor.White;
        public static ConsoleColor selectFontColor = ConsoleColor.Blue;


        public static void InitBoard(Heroes? hero = null) {
            Console.SetWindowPosition(0 ,0);
            yPositionForItem = yPositionForStat + Enum.GetValues(typeof(StatType)).Length * 2 + 3;
            Console.ResetColor();
            Console.BackgroundColor = BasicBackground;
            BaseBoard();
            UpdateStats(hero);

            UpdateLoots(hero);
            SetHeroPosition(hero ,HeroPositionX ,HeroPositionY);
            resetGameBoard(0);
            }

        private static void UpdateLoots(Heroes? hero) {
            for ( int i = 0; i < Enum.GetValues(typeof(LootType)).Length * 2; i++ ) {
                Console.SetCursorPosition(xPositionForItem ,yPositionForItem + i);

                if ( i % 2 == 0 ) {
                    Console.Write($"{(LootType) ( i / 2 )}  :{hero?.Materiaux[(LootType) ( i / 2 )]}");

                    }

                }
            }
        public static void chooseStat() {
            Console.SetCursorPosition(4 ,boardY / 2);
            Console.Write("Level Up!!!!");
            Console.SetCursorPosition(5 ,boardY / 2 + 2);
            Console.Write("quel stats voulez vous augmenter?");

            }
        private static void UpdateStats(Heroes hero) {
            // a voir avec stats dans character
            using ( var reader = new StringReader(hero.ToString()) ) {
                int i = 0;
                for ( string line = reader.ReadLine(); line != null; line = reader.ReadLine() ) {
                    Console.SetCursorPosition(xPositionForStat ,yPositionForStat + i);
                    Console.Write(line.Trim());
                    i += 2;

                    }
                }


            }
        public static void SetHeroPosition(Heroes Hero ,int x ,int y) {
            HeroPositionX = x;
            HeroPositionY = y;
            Console.SetCursorPosition(HeroPositionX ,HeroPositionY);
            Console.Write(Hero.Icon);
            }
        static public void resetGameBoard(int wait) {
            for ( int i = 0; i < y; i++ ) {
                for ( int b = 0; b < x - 1; b++ ) {
                    Utils.sleep(wait);

                    Console.SetCursorPosition(b ,i);

                    if ( b > 0 && i > 0 && b < RightSideX && i < BottomY )

                        Console.Write(" ");


                    }

                }

            }
        public static void BaseBoard() {
            Console.SetCursorPosition(0 ,0);
            StringBuilder sb = new StringBuilder();

            for ( int i = 0; i < y; i++ ) {

                for ( int b = 0; b < x - 1; b++ ) {

                    if ( ( b == 0 || b == x - 2 || b == x - 32 ) && i != 0 || ((b == 35) && i > y-10) ) {
                        sb.Append('|');
                        }
                    else if ( !( b == 0 || b == x - 2 || b == x - 32 ) && ( i == y - 1 || i == 0 || i == y - 10 ) ) {
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
            BaseBoard();
            UpdateLoots(hero);
            UpdateStats(hero);

            }
        public static void resetBlock(int q ,int y ,int startPositionX ,int StartPositionY) { // peut etre transformer pour reset la partie que j'ai envie

            for ( int i = 0; i < q; i++ ) {
                Console.SetCursorPosition(RightSideX + 1 ,RightSideY+1+i);
                for ( int j = 0; j < y; j++ ) {
                    Console.Write(" ");
                    }
                }
            }
        public static void BottomRightSquare(Character hero ,Character monster ,SquareType square) {

            int y = bottomInformationY + 2;

            switch ( square ) {
                case SquareType.log:
                resetBlock(8 ,SizeRightSide - 3 ,RightSideX - 2 ,yPositionForItem + 5);
                logInfo(hero ,monster);
                break;
                default:
                break;
                }




            }

        static private void logInfo(Character hero ,Character monster) {
            Console.SetCursorPosition(x - 28 ,RightSideY + 2);
            Console.Write($"{hero.Name}");
            Console.SetCursorPosition(x - 28 ,RightSideY + 3);
            Console.Write($"--------------");
            Console.SetCursorPosition(x - 28 ,RightSideY + 4);
            Console.Write($"hp  :   {hero.currentHp}");
            Console.SetCursorPosition(x - 28 ,RightSideY + 5);
            Console.Write($"-------------------");
            Console.SetCursorPosition(x - 28 ,RightSideY + 6);
            Console.Write($"{monster.Name}");
            Console.SetCursorPosition(x - 28 ,RightSideY + 7);
            Console.Write($"--------------");
            Console.SetCursorPosition(x - 28 ,RightSideY + 8);
            Console.Write($"hp  :   {monster.currentHp}");
            }
        public static void displayAscii(string ascii) {
            SetColor(ConsoleColor.Black ,fontColor);

            resetGameBoard(1500);
            int i = 0;
            using ( var reader = new StringReader(ascii) ) {
                int height = ( boardY - ascii.Split("\n").Count() ) / 2;

                for ( string line = reader.ReadLine(); line != null; line = reader.ReadLine() ) {
                    int centerPosition = (int) Math.Floor((double) ( RightSideX - 2 - line.Length ) / 2);
                    Utils.sleep(400000);

                    Console.SetCursorPosition(centerPosition ,height + i);

                    Console.Write(line);
                    i++;
                    }
                }
            SetColor(BasicBackground ,fontColor);

            }

        public static void SetColor(ConsoleColor background ,ConsoleColor font) {

            Console.ForegroundColor = font;
            Console.BackgroundColor = background;

            }
        }
    }


