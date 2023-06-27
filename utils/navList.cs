using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace heroes_Vs_Monster.utils {
    public static class Nav {

        public static int NavList(int distance ,int element,int x = 0 ,int y = 0) {
            Console.SetCursorPosition(x ,y);
            int moveX = x;
            int moveY = y;

            do {
                ConsoleKeyInfo consoleKeyInfo = Console.ReadKey();
                switch ( consoleKeyInfo.Key ) {
                    case ConsoleKey.LeftArrow:
                    if ( Console.GetCursorPosition().Left == x ) {
                        moveX = distance * element;
                        }
                    else {
                        moveX -= ( distance );
                        }
                    break;
                    case ConsoleKey.RightArrow:
                    break;
                    case ConsoleKey.Spacebar:
                    return ( (moveX-x) / distance );
                    default:
                    break;

                    }
                Console.SetCursorPosition(moveX ,moveY);
                } while ( true );
            }
        }
    }
