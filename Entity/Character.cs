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
        public event Action<Character> LootEvent;

        public bool IsAlive {
            get {
                return hp <= 0; 
                }
            }
        private int _currentHp;
        public int currentHp {
            get {
                return hp;
                }
            set {
                _currentHp = _currentHp < 0 ? 0 : value;
                }
            }
        public string Name {
            get => name;
            set => name = value;
            }
            
        public Inventaire Inventaire {
            get => inventaire;
            set => inventaire =  value ;
            }
        public int hp => getValueStat(StatType.hp);
        public int force => getValueStat(StatType.force);

        public int endurance => getValueStat(StatType.endurance);

        public int vitesse => getValueStat(StatType.vitesse);

        public Character() {
            stats = new Stats();
            // verifier les enfants pour les stats 
            // protected value pour stats mais faire des methode pour aller chercher les stats
            }

        public int getValueStat(StatType stat) {
            return stats[stat];
            }
        public void setValueStat(StatType stat, int nbr) {
            stats[stat] += nbr;
            }
        protected virtual void statsGeneration() {
           
            }
        public virtual void Attaque(Character E,int nbr) {
           
            E.RaiseLootAction(E);
            }
        public void DamageTaken(int nbrDamage) {
            stats[StatType.hp] -= nbrDamage;
            }

        public void RaiseLootAction(Character monster) {
            //lancer celui du monstre pour plus de simplicité?
            LootEvent?.Invoke(monster);
            }



        public override string ToString() {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"name : {Name}");
            for ( int i = 0; i < Enum.GetValues<StatType>().Count(); i++ ) {
                sb.AppendLine($"{(StatType) i} : {stats[(StatType) i]}");
                }
            return sb.ToString();
            
            }
        
        
      
        

        }
   

    }
