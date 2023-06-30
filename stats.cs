using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace heroes_Vs_Monster
    {
    public class Stats {



        private readonly Dictionary<StatType ,int> Stat = new Dictionary<StatType ,int>();

        public int this[StatType stat] {
            get {
                if ( !Stat.ContainsKey(stat) ) {
                    Stat.Add(stat ,0);
                    }
                return Stat[stat];
                }
            set {
                if ( !Stat.ContainsKey(stat) ) {
                    Stat.Add(stat ,0);
                    }
                Stat[stat] = value;
                }
            }
        }
    }
