using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace heroes_Vs_Monster.Entity.Monster.Monster
    {
    public abstract class Monster:Character
        {
        public string AsciiArt;
        protected int Lvl = 2;

        public Monster(int lvlHero ,string asciiArt)
            {
            AsciiArt = asciiArt;
            //SetupLvl(lvlHero);
            xp = 25 * Lvl * (1 + Lvl / 4)*4;
            //((Lvl+81)-92)*0.02
            }


        protected abstract void SetupLvl(int LvlHero);


        }
    }
