using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Unit
    {
        //Name
        String name;
        //hp, patk, pdef, spd, eva. 
        int[] stats = {0,0,0,0,0};

        int currentHealth = 0;

        int clockticks = 0; 

        bool willAct = false;

        //This will tick the unit forward.
        public void tick()
        {
            clockticks += stats[3];
        }

        //This clears the ticks
        public void clearTick()
        {
            clockticks = 0;
        }

        public int getTick()
        {
            return clockticks;
        }

        public String getName()
        {
            return name;
        }

        public void setWillAct(bool input)
        {
            willAct = input;
        }

       public bool getWillAct()
        {
            return willAct;
        }

        public void setStats(int[] newStats)
        {
            stats = newStats;
        }

        public void setHP(int input)
        {
            currentHealth = input;
        }

        public void setName(String inputName)
        {
            name = inputName;
        }

        public int[] getStats()
        {
            return stats;
        }

        public int getMaxHP()
        {
            return stats[0];
        }

        public int getHP()
        {
            return currentHealth;
        }

        public int getPATK()
        {
            return stats[1];
        }
        
        public int getPDEF()
        {
            return stats[2];
        }
        
        public int getSPD()
        {
            return stats[3];
        }
        
        public int getEVA()
        {
            return stats[4];
        }
    }
}
