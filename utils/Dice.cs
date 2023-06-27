using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace heroes_Vs_Monster.utils {
    static class Dice {

       public static int RandomDice(int id) {
            Random r = new Random();
            int nbr = r.Next(id + 1);
            return nbr;
            }
       public static int RandomDices(int q ,int id ,int nbrToTake) {
            List<int> l = new List<int>();
            for ( int i = 0; i < q; i++ ) {
                l.Add(RandomDice(id));
                }
            return l.OrderByDescending(x => x).Take(nbrToTake).Sum();
            }
        }
    }
