using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class CombatController
    {


//METHODS LOL
        //@Checks life
        public bool isDead(Unit A)
        {
            bool output = false;
            if (A.getHP() <= 0)
            {
                output = true;
            }
            return output;
        }

        //@param calculates hit and damage and reduces health
        public void Attack(Unit A, Unit B)
        {
            Random rng = new Random();

            System.Console.WriteLine(A.getName() + " attacks!");

            int hit = rng.Next(100);
            int eva = rng.Next(10);
            System.Console.WriteLine("Acc:" + hit + "vs. " + (B.getEVA() + 20 + eva));

            if (hit >= B.getEVA()+20)
            {
                double damage = (A.getPATK()*1.5) - B.getPDEF() +1;
                int damage2 = (int)Math.Ceiling(damage);
                B.setHP(B.getHP() - damage2);

                System.Console.WriteLine("Hit! ("+damage+")... " + damage2 + " damage!");
            }
            else
            {
                System.Console.WriteLine("Miss!");
            }
        }
    }
}
