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


        public static Character? generateMonster() {
            int nbr = new Random().Next(1 ,10);
            Character? character = null;
            switch ( nbr ) {
                case 1:
                case 2:
                case 3:
                case 4:
                
                character = new Loup();
                break;
                case 5:
                case 6:
                case 7:
                
                character = new Orc();
                break;
                case 8:
                case 9:
                character = new Dragonnet();
                break;

                }
            return character;


            }
        }
    }
