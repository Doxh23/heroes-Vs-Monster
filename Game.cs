using heroes_Vs_Monster.board;
using heroes_Vs_Monster.Entity;
using heroes_Vs_Monster.Item;
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
            int moveX = Board.HeroPositionX;
            int moveY = Board.HeroPositionY;
            Console.SetCursorPosition(moveX ,moveY);

            while ( isAlive ) {

                ConsoleKeyInfo k = Console.ReadKey();
                switch ( k.Key ) {

                    case ConsoleKey.UpArrow:
                    if ( moveY != 1 ) {
                        moveY -= 1;
                        }
                    break;
                    case ConsoleKey.DownArrow:
                    if ( moveY != Board.y - 11 ) {
                        moveY += 1;
                        }
                    break;
                    case ConsoleKey.RightArrow:
                    if ( moveX != Board.x - 34 ) {
                        moveX += 1;
                        }
                    break;
                    case ConsoleKey.LeftArrow:
                    if ( moveX != 1 ) {
                        moveX -= 1;
                        }
                    break;

                    default:
                    break;
                    }
                isAlive =Rencontre(hero);
                Board.UpdateBoard(hero);
                Console.SetCursorPosition(moveX ,moveY);
                Console.Write("@");


                }


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

        private bool Rencontre(Heroes hero) {
            int nbr = new Random().Next(10);
            switch ( nbr ) {
                case 1:
                case 2:
                case 3:
                case 4:
                case 5:
                case 6:

                break;

                case 7:
                getLoot(hero);
                break;
                case 8:
                case 9:

               return CombatAleatoire();

                }
            return true;
            }

        private void getLoot(Heroes hero) {
            int nbr = new Random().Next(2);
            hero.inventaire[(LootType) nbr] += 2;
            }

        public bool CombatAleatoire2() {
                Character monster = Utils.generateMonster();

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
        public bool CombatAleatoire() {
            
            Character monster = Utils.generateMonster();

            hero.LootEvent += hero.HealAction;
            hero.LootEvent += hero.LootAction;

            do {
               int rps = Nav.NavList(10 ,4 ,5 ,25);
                Console.WriteLine(rps);
                switch ( rps ) {
                    case 0:
                        hero.Attaque(monster ,1);
                    break;
                    }
                Console.WriteLine($"{monster.stats[StatType.hp]} :   monstre");
                if ( monster.stats[StatType.hp] <= 0 ) {
                    
                    return true;
                    }
                monster.Attaque(hero ,1);
                if ( hero.stats[StatType.hp] <= 0 ) {
                    return false;
                    }
                Console.WriteLine($"{hero.stats[StatType.hp]} :   hero");

                }
            while ( true );

            }





        }
        }

