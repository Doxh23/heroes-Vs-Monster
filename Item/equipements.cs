using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace heroes_Vs_Monster.Item
{
    public class Equipements
    {

        public Dictionary<equipementType,Equipement> l = new();


        public Equipements() {
            l[equipementType.pied] = new Equipement(); 
            }
        public Equipement? this[equipementType stuff] {
            get {
                if ( !l.ContainsKey(stuff) ) {
                    l.Add(stuff ,null);
                    }
                return l[stuff];

                }
            set {
                if ( !l.ContainsKey(stuff) ) {
                    l.Add(stuff ,value);
                    }
                l[stuff] = value;
                }
            }

        public int getValueStat(StatType statType) {
            return l.Sum(e => e.Value is null ? 0 : e.Value.stats[statType]);
            }
    }
}
