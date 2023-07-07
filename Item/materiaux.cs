using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace heroes_Vs_Monster.Item
    {
    public class materiaux {
       

        public materiaux() {
            }

        public Dictionary<LootType ,int> materiel = new();

        public int this[LootType type] {
            get {
                if ( !materiel.ContainsKey(type) )
                    materiel.Add(type, 0);
                return materiel[type];
                }
            set {
                if ( !materiel.ContainsKey(type) ) {
                    materiel.Add(type ,0);
                    }
                 materiel[type] = value;

                }
            }
        }
    }
