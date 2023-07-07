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
        public materiaux Materiaux = new materiaux();
        public Equipements equipements = new Equipements();
        public Action<Character>? DieEvent;
        public int lvl = 1;
        public int xp = 1;
        public int necessaryXp;


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


        public int hp => getValueStat(StatType.hp);
        public int force => getValueStat(StatType.force);

        public int endurance => getValueStat(StatType.endurance);

        public int vitesse => getValueStat(StatType.vitesse);
        public int resistance => getValueResistance(StatType.resistance);
        public int resistanceMagique => getValueResistance(StatType.resistanceMagique);



        public Character() {
            necessaryXp = (int) Math.Round((double) ( 25 * lvl * ( 1 + lvl ) ) * 2);
            stats = new Stats(lvl);

            _currentHp = hp;
            // verifier les enfants pour les stats 
            // protected value pour stats mais faire des methode pour aller chercher les stats
            }

        public virtual int getValueStat(StatType stat) {
            return stats[stat];
            }
        public virtual int getValueResistance(StatType stat) {

           
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
                Materiaux[(LootType) i] += character.Materiaux[(LootType) i];
                }
            }

        public void GrantXpAction(Character character) {
            
            }
        public void HealAction(Character character) {
            currentHp += Dice.RandomDices(1 ,Dice.DiceType.d6 ,1);
            }




        public override string ToString() {// stats a afficher a droite
            return @$"Hp : {currentHp} / {hp}
                     Force : {force}
                     Endurance : {endurance}
                     Vitesse : {vitesse}
                     resistance : {resistance}
                     resi magique : {resistanceMagique}
                     xp : {xp} / {necessaryXp}
                     lvl : {lvl}
";
                        








            }

        }
        }
