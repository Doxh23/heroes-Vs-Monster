using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace heroes_Vs_Monster.Entity {
    public abstract class Monster:Character {
        protected  int Lvl;
        public int GrantXp {
            get;set;
            }
        public Monster(int lvlHero) {
        //SetupLvl(lvlHero);
            GrantXp = ( ( 25 * Lvl ) * ((int)1 + Lvl/4 ) );
            //((Lvl+81)-92)*0.02
            }

        protected abstract void SetupLvl(int LvlHero);
           
       
        }
    }
