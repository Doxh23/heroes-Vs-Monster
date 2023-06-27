using System;
using heroes_Vs_Monster.utils;
/// <summary>
/// Summary description for Class1
/// </summary>
/// 
namespace heroes_Vs_Monster.Entity {
    public class Dwarf:Heroes {
        public string Name;

        public Dwarf(string name) : base() {
        Name =name;
            }
        protected override void statsGeneration() {
            base.statsGeneration();
            stats[StatType.force] += 2;
            
            }

        }
    }

