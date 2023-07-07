using heroes_Vs_Monster.board;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace heroes_Vs_Monster.utils {
    public static class Nav {
        public enum ActionP {
            attaque,defense,heal,fuir
            }
        public static int NavList(int distance ,int x = 0 ,int y = 0) {
            int element = Enum.GetValues(typeof(ActionP)).Length;
            int moveX = 0;
            int moveY = 0;
            DisplayNavList(x ,y ,element ,moveY);
            do {
                ConsoleKeyInfo consoleKeyInfo = Console.ReadKey(true);
                switch ( consoleKeyInfo.Key ) {
                    case ConsoleKey.DownArrow:
                    if ( moveY == element+2 ) {
                        moveY = 0;
                        }
                    else {
                        moveY += 2;
                        }
                    DisplayNavList(x ,y ,element,moveY);

                    break;
                    case ConsoleKey.UpArrow:

                    if ( moveY == 0  ) {
                        moveY = 6;
                        }
                    else {
                        moveY -= 2;
                        }
                    DisplayNavList(x ,y  ,element,moveY);

                    break;
                    case ConsoleKey.Spacebar:
                    return ( moveY/2);
                    default:
                    break;

                    }
                Console.SetCursorPosition(moveX ,moveY);
                } while ( true );
            }

        private static void DisplayNavList(int x, int y,int element,int rps) {

            for ( int i = 0; i < element; i++ ) {
                Console.SetCursorPosition(x ,y+i*2);

                if ( i*2 == rps ) {
                    Board.SetColor(Board.SelectBackground ,Board.selectFontColor);
                    }
                Console.Write((ActionP)i);
                Board.SetColor(Board.BasicBackground ,Board.fontColor);
            
                }
            


            }
        }
    }
