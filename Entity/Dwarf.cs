using System;
using heroes_Vs_Monster.utils;
/// <summary>
/// Summary description for Class1
/// </summary>
/// 
namespace heroes_Vs_Monster.Entity {
    public class Dwarf:Heroes {
        

        public Dwarf(string name,string icon) : base(icon) {
        Name =name;
            }
        protected override void statsGeneration() {
            base.statsGeneration();
            Stats[StatType.force] += 2;
            
            }

        }
    }

