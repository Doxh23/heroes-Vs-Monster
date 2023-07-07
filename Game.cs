using heroes_Vs_Monster.board;
using heroes_Vs_Monster.Entity;
using heroes_Vs_Monster.Item;
using heroes_Vs_Monster.utils;

namespace heroes_Vs_Monster {
    public class Game {
        public bool isAlive = true;
        public string m;
        public Heroes hero = new Voleur("dante" ,"😂");

        public Game() {
            /// TODO moment de rencontre avec un monstre

            Console.CursorVisible = false;
            Board.InitBoard(hero);
            int moveX = Board.HeroPositionX;
            int moveY = Board.HeroPositionY;
            Console.SetCursorPosition(moveX ,moveY);
      
            while ( isAlive ) {

                ConsoleKeyInfo k = Console.ReadKey(true);
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
                    case ConsoleKey.Escape:
                    break;
                    case ConsoleKey.I:
                    //showIventaire();
                    break;
                    case ConsoleKey.C:
                    //showCraftMenu();
                    break;
                    break;

                    default:
                    continue;
                  
                    }

                isAlive =Rencontre(hero);
                Board.UpdateBoard(hero);
                Board.SetHeroPosition(hero,moveX,moveY);
               


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
            hero.Materiaux[(LootType) nbr] += 2;
            }

        public bool CombatAleatoire() {
            
            Monster monster = Utils.generateMonster(hero);
            // changer l'action vers le monde die event etc
            Board.displayAscii(monster.AsciiArt);

            do {
                Board.BottomRightSquare(hero ,monster,SquareType.log);
                int rps = Nav.NavList(10  ,9 ,Board.y-8);
                switch ( rps ) {
                    
                    case 0:
                        hero.Attaque(monster ,1);
                    break;
                    default:
                    continue;
                  
                    
                    }
                // a changer car a gerer dans le character et l'attaque
                if ( monster.currentHp <= 0 ) {
               
                    return true;
                    }
                monster.Attaque(hero ,1);
                if ( hero.currentHp <= 0 ) {
                    return false;
                    }
                
                }
            while ( true );

            }





        }
        }

