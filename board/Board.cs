using heroes_Vs_Monster.Entity;
using System.Text;
using heroes_Vs_Monster.utils;
using heroes_Vs_Monster.Item;

namespace heroes_Vs_Monster.board {
    static class Board {

        // faire classe qui permet de modifier une cellule
        static public int x = 140;
        static public int y = 40;
        static private int yPositionForStat = 4;
        static private int xPositionForStat = x - 28;
        static private int xPositionForItem = x - 28;
        static private int yPositionForItem;
        public static int HeroPositionX = ( x - 2 - 32 ) / 2;
        public static int HeroPositionY {
            get; private set;
            } = ( y - 11 ) / 2;

        static public int bottomInformationY = y - 2;
        static public int bottomPositionY = y - 10;
        static public int bottomInformationX = x - 32;
        static public int logPositionY = ( y - 10 ) / 2;
        public static ConsoleColor BasicBackground = ConsoleColor.Blue;
        public static ConsoleColor SelectBackground = ConsoleColor.White;
        public static ConsoleColor fontColor = ConsoleColor.White;
        public static ConsoleColor selectFontColor = ConsoleColor.Blue;


        public static void InitBoard(Heroes? hero = null) {
            Console.SetWindowPosition(0 ,0);
            yPositionForItem = yPositionForStat + Enum.GetValues(typeof(StatType)).Length * 2 + 2;
            Console.ResetColor();
            Console.BackgroundColor = BasicBackground;
            BaseBoard();

            UpdateStats(hero);

            UpdateLoots(hero);
            SetHeroPosition(hero ,HeroPositionX ,HeroPositionY);
            resetGameBoard();
            }

        private static void UpdateLoots(Heroes? hero) {
            for ( int i = 0; i < Enum.GetValues(typeof(LootType)).Length * 2; i++ ) {
                Console.SetCursorPosition(xPositionForItem ,yPositionForItem + i);

                if ( i % 2 == 0 ) {
                    Console.Write($" {(LootType) ( i / 2 )}  :{hero?.Inventaire[(LootType) ( i / 2 )]}");

                    }

                }
            }
        private static void UpdateStats(Heroes? hero) {
            // a voir avec stats dans character
            for ( int i = 0; i < Enum.GetValues(typeof(StatType)).Length * 2; i++ ) {
                Console.SetCursorPosition(xPositionForStat ,yPositionForStat + i);

                if ( i % 2 == 0 ) {
                    Console.Write($" {(StatType) ( i / 2 )}  :{hero?.getValueStat((StatType) ( i / 2 ))} ");

                    }


                }
            }
        public static void SetHeroPosition(Heroes Hero ,int x ,int y) {
            HeroPositionX = x;
            HeroPositionY = y;
            Console.SetCursorPosition(HeroPositionX ,HeroPositionY);
            Console.Write(Hero.Icon);
            }
       static public void resetGameBoard() {
            for ( int i = 0; i < y; i++ ) {

                for ( int b = 0; b < x - 1; b++ ) {
                    Console.SetCursorPosition(b ,i);

                    if ( b > 0 && i > 0 && b < bottomInformationX && i < bottomPositionY )

                        Console.Write("f");
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
            Utils.LogCombatReset();

            }
        public static void displayAscii(string ascii) {

            }

        public static void SetColor(ConsoleColor background ,ConsoleColor font) {

            Console.ForegroundColor = font;
            Console.BackgroundColor = background;

            }
        }
        }
  

