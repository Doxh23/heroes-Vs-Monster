using heroes_Vs_Monster.board;
using heroes_Vs_Monster.Entity;

using heroes_Vs_Monster.utils;


namespace heroes_Vs_Monster {
    public class Game {
        public bool isAlive = true;
        public string m;
        Heroes hero = new Human("Dante");
        List<Character> monsters = new List<Character>();

        public Game() {

            /// TODO moment de rencontre avec un monstre
            Heroes hero = new Human("dante");

            Board.InitBoard(hero);



            //bool win;
            //Character monster = Utils.generateMonster();

            //win = CombatAleatoire(monster);
            //if ( win ) {

            //    hero.RaiseLootAction(monster);
            //    Console.WriteLine($"{hero.stats[StatType.hp]} : life");


            //    Console.WriteLine("vous avez gagné");
            //    }
            //else {
            //    Console.WriteLine("vous avez perdu");
            //    Environment.Exit(0);
            //    }







            }


       
        public bool CombatAleatoire(Character monster) {

            hero.LootEvent += hero.HealAction;
            hero.LootEvent += hero.LootAction;

            do {
                Console.WriteLine($"{hero.stats[StatType.hp]} : life");

                hero.Attaque(monster ,1);
                if ( monster.stats[StatType.hp] <= 0 ) {

                    return true;
                    }
                monster.Attaque(hero ,1);
                if ( hero.stats[StatType.hp] <= 0 ) {
                    return false;
                    }


                }
            while ( true );
           
            }
        




        }
    }

