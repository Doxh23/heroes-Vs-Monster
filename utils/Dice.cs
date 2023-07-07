using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace heroes_Vs_Monster.utils {
    static class Dice {
        public enum DiceType {
            d4 =4,
            d6 = 6,
            d8 =8,
            d10 = 10,
            d20 = 20,
            d100 = 100
            }

       public static int RandomDice(DiceType dice) {
            Random r = new Random();
            int nbr = r.Next((int)dice + 1);
            return nbr;
            }
       public static int RandomDices(int q ,DiceType dice ,int nbrToTake) {
            List<int> l = new List<int>();
            for ( int i = 0; i < q; i++ ) {
                l.Add(RandomDice(dice));
                }
            return l.OrderByDescending(x => x).Take(nbrToTake).Sum();
            }
        }
    }
