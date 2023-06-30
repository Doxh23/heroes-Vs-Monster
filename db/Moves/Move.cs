using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace heroes_Vs_Monster.db.Moves
    {
    public class Move
        {
        public int damage;
        public string name;
        public string description;
        public EnumType type;

        public Move(int damage, string name, string description,)
            {
            this.damage = damage;
            this.name = name;
            this.description = description;
            this}
        }
    }
