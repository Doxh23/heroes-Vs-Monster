using System;
using heroes_Vs_Monster.utils;
/// <summary>
/// Summary description for Class1
/// </summary>
/// 

namespace heroes_Vs_Monster.Entity {
    public class Human:Heroes {

        public Human(string name)  {
            Name = name;
            }
       
        protected override void statsGeneration() {
            base.statsGeneration();
            stats[StatType.hp] += +4;
            }
        }

    }

