using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ConsoleApplication1
{
    class Core
    {
        public static void CallToChildThread()
        {
            CombatController Controller = new CombatController();

            Unit Knight1 = new Unit();
            Knight1.setName("Allied Knight");
            int[] statsA = { 50, 11, 15, 7, -20 };
            Knight1.setStats(statsA);
            Controller.addUnit(Knight1);

            Unit Warrior1 = new Unit();
            Warrior1.setName("Allied Warrior");
            int[] statsB = { 35, 15, 10, 10, 0};
            Warrior1.setStats(statsB);
            Controller.addUnit(Warrior1);

            Unit Knight2 = new Unit();
            Knight2.setName("Enemy Knight");
            int[] statsC = { 50, 11, 15, 7, -20 };
            Knight2.setStats(statsC);
            Controller.addUnit(Knight2);

            Unit Warrior2 = new Unit();
            Warrior2.setName("Enemy Warrior");
            int[] statsD = { 35, 15, 10, 10, 0};
            Warrior2.setStats(statsD);
            Controller.addUnit(Warrior2);

            try
            {
                Console.WriteLine("Starting");

                bool isOver = false;

                int turnNumber = 1;

                while(isOver == false)
                {
                    Thread.Sleep(500);
                    Console.WriteLine(turnNumber);
                    Controller.displayTick();
                    Controller.clockTick();
                    bool state = false;
                    turnNumber++;
                }
             }

            catch (ThreadAbortException e)
            {
                Console.WriteLine("Thread Abort Exception");
            }
            finally
            {
                Console.WriteLine("Child Thread Completed");
            }
        }
        static void Main(string[] args)
        {
            ThreadStart childref = new ThreadStart(CallToChildThread);
            Thread childThread = new Thread(childref);
            childThread.Start();
        }
    }
}