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
            int moveX = x;
            int moveY = y;
            DisplayNavList(x ,y ,distance ,element ,( ( moveX - x ) / distance ));
            do {
                ConsoleKeyInfo consoleKeyInfo = Console.ReadKey(true);
                switch ( consoleKeyInfo.Key ) {
                    case ConsoleKey.LeftArrow:
                    if ( moveX-distance < x ) {
                        moveX = distance * (element-1)+x;
                        }
                    else {
                        moveX -= ( distance );
                        }
                    DisplayNavList(x ,y ,distance ,element,(( moveX - x ) / distance));

                    break;
                    case ConsoleKey.RightArrow:

                    if ( moveX+element > x+ distance*(element-1)  ) {
                        moveX = x;
                        }
                    else {
                        moveX += ( distance );
                        }
                    DisplayNavList(x ,y ,distance ,element,( moveX - x ) / distance);

                    break;
                    case ConsoleKey.Spacebar:
                    return ( (moveX-x) / distance );
                    default:
                    break;

                    }
                Console.SetCursorPosition(moveX ,moveY);
                } while ( true );
            }

        private static void DisplayNavList(int x, int y,int distance,int element,int rps) {
            Console.SetCursorPosition(x ,y);
          
            
            for ( int i = 0; i < element; i++ ) {
                if ( i == rps ) {
                    Board.SetColor(Board.SelectBackground ,Board.selectFontColor);
                    }
                Console.Write((ActionP)i);
                Board.SetColor(Board.BasicBackground ,Board.fontColor);
                int whiteSpace = Utils.DiffMaxCharacter(( (ActionP) i ).ToString(),distance);
                for(int  j = 0; j < whiteSpace; j++ ) {
                    Console.Write(" ");
                    }
                }
            


            }
        }
    }
