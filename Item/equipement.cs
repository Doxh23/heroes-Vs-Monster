using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace heroes_Vs_Monster.Item
{
    public enum equipementType
    {
        tete, epaule, torse, jambes, pied
    }
    public class Equipement
    {

        public int lvl;
        public string desciption;
        public int resistance;
        public int resistanceMagie;
        public int rarity;
        public Stats stats;
        public Equipement() {
            stats = new (1);
            }
    }
}
