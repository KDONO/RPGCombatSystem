using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class CombatController
    {
        //This is how the Controller determines if an action timeslot is complete.
        bool isOver = false;

        //This is the list of actors
        List<Unit>  Actors = new List<Unit>();

        //Adds a unit to the ActorList
        public void addUnit(Unit newUnit)
        {
            newUnit.setHP(newUnit.getMaxHP());
            Actors.Add(newUnit);
        }

        //This ticks all the units forward by one and checks to see if they are ready to act, and resolves that action.
        public void clockTick()
        {   
            //This tracks unit that will act
            List<Unit> toAct = new List<Unit>();

            //This loops through and ticks everyone!
            for (int i = 0; i < Actors.Count(); i++)
            {
               Actors[i].tick();
               if (Actors[i].getTick() >= 100)
               {
                   int target = ChooseTarget(Actors[i]);
                   ResolveAction(Actors[i], Actors[target]);
               }
            }
            ///NOTE... TODO HERE... to handle more than one unit reaching 100 at the same time, have them added to 
            ///a new array and sort that array by spd with preference to allied units? 
        }

        //Choose a target
        public int ChooseTarget(Unit Attacker)
        {
            Console.WriteLine(Attacker.getName()+"'s turn! Choose your target!");
            for (int i = 0; i < Actors.Count(); i++)
            {
                if (Attacker != Actors[i])
                {
                    Console.WriteLine(i + "). " + Actors[i].getName());
                }
            }
            int output = Int32.Parse(Console.ReadLine());
            return output;
        }

         //Sort a unit array by speed... THIS NEEDS TO BE TESTED....
        public void Sort(List<Unit> toAct)
        {
            List<Unit> temp = toAct;
            toAct.Clear();
            for (int i = 0; i < temp.Count(); i++)
            {                   
                int maxIndex = 0;

                for (int j = 0; j < temp.Count(); j++)
                {
                    if (toAct[j].getSPD() > toAct[maxIndex].getSPD())
                    {
                        maxIndex = j;
                    }
                }
                toAct.Add(toAct[maxIndex]); 
            }
        }

        public void displayTick()
        {
            for (int i = 0; i < Actors.Count(); i++)
            {
                Console.WriteLine("     "+Actors[i].getName()+"(HP:"+Actors[i].getHP()+" CT:"+Actors[i].getTick()+")");
            }
        }

        //This resolves an action... for now it just lets you choose who to attack! :O
        public void ResolveAction(Unit Attacker, Unit Defender)
        {
            //Resolves Attack
            Attack(Attacker, Defender);
            //Resets clocktick
            Attacker.clearTick();
            //Checks for Death
            isDead(Defender);
        }

        //@Checks life
        public void isDead(Unit input)
        {
            if (input.getHP() <= 0)
            {
                Console.WriteLine(input.getName() + " is dead!");
                Actors.Remove(input);
            }
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

        public void setIsOver(bool input)
        {
            isOver = input;
        }

        public bool getIsOver()
        {
            return isOver;
        }
    }
}
