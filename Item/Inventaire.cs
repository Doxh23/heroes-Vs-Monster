using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace heroes_Vs_Monster.Item {
    public enum LootType {
        cuir, or
        }
    public class Inventaire {
       

        public Inventaire() {
            }

        public Dictionary<LootType ,int> Loots = new();

        public int this[LootType type] {
            get {
                if ( !Loots.ContainsKey(type) )
                    Loots.Add(type, 0);
                return Loots[type];
                }
            set {
                if ( !Loots.ContainsKey(type) ) {
                    Loots.Add(type ,0);
                    }
                 Loots[type] = value;

                }
            }
        }
    }
