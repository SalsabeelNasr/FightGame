using System;

namespace FightGame
{
    public class Warrior
    {
        public string Name { get; set; } = "Warrior";
        private double health = 0;
        public double Health
        {
            get
            {
                return health;
            }
            set
            {
                if (value <= 0)
                    IsDead = true;
                health = value;
            }
        }
        public int AttackMax { get; set; } = 0;
        public double BlockMax { get; set; } = 0;
        public bool IsDead { get; set; } = false;

        Random rnd = new Random(DateTime.Now.Second);

        public Warrior(string name , double health = 0 , int attackMax = 0 , double blockMax = 0)
        {
            this.Name = name;
            this.Health = health;
            this.AttackMax = attackMax;
            this.BlockMax = blockMax;
        }
        public double GetAttack()
        {
           return rnd.Next(1, AttackMax);
        }
        public double GetBlock()
        {
            return rnd.Next(1, AttackMax);
        }
    }
}
