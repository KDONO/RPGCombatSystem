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

        public String getName()
        {
            return name;
        }

        public void setStats(int[] newStats)
        {
            stats = newStats;
        }

        public void setHP(int input)
        {
            stats[0] = input;
        }

        public void setName(String inputName)
        {
            name = inputName;
        }

        public int[] getStats()
        {
            return stats;
        }

        public int getHP()
        {
            return stats[0];
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
