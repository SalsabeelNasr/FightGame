using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FightGame
{
    public class Battle
    {
        private Random rnd = new Random(DateTime.Now.Second);
        private List<Warrior> warriors;
        public Battle(List<Warrior> warriors)
        {
            this.warriors = warriors;
            bool gameOver = false;
            while (!gameOver)
            {
                gameOver = PlayRound();
            }
            Console.WriteLine("Game Over!");
        }
        public bool PlayRound()
        {
            Warrior attacker = GetAttacker();
            foreach (Warrior warrior in warriors)
            {
                if (warrior.Name == attacker.Name || warrior.IsDead == true)
                    continue;
                Fight(ref attacker, warrior);
                IsDead(warrior);
                if (IsDead(attacker))
                    break;
                Console.WriteLine("---");
            }
            return IsGameOver();
        }
        private Warrior GetAttacker()
        {
            var aliveWarriors = warriors.Where(w => w.IsDead == false);
            int index = rnd.Next(0, aliveWarriors.Count() - 1);
            Warrior attacker = aliveWarriors.ElementAt(index);
            return attacker;
        }
        private bool IsGameOver()
        {
            if (warriors.Where(w => w.IsDead == false).Count() > 1)
                return false;
            else
            {
                Console.WriteLine("{0} Wins!", warriors.Where(w => w.IsDead == false).FirstOrDefault().Name);
                return true;
            }
        }
        private bool IsDead(Warrior warrior)
        {
            if (warrior.IsDead)
                Console.WriteLine("*************************************************************************{0} is dead!", warrior.Name);
            return warrior.IsDead;
        }
        private void Fight(ref Warrior attacker,  Warrior oponent)
        {
            double attack = attacker.GetAttack();
            double block = oponent.GetBlock();
            Console.WriteLine("{0} Attacks {1} with {2}", attacker.Name, oponent.Name, attack);
            Console.WriteLine("{0} Blocks with {1}", oponent.Name, block);
            double attackerDamage = block - attack;
            if (attackerDamage > 0)
            {
                attacker.Health -= attackerDamage;
                Console.WriteLine("{0} got hurt", attacker.Name);
                Console.WriteLine("{0} Health is {1}", attacker.Name, attacker.Health);
            }
            else if (attackerDamage == 0)
            {
                Console.WriteLine("Nobody got hurt!");
            }
            else
            {
                oponent.Health -= Math.Abs(attackerDamage);
                Console.WriteLine("{0} got hurt", oponent.Name);
                Console.WriteLine("{0} Health is {1}", oponent.Name, oponent.Health);
            }
        }

    }
}
