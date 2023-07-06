using heroes_Vs_Monster.Item;
using heroes_Vs_Monster.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace heroes_Vs_Monster.Entity {


    public class Character {

        private string name;
        protected Stats stats;
        private Inventaire inventaire = new();
        public Action<Character>? DieEvent;


        public bool IsAlive {
            get {
                return hp <= 0;
                }
            }
        private int _currentHp;
        public int currentHp {
            get {
                return _currentHp;
                }
            set {
                _currentHp = value < 0 ? 0 : value > hp ? hp : value;
                }
            }
        public string Name {
            get => name;
            set => name = value;
            }

        public Inventaire Inventaire {
            get => inventaire;
            set => inventaire = value;
            }
        public int hp => getValueStat(StatType.hp);
        public int force => getValueStat(StatType.force);

        public int endurance => getValueStat(StatType.endurance);

        public int vitesse => getValueStat(StatType.vitesse);



        public Character() {
            stats = new Stats();
            stats[StatType.hp] += 155;
            _currentHp = hp;
            // verifier les enfants pour les stats 
            // protected value pour stats mais faire des methode pour aller chercher les stats
            }

        public virtual int getValueStat(StatType stat) {
            return stats[stat];
            }
        public void setValueStat(StatType stat ,int nbr) {
            stats[stat] += nbr;
            }
        protected virtual void statsGeneration() {

            }
        public virtual void Attaque(Character target ,int nbr) {
            if ( target.currentHp <= 0 ) {
                target.DieEvent?.Invoke(target);

                }
            }
        public void DamageTaken(int nbrDamage) {
            currentHp -= nbrDamage;
            }
        public void LootAction(Character character) {
            for ( int i = 0; i < Enum.GetValues<LootType>().Count(); i++ ) {
                Inventaire[(LootType) i] += character.Inventaire[(LootType) i];
                }
            }

        public void HealAction(Character character) {
            currentHp += Dice.RandomDices(1 ,100 ,1);
            }




        public override string ToString() {// stats a afficher a droite
            return @$"Hp : {currentHp} / {hp}
                     Force : {force}
                     endurance : {endurance}
                     vitesse : {vitesse}";








            }

        }
        }
