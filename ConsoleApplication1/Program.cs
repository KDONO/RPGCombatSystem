using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ConsoleApplication1
{
    class Program
    {
        public static void CallToChildThread()
        {
            Unit Knight = new Unit();
            Knight.setName("Knight");
            int[] statsA = { 50, 11, 15, 7, -20 };
            Knight.setStats(statsA);
            int knightticks = statsA[3];

            Unit Warrior = new Unit();
            Warrior.setName("Warrior");
            int[] statsB = { 35, 15, 10, 10, 0};
            Warrior.setStats(statsB);
            int warriorticks = statsB[3];

            CombatController Controller = new CombatController();
            try
            {
                Console.WriteLine("Starting");

                bool isOver = false;
                int clockticks = 0;

                // do some work, like counting to 10
                while(isOver == false)
                {
                    Console.WriteLine("Knight: " + Knight.getHP() + "hp, Warrior: " + Warrior.getHP() + "hp");
                    while(knightticks <= 100  && warriorticks <= 100)
                    {
                        Thread.Sleep(500);
                        Console.WriteLine(clockticks+ ": Knight: "+knightticks+", Warrior: "+warriorticks);
                        knightticks += Knight.getSPD();
                        warriorticks += Warrior.getSPD();
                        clockticks++;
                    }
                    if(knightticks >= 100)
                    {
                        Console.WriteLine("Knight: " + Knight.getHP() + "hp, Warrior: " + Warrior.getHP() + "hp");
                        Console.WriteLine("Knight's Turn!... 1)Attack 2)Wait 3)End");
                        String input = Console.ReadLine();
                        switch (input)
                        {
                            case "1":
                                {
                                    Controller.Attack(Knight, Warrior);
                                    knightticks -= 100;
                                    break;
                                }
                            case "2":
                                {
                                    Console.WriteLine("Wait...");
                                    knightticks -= 50;
                                    break;
                                }
                            case "3":
                                {
                                    isOver = true;
                                    knightticks -= 100;
                                    break;
                                }
                        }

                        Thread.Sleep(1000);
                    }
                    else if (warriorticks >= 100)
                    {
                        Console.WriteLine("Knight: "+Knight.getHP()+"hp, Warrior: "+Warrior.getHP()+"hp");
                        Console.WriteLine("Warrior turn!... 1)Attack 2)Wait 3)End");
                        String input = Console.ReadLine();
                        switch (input)
                        {
                            case "1":
                                {
                                    Controller.Attack(Warrior, Knight);
                                    warriorticks -= 100;
                                    break;
                                }
                            case "2":
                                {
                                    Console.WriteLine("Wait...");
                                    warriorticks -= 50;
                                    break;
                                }
                            case "3":
                                {
                                    isOver = true;
                                    warriorticks -= 100;
                                    break;
                                }
                        }
                        Thread.Sleep(1000);
                    }

                    if (Knight.getHP() <= 0 || Warrior.getHP() <= 0)
                    {
                        Console.WriteLine("End!");
                        isOver = true;
                    }
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