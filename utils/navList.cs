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
            Console.SetCursorPosition(x ,y);
            int element = Enum.GetValues(typeof(ActionP)).Length;
            int moveX = x;
            int moveY = y;
            displayNavList(x,y,distance,element);
            do {
                ConsoleKeyInfo consoleKeyInfo = Console.ReadKey();
                switch ( consoleKeyInfo.Key ) {
                    case ConsoleKey.LeftArrow:
                    if ( moveX-distance < x ) {
                        moveX = distance * element+x;
                        }
                    else {
                        moveX -= ( distance );
                        }
                    break;
                    case ConsoleKey.RightArrow:

                    if ( moveX+element > x+ distance*element  ) {
                        moveX = x;
                        }
                    else {
                        moveX += ( distance );
                        }
                    break;
                    case ConsoleKey.Spacebar:
                    return ( (moveX-x) / distance );
                    default:
                    break;

                    }
                Console.SetCursorPosition(moveX ,moveY);
                } while ( true );
            }

        private static void displayNavList(int x, int y,int distance,int element) {
            StringBuilder sb = new StringBuilder();
            for ( int i = 0; i < element; i++ ) {
                sb.Append((ActionP)i);
                int whiteSpace = Utils.diffMaxCharacter(( (ActionP) i ).ToString(),distance);
                for(int  j = 0; j < whiteSpace; j++ ) {
                    sb.Append(" ");
                    }
                }
            Console.Write(sb.ToString());


            }
        }
    }
